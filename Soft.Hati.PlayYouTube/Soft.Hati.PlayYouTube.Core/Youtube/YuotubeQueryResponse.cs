using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.YouTube.v3.Data;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public class YuotubeQueryResponse : IQueryResponse
    {
        public IDictionary<TypeResult, IList<SearchResult>> Results { get; private set; }

        public YuotubeQueryResponse(IDictionary<TypeResult,SearchListResponse> searchResult)
        {
            Results = new Dictionary<TypeResult, IList<SearchResult>>
            {
                {TypeResult.video, new List<SearchResult>() },
                {TypeResult.playlist, new List<SearchResult>() },
                {TypeResult.channel, new List<SearchResult>() }
            };
            searchResult[TypeResult.video].Items.ToList().ForEach(item => Results[TypeResult.video].Add(new SearchResult(item.Id.VideoId, item.Snippet.Title, item.Snippet.Thumbnails.Default.Url, item.Snippet.Description, TypeResult.video)));
            searchResult[TypeResult.playlist].Items.ToList().ForEach(item => Results[TypeResult.playlist].Add(new SearchResult(item.Id.PlaylistId, item.Snippet.Title, item.Snippet.Thumbnails.Default.Url, item.Snippet.Description, TypeResult.playlist)));
            searchResult[TypeResult.channel].Items.ToList().ForEach(item => Results[TypeResult.channel].Add(new SearchResult(item.Snippet.ChannelTitle, item.Snippet.Title, item.Snippet.Thumbnails.Default.Url, item.Snippet.Description, TypeResult.channel)));
        }
    }

    public class SearchResult
    {
        public SearchResult(string id, string name, string thumbnail, string description, TypeResult type)
        {
            Id = id;
            Name = name;
            Thumbnail = thumbnail;
            Description = description;
            Type = type;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Thumbnail { get; private set; }
        public string Description { get; private set; }
        public TypeResult Type { get; private set; }
    }
}