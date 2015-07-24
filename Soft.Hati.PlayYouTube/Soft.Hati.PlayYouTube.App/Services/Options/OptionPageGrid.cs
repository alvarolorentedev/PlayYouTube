using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Soft.Hati.PlayYouTube.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.Services.Options
{
    [Guid("6D6519AF-8B2E-46BF-A747-9136EE16D85D")]
    public class OptionPage : DialogPage
    {
        private readonly OptionsManager optionsManager;
        private readonly SettingStoreProvider settingStoreProvider;
        

        public OptionPage()
        {
            settingStoreProvider = new SettingStoreProvider("PlayYouTube");
            if (settingStoreProvider.Exist("SafeSearchLevel"))
                optionsManager =
                    new OptionsManager(
                        (SafeSearchLevel.Enum)
                            Enum.Parse(typeof(SafeSearchLevel.Enum), settingStoreProvider.Get("SafeSearchLevel")));
            else
                optionsManager = new OptionsManager();
        }

        public OptionsManager OptionsManager { get { return optionsManager; } }

        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionUserControl { OptionsPage = this };
                page.OptionsPage = this;
                page.Initialize(optionsManager);
                return page;
            }
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            settingStoreProvider.Set("SafeSearchLevel", optionsManager.SafeSearchLevel.ToString());
        }

    }
}