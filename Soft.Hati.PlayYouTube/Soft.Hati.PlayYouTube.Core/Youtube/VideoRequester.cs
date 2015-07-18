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
            var searchListRequest = serviceContainer.Service.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.Type = "video";
            searchListRequest.SafeSearch = SafeSearchLevel.Level[safeSearchLevel];
            searchListRequest.MaxResults = 20;

            return new YuotubeQueryResponse(await searchListRequest.ExecuteAsync());
        }
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