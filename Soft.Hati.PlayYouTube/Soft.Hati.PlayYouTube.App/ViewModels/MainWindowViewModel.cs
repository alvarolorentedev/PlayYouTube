using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Soft.Hati.YouPlayVS.Core.MVVM;
using Soft.Hati.YouPlayVS.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _idStringVideo;
        private string _idVideo;

        public MainWindowViewModel()
        {
            GoCommand = new RelayCommand(Search, arg => true);
        }

        private void Search(object obj)
        {
            var req = new VideoRequester(new YouMixServiceContainer());
            req.Search(IDStringVideo).ContinueWith(result =>
            {
                videos = new ObservableCollection<SearchResult>(result.Result.Videos);
            });
        }

        public ObservableCollection<SearchResult> videos { get; set; }

        public ICommand GoCommand { get; private set; }

        public string IDStringVideo
        {
            get { return _idStringVideo; }
            set { SetValue(ref _idStringVideo, value, () => IDStringVideo); }
        }

        public string IDVideo
        {
            get { return _idVideo; }
            set { SetValue(ref _idVideo, value, () => IDVideo); }
        }
    }
}