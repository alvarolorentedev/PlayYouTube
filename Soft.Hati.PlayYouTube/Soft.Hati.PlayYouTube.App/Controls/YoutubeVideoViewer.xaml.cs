using System;
using System.Windows;
using System.Windows.Controls;
using Soft.Hati.PlayYouTube.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.Controls
{
    public partial class YoutubeVideoViewer : UserControl
    {
        private const string Html = "<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='application/x-shockwave-flash' /><meta http-equiv='X-UA-Compatible' content='IE=Edge' /><title></title>"
            + "<style>html, body {{height: 100%; margin: 0px 0px 10px 0px;}}</style></head>"
            + "<iframe preload='metadata' width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed{0}\" frameborder=\"0\" allowfullscreen></iframe></html>";

        public YoutubeVideoViewer()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SearchResultProperty = DependencyProperty.Register("SearchResult", typeof(SearchResult), typeof(YoutubeVideoViewer), new PropertyMetadata(OnSearchResultChange));

        public SearchResult SearchResult
        {
            get { return (SearchResult)GetValue(SearchResultProperty); }
            set { SetValue(SearchResultProperty, value); }
        }

        private static void OnSearchResultChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (YoutubeVideoViewer)d;
            var newValue = (SearchResult)e.NewValue;
            control.browser.NavigateToString(control.UpdateHtml(newValue.Id, newValue.Type));
        }

        private static string AppenderSelector(TypeResult resultType)
        {
            switch (resultType)
            {
                case TypeResult.video:
                     return "/";
                case TypeResult.playlist:
                    return "?listType=playlist&list=";
                case TypeResult.channel:
                    return "?listType=user_uploads&list=";
                default:
                    throw new NotSupportedException();
            }
        }

        private string UpdateHtml(string id, TypeResult resultType)
        {
            return string.Format(Html, string.Format("{0}{1}", AppenderSelector(resultType), id));
        }

        private void browser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            string script = "document.body.style.overflow ='hidden'";
            WebBrowser wb = (WebBrowser)sender;
            wb.InvokeScript("execScript", new Object[] { script, "JavaScript" });
        }
    }

    
}
