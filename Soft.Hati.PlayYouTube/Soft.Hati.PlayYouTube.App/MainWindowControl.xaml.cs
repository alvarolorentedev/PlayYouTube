using System;
using System.IO;
using Soft.Hati.PlayYouTube.App.ViewModels;

namespace Soft.Hati.PlayYouTube.App
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindowControl : UserControl
    {
        public MainWindowControl()
        {
            InstallAvalonToGac();
            this.InitializeComponent();
        }

    private static void InstallAvalonToGac()
    {
        var fullpath = Path.Combine(Environment.CurrentDirectory, "Xceed.Wpf.AvalonDock.dll");
        new System.EnterpriseServices.Internal.Publish().GacInstall(fullpath);
    }

    [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "MainWindow");
        }
    }
}