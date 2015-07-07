using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.YouTube.v3.Data;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public class YuotubeQueryResponse : IQueryResponse
    {
        private readonly IList<SearchResult> videos = new List<SearchResult>();

        public YuotubeQueryResponse(SearchListResponse listResponse)
        {
            listResponse.Items.ToList().ForEach(item => videos.Add(new SearchResult(item.Id.VideoId, item.Snippet.Title,item.Snippet.Thumbnails.Default.Url,item.Snippet.Description)));
        }
        public IEnumerable<SearchResult> Videos
        {
            get { return videos; }
        }
    }

    public class SearchResult
    {
        public SearchResult(string id, string name, string thumbnail, string description)
        {
            Id = id;
            Name = name;
            Thumbnail = thumbnail;
            Description = description;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Thumbnail { get; private set; }
        public string Description { get; private set; }
    }
}