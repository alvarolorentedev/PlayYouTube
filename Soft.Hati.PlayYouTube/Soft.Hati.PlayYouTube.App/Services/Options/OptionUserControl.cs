using System;
using System.Windows.Forms;
using Soft.Hati.PlayYouTube.Core.Youtube;

namespace Soft.Hati.PlayYouTube.App.Services.Options
{
    public partial class OptionUserControl : UserControl
    {
        private OptionsManager optionsManager;

        public OptionUserControl()
        {
            InitializeComponent();
        }

        internal OptionPage OptionsPage;

        private void SearchEngineCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SafeSearchLevel.Enum level;
            Enum.TryParse(SearchEngineCB.SelectedValue.ToString(), out level);
            optionsManager.SafeSearchLevel = level;
        }

        internal void Initialize(OptionsManager optionsManager)
        {
            this.optionsManager = optionsManager;
            SearchEngineCB.DataSource = Enum.GetValues(typeof(SafeSearchLevel.Enum));
        }
    }

    
}
