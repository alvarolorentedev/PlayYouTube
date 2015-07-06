using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.YouTube.v3.Data;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public class YuotubeQueryResponse : IQueryResponse
    {
        private IList<SearchResult> videos = new List<SearchResult>();

        public YuotubeQueryResponse(SearchListResponse listResponse)
        {
            listResponse.Items.ToList().ForEach(item =>
            {
                switch (item.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(new SearchResult
                        {
                            Id = item.Id.VideoId,
                            Name = item.Snippet.Title,
                            Thumbnail = item.Snippet.Thumbnails.Default.Url,
                            Description = item.Snippet.Description,

                        });
                        break;

                    case "youtube#channel":
                    case "youtube#playlist":
                        break;
                }
            });
        }
        public IEnumerable<SearchResult> Videos
        {
            get { return videos; }
        }
    }

    public class SearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
    }
}