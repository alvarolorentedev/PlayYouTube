using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Soft.Hati.PlayYouTube.App.Services.Options;
using Soft.Hati.YouPlayVS.Core.MVVM;
using Soft.Hati.YouPlayVS.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly OptionsManager options;
        private string idStringVideo;
        private string idVideo;
        private IEnumerable<SearchResult> videos;
        private SearchResult selectedVideo;
        private bool searchInProgress;
        private IEnumerable<SearchResult> playlists;
        private IEnumerable<SearchResult> channels;
        private TypeResult _linkType;

        public MainWindowViewModel(OptionsManager options)
        {
            this.options = options;
            GoCommand = new RelayCommand(Search, arg => true);
        }

        private async void Search(object obj)
        {
            try
            {
                SearchInProgress = true;
                var req = new VideoRequester(new YouMixServiceContainer());
                var result = await req.Search(IDStringVideo, options.SafeSearchLevel);
                Videos = result.Results[TypeResult.video];
                Playlists = result.Results[TypeResult.playlist];
                Channels = result.Results[TypeResult.channel];
                SearchInProgress = false;
            }
            catch (Exception)
            {
                HandleSearchException();
                SearchInProgress = false;
            }
            
        }

        private void HandleSearchException()
        {
            MessageBox.Show(
                "Error accessing web service, please check your conection. If the problems perseveres please contact us",
                "Network Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public IEnumerable<SearchResult> Videos
        {
            get { return videos; }
            set { SetValue(ref videos, value, () => Videos); }
        }

        public IEnumerable<SearchResult> Playlists
        {
            get { return playlists; }
            set { SetValue(ref playlists, value, () => Playlists); }
        }

        public IEnumerable<SearchResult> Channels
        {
            get { return channels; }
            set { SetValue(ref channels, value, () => Channels); }
        }

        public bool SearchInProgress
        {
            get { return searchInProgress; }
            set { SetValue(ref searchInProgress, value, () => SearchInProgress); }
        }

        public SearchResult SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                if (value == null)
                    return;

                SetValue(ref selectedVideo, value, ()=> SelectedVideo);
            }
        }

        public ICommand GoCommand { get; private set; }

        public string IDStringVideo
        {
            get { return idStringVideo; }
            set { SetValue(ref idStringVideo, value, () => IDStringVideo); }
        }

        public TypeResult LinkType
        {
            get { return _linkType; }
            set { SetValue(ref _linkType, value, () => LinkType); }
        }

    }
}