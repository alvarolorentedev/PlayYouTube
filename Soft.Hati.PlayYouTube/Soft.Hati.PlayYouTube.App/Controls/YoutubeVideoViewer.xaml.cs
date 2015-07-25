using System;
using System.Diagnostics;
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
            //UserNavigationRequest = false;
            return string.Format(Html, string.Format("{0}{1}", AppenderSelector(resultType), id));
        }

        private void browser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            RemoveScrollbar(sender);
            HandleNewWindow(sender);
        }

        private void HandleNewWindow(object sender)
        {
            var Browser = (WebBrowser)sender;
            var SID_SWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");

            try
            {
                var serviceProvider = (UCOMIServiceProvider) Browser.Document;
                var serviceGuid = SID_SWebBrowserApp;
                var iid = typeof (SHDocVw.IWebBrowser2).GUID;
                var myWebBrowser2 = (SHDocVw.IWebBrowser2) serviceProvider.QueryService(ref serviceGuid, ref iid);
                var wbEvents = (SHDocVw.DWebBrowserEvents_Event) myWebBrowser2;
                wbEvents.NewWindow += new SHDocVw.DWebBrowserEvents_NewWindowEventHandler(OnWebBrowserNewWindow);
            }
            catch (Exception)
            {
            }
        }

        private static void RemoveScrollbar(object sender)
        {
            string script = "document.body.style.overflow ='hidden'";
            WebBrowser wb = (WebBrowser) sender;
            wb.InvokeScript("execScript", new Object[] {script, "JavaScript"});
        }

        private void OnWebBrowserNewWindow(string url, int flags, string targetframename, ref object postdata, string headers, ref bool processed)
        {
            processed = true;
            Process.Start(url);
        }
    }
}
