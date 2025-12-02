using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WinFormsYoutube
{
    internal class DatabaseHelper
    {
        private const string connectionString = "Data Source=youtube_cache.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS TrendingVideos (
                    VideoId TEXT PRIMARY KEY,
                    Title TEXT,
                    ChannelTitle TEXT,
                    ViewCount INTEGER,
                    LikeCount INTEGER,
                    PublishedAt TEXT,
                    Description TEXT,
                    ThumbnailUrl TEXT,
                    CacheDate TEXT 
                );";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static async Task<List<YTVideo>> GetTrendingVideosAsync(DateTime date)
        {
            var videos = new List<YTVideo>();
            string cacheDateStr = date.ToString("yyyy-MM-dd");

            using (var cnn = new SQLiteConnection(connectionString))
            {
                await cnn.OpenAsync();
                string sql = "SELECT * FROM TrendingVideos WHERE CacheDate = @CacheDate";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@CacheDate", cacheDateStr);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            videos.Add(new YTVideo
                            {
                                VideoId = reader["VideoId"].ToString(),
                                Title = reader["Title"].ToString(),
                                ChannelTitle = reader["ChannelTitle"].ToString(),
                                ViewCount = Convert.ToInt64(reader["ViewCount"]),
                                LikeCount = Convert.ToInt64(reader["LikeCount"]),
                                PublishedAt = DateTime.Parse(reader["PublishedAt"].ToString()),
                                Description = reader["Description"].ToString(),
                                ThumbnailUrl = reader["ThumbnailUrl"].ToString()
                            });
                        }
                    }
                }
            }
            return videos;
        }

        public static async Task SaveTrendingVideosAsync(List<YTVideo> videos, DateTime date)
        {
            string cacheDateStr = date.ToString("yyyy-MM-dd");

            using (var cnn = new SQLiteConnection(connectionString))
            {
                await cnn.OpenAsync();
                using (var transaction = cnn.BeginTransaction())
                {
                    string sql = @"
                    INSERT OR REPLACE INTO TrendingVideos 
                    (VideoId, Title, ChannelTitle, ViewCount, LikeCount, PublishedAt, Description, ThumbnailUrl, CacheDate) 
                    VALUES 
                    (@VideoId, @Title, @ChannelTitle, @ViewCount, @LikeCount, @PublishedAt, @Description, @ThumbnailUrl, @CacheDate)";

                    foreach (var vid in videos)
                    {
                        using (var cmd = new SQLiteCommand(sql, cnn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@VideoId", vid.VideoId);
                            cmd.Parameters.AddWithValue("@Title", vid.Title);
                            cmd.Parameters.AddWithValue("@ChannelTitle", vid.ChannelTitle);
                            cmd.Parameters.AddWithValue("@ViewCount", vid.ViewCount);
                            cmd.Parameters.AddWithValue("@LikeCount", vid.LikeCount);
                            cmd.Parameters.AddWithValue("@PublishedAt", vid.PublishedAt.ToString("o")); // ISO 8601
                            cmd.Parameters.AddWithValue("@Description", vid.Description);
                            cmd.Parameters.AddWithValue("@ThumbnailUrl", vid.ThumbnailUrl);
                            cmd.Parameters.AddWithValue("@CacheDate", cacheDateStr);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
