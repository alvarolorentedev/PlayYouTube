using Soft.Hati.PlayYouTube.App.ViewModels;

namespace Soft.Hati.PlayYouTube.App
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using Soft.Hati.PlayYouTube.App.Services.Options;

    [Guid("61f43393-414e-4c8b-a407-fee1ed9ac634")]
    public class MainWindow : ToolWindowPane
    {
        public MainWindow() : base(null)
        {
            this.Caption = "PlayYouTube";
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;
            this.Content = new MainWindowControl();
        }

        internal void Initialize(OptionsManager options)
        {
            var window = (MainWindowControl)this.Content;
            window.DataContext = new MainWindowViewModel(options);
        }
    }
}
