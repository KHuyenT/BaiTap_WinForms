using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsYoutube
{
        public class YTVideo
        {
            public string VideoId { get; set; }
            public string Title { get; set; }
            public string ChannelTitle { get; set; }
            public long ViewCount { get; set; }
            public long LikeCount { get; set; }
            public DateTime PublishedAt { get; set; }
            public string Description { get; set; }
            public string ThumbnailUrl { get; set; }
        }
}
