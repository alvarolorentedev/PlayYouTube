using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public class VideoRequester
    {
        private readonly IYoutubeServiceContainer serviceContainer;

        public VideoRequester(IYoutubeServiceContainer serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        public async Task<YuotubeQueryResponse> Search(string query, SafeSearchLevel.Enum safeSearchLevel)
        {
            var LastResponses = new Dictionary<TypeResult, SearchListResponse>();
            LastResponses.Add(TypeResult.video, await SearchVideos(query, safeSearchLevel));
            LastResponses.Add(TypeResult.playlist, await SearchPlaylists(query, safeSearchLevel));
            LastResponses.Add(TypeResult.channel, await SearchChannels(query, safeSearchLevel));
            return new YuotubeQueryResponse(LastResponses);
        }

        private async Task<SearchListResponse> SearchVideos(string query, SafeSearchLevel.Enum safeSearchLevel)
        {
            var searchListRequest = serviceContainer.Service.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.SafeSearch = SafeSearchLevel.Level[safeSearchLevel];
            searchListRequest.MaxResults = 20;
            searchListRequest.Type = TypeResult.video.ToString();
            return await searchListRequest.ExecuteAsync();
        }

        private async Task<SearchListResponse> SearchPlaylists(string query, SafeSearchLevel.Enum safeSearchLevel)
        {
            var searchListRequest = serviceContainer.Service.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.SafeSearch = SafeSearchLevel.Level[safeSearchLevel];
            searchListRequest.MaxResults = 20;
            searchListRequest.Type = TypeResult.playlist.ToString();
            return await searchListRequest.ExecuteAsync();
        }

        private async Task<SearchListResponse> SearchChannels(string query, SafeSearchLevel.Enum safeSearchLevel)
        {
            var searchListRequest = serviceContainer.Service.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.SafeSearch = SafeSearchLevel.Level[safeSearchLevel];
            searchListRequest.MaxResults = 20;
            searchListRequest.Type = TypeResult.channel.ToString();
            return await searchListRequest.ExecuteAsync();
        }

        public IDictionary<TypeResult, SearchListResponse> LastResponses { get; private set; }
    }

    public enum TypeResult
    {
        video,
        playlist,
        channel
    }

    public class SafeSearchLevel
    { 
        public enum Enum
        {
            All,
            Moderate,
            Strict
        }
        public static readonly IDictionary<Enum, SearchResource.ListRequest.SafeSearchEnum> Level = new Dictionary<Enum, SearchResource.ListRequest.SafeSearchEnum>
        {
            { Enum.All, SearchResource.ListRequest.SafeSearchEnum.None },
            { Enum.Moderate, SearchResource.ListRequest.SafeSearchEnum.Moderate },
            { Enum.Strict,  SearchResource.ListRequest.SafeSearchEnum.Strict }
        };
    }
}