using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;
using WinFormsYoutube;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        // ======= CONFIG =======
        private const string API_KEY = "AIzaSyDp0CK3SzkL6nN2buu05ayClZC_2qapHfo";
        private const string REGION_CODE = "VN";
        private const int MAX_RESULTS = 25;
        // =======================

        private HttpClient httpClient = new HttpClient();
        private List<YTVideo> videos = new List<YTVideo>();

        public MainForm()
        {
            InitializeComponent(); // gọi method trong Designer
            InitializeDataGridColumns();
            this.Load += Form1_Load;
        }

        private void InitializeDataGridColumns()
        {
            dgvVideos.Columns.Clear();
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Title" });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Channel", HeaderText = "Channel" });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Views", HeaderText = "Views", FillWeight = 20 });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Likes", HeaderText = "Likes", FillWeight = 15 });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Published", HeaderText = "Published", FillWeight = 20 });
            dgvVideos.Columns.Add(new DataGridViewTextBoxColumn { Name = "VideoId", HeaderText = "VideoId", Visible = false });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.InitializeDatabase();
            lblStatus.Text = "Initializing WebView...";
            try
            {
                await webView.EnsureCoreWebView2Async();
                lblStatus.Text = "Ready";
            }
            catch
            {
                lblStatus.Text = "WebView2 not available - will open browser on Play";
            }

            // Optionally auto load trending
            await LoadTrendingAsync();
        }

        #region API logic
        private async Task LoadTrendingAsync()
        {
            try
            {
                SetUiBusy("Loading trending...");
                videos.Clear();
                dgvVideos.Rows.Clear();

                DateTime today = DateTime.Today;
                var cachedVideos = await DatabaseHelper.GetTrendingVideosAsync(today);

                if (cachedVideos.Count > 0)
                {
                    // --- TẢI TỪ CACHE ---
                    SetUiBusy("Loading trending from cache...");
                    videos.AddRange(cachedVideos);
                    foreach (var vid in videos)
                    {
                        dgvVideos.Rows.Add(
                            vid.Title,
                            vid.ChannelTitle,
                            vid.ViewCount.ToString("N0"),
                            vid.LikeCount.ToString("N0"),
                            vid.PublishedAt.ToString("dd/MM/yyyy HH:mm"),
                            vid.VideoId
                        );
                    }
                    SetUiReady($"Loaded trending from cache: {videos.Count}");
                    return; // Kết thúc
                }

                // --- TẢI TỪ API (NẾU KHÔNG CÓ CACHE) ---
                SetUiBusy("Loading trending from YouTube API...");
                string url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&chart=mostPopular&regionCode={REGION_CODE}&maxResults={MAX_RESULTS}&key={API_KEY}";
                var resp = await httpClient.GetAsync(url);
                if (!resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error fetching trending: {resp.StatusCode}\n{await resp.Content.ReadAsStringAsync()}");
                    SetUiReady("Error loading trending");
                    return;
                }

                string json = await resp.Content.ReadAsStringAsync();
                var j = JObject.Parse(json);
                var items = (JArray)j["items"];
                List<YTVideo> newVideos = new List<YTVideo>(); // Dùng list tạm

                foreach (var it in items)
                {
                    var id = (string)it["id"];
                    var snippet = it["snippet"];
                    var stats = it["statistics"];
                    var vid = new YTVideo
                    {
                        VideoId = id,
                        Title = (string)snippet["title"] ?? "",
                        ChannelTitle = (string)snippet["channelTitle"] ?? "",
                        ViewCount = stats != null && stats["viewCount"] != null ? (long)(stats.Value<long?>("viewCount") ?? 0) : 0,
                        LikeCount = stats != null && stats["likeCount"] != null ? (long)(stats.Value<long?>("likeCount") ?? 0) : 0,
                        PublishedAt = DateTime.Parse((string)snippet["publishedAt"]),
                        Description = (string)snippet["description"] ?? "",
                        ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? (string)snippet["thumbnails"]?["default"]?["url"]
                    };
                    newVideos.Add(vid); // Thêm vào list tạm
                }

                // Lưu vào CSDL
                await DatabaseHelper.SaveTrendingVideosAsync(newVideos, today);

                // Cập nhật UI từ list tạm
                videos.AddRange(newVideos);
                foreach (var vid in videos)
                {
                    dgvVideos.Rows.Add(
                       vid.Title,
                       vid.ChannelTitle,
                       vid.ViewCount.ToString("N0"),
                       vid.LikeCount.ToString("N0"),
                       vid.PublishedAt.ToString("dd/MM/yyyy HH:mm"),
                       vid.VideoId
                   );
                }

                SetUiReady($"Loaded trending: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }

        private async Task SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) { MessageBox.Show("Please enter search terms."); return; }

            try
            {
                SetUiBusy($"Searching \"{query}\"...");
                videos.Clear();
                dgvVideos.Rows.Clear();

                string urlSearch = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&maxResults={MAX_RESULTS}&q={Uri.EscapeDataString(query)}&regionCode={REGION_CODE}&key={API_KEY}";
                var resp = await httpClient.GetAsync(urlSearch);
                if (!resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Search error: {resp.StatusCode}\n{await resp.Content.ReadAsStringAsync()}");
                    SetUiReady("Search error");
                    return;
                }

                string jsonSearch = await resp.Content.ReadAsStringAsync();
                var jSearch = JObject.Parse(jsonSearch);
                var items = (JArray)jSearch["items"];
                var ids = items.Select(it => (string)it["id"]?["videoId"]).Where(id => !string.IsNullOrEmpty(id)).ToList();
                if (ids.Count == 0) { SetUiReady("No results"); return; }

                string idsParam = string.Join(",", ids);
                string urlVideos = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={idsParam}&key={API_KEY}";
                var resp2 = await httpClient.GetAsync(urlVideos);
                if (!resp2.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Videos error: {resp2.StatusCode}\n{await resp2.Content.ReadAsStringAsync()}");
                    SetUiReady("Error");
                    return;
                }

                string jsonVideos = await resp2.Content.ReadAsStringAsync();
                var jVideos = JObject.Parse(jsonVideos);
                var items2 = (JArray)jVideos["items"];
                foreach (var it in items2)
                {
                    var id = (string)it["id"];
                    var snippet = it["snippet"];
                    var stats = it["statistics"];
                    var vid = new YTVideo
                    {
                        VideoId = id,
                        Title = (string)snippet["title"] ?? "",
                        ChannelTitle = (string)snippet["channelTitle"] ?? "",
                        ViewCount = stats != null && stats["viewCount"] != null ? (long)(stats.Value<long?>("viewCount") ?? 0) : 0,
                        LikeCount = stats != null && stats["likeCount"] != null ? (long)(stats.Value<long?>("likeCount") ?? 0) : 0,
                        PublishedAt = DateTime.Parse((string)snippet["publishedAt"]),
                        Description = (string)snippet["description"] ?? "",
                        ThumbnailUrl = (string)snippet["thumbnails"]?["medium"]?["url"] ?? (string)snippet["thumbnails"]?["default"]?["url"]
                    };
                    videos.Add(vid);
                    dgvVideos.Rows.Add(vid.Title, vid.ChannelTitle, vid.ViewCount.ToString("N0"), vid.LikeCount.ToString("N0"), vid.PublishedAt.ToString("dd/MM/yyyy HH:mm"), vid.VideoId);
                }

                SetUiReady($"Search results: {videos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SetUiReady("Error");
            }
        }
        #endregion

        #region UI Helpers & Handlers
        private void SetUiBusy(string text)
        {
            lblStatus.Text = text;
            btnTrending.Enabled = btnSearch.Enabled = btnPlay.Enabled = false;
        }

        private void SetUiReady(string text)
        {
            lblStatus.Text = text;
            btnTrending.Enabled = btnSearch.Enabled = btnPlay.Enabled = true;
        }

        private async void BtnTrending_Click(object sender, EventArgs e)
        {
            await LoadTrendingAsync();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await SearchAsync(txtSearch.Text.Trim());
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            PlaySelected();
        }

        private void DgvVideos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) PlaySelected();
        }

        private async void DgvVideos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count == 0) return;
            var videoId = dgvVideos.SelectedRows[0].Cells["VideoId"].Value?.ToString();
            if (string.IsNullOrEmpty(videoId)) return;

            var v = videos.FirstOrDefault(x => x.VideoId == videoId);
            if (v == null) return;

            lblStatus.Text = $"Selected: {v.Title}";
            txtDescription.Text = v.Description;
            // load thumbnail
            if (!string.IsNullOrEmpty(v.ThumbnailUrl))
            {
                try
                {
                    using var s = await httpClient.GetStreamAsync(v.ThumbnailUrl);
                    picThumbnail.Image?.Dispose();
                    picThumbnail.Image = System.Drawing.Image.FromStream(s);
                }
                catch
                {
                    picThumbnail.Image = null;
                }
            }
            else picThumbnail.Image = null;
        }

        private void PlaySelected()
        {
            if (dgvVideos.SelectedRows.Count == 0) { MessageBox.Show("Please select a video first."); return; }
            string id = dgvVideos.SelectedRows[0].Cells["VideoId"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            string url = $"https://www.youtube.com/watch?v={id}";

            if (webView?.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(url);
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = url, UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot open browser: " + ex.Message);
                }
            }
        }
        #endregion    
    }
}
