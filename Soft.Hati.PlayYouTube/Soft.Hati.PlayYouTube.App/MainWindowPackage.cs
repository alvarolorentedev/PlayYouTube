using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Soft.Hati.PlayYouTube.App.Services.Options;

namespace Soft.Hati.PlayYouTube.App
{
    [ProvideBindingPath]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(MainWindow))]
    [Guid(MainWindowPackageGuids.PackageGuidString)]
    [ProvideOptionPage(typeof(OptionPage), "PlayYouTube", "General", 0, 0, true)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class MainWindowPackage : Package
    {
        protected override void Initialize()
        {
            MainWindowCommand.Initialize(this);
            base.Initialize();
        }

        public OptionsManager Options
        {
            get
            {
                var page = (OptionPage)GetDialogPage(typeof(OptionPage));
                return page.OptionsManager;
            }
        }
    }
}
