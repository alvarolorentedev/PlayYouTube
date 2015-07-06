using System;
using System.Windows;
using System.Windows.Controls;

namespace Soft.Hati.PlayYouTube.App.Controls
{
    public partial class YoutubeVideoViewer : UserControl
    {

        static string html = "<iframe width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed/{0}?rel=0\" frameborder=\"0\" allowfullscreen></iframe>";

        public YoutubeVideoViewer()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty VideoIDProperty = DependencyProperty.Register("VideoID", typeof(string), typeof(YoutubeVideoViewer), new PropertyMetadata(OnVideoIDChange));

        private static void OnVideoIDChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = ((YoutubeVideoViewer) d).browser;
            webBrowser.NavigateToString(string.Format(html, e.NewValue));
        }

        public string VideoID
        {
            get { return (string)GetValue(VideoIDProperty); }
            set { SetValue(VideoIDProperty, value); }
        }

        private void browser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            string script = "document.body.style.overflow ='hidden'";
            WebBrowser wb = (WebBrowser)sender;
            wb.InvokeScript("execScript", new Object[] { script, "JavaScript" });
        }
    }

    
}
