namespace hq_youtube_video_downloader.Models.Home
{
    public class HomeIndexViewModel
    {
        public string VideoUrl { get; set; }


        /// <summary>
        /// Metadata
        /// </summary>
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string Author { get; set; }

    }
}
