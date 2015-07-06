using Google.Apis.YouTube.v3;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public interface IYoutubeServiceContainer
    {
        YouTubeService Service { get; }
    }
}