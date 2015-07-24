using Soft.Hati.PlayYouTube.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.Services.Options
{
    public class OptionsManager
    {
        public OptionsManager(SafeSearchLevel.Enum level = Core.Youtube.SafeSearchLevel.Enum.All)
        {
            SafeSearchLevel = level;
        }

        public SafeSearchLevel.Enum SafeSearchLevel { get; set; }
    }
}