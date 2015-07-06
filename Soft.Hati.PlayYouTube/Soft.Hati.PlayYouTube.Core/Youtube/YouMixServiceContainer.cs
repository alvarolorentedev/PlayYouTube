using System;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Soft.Hati.YouPlayVS.Core.Youtube
{
    public class YouMixServiceContainer : IYoutubeServiceContainer
    {
        public YouMixServiceContainer()
        {
            AssemblyHandler.RedirectAssembly("System.Net.Http.Primitives", new Version(4, 2, 28, 0), "b03f5f7f11d50a3a");
            Service = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyD8ZsvvMyOSftpldDtxeRmDkjGYmyzhnAQ",
                ApplicationName = "YouMixVS"
            });
        }

        public YouTubeService Service { get; private set; }
    }
}