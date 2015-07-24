using Google.Apis.YouTube.v3;

namespace Soft.Hati.PlayYouTube.Core.Youtube
{
    public interface IYoutubeServiceContainer
    {
        YouTubeService Service { get; }
    }
}