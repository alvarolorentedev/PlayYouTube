using Soft.Hati.YouPlayVS.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.Services.Options
{
    public class OptionsManager
    {
        public OptionsManager(SafeSearchLevel.Enum level = YouPlayVS.Core.Youtube.SafeSearchLevel.Enum.All)
        {
            SafeSearchLevel = level;
        }

        public SafeSearchLevel.Enum SafeSearchLevel { get; set; }
    }
}