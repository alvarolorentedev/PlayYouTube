namespace Soft.Hati.PlayYouTube.App
{
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("61f43393-414e-4c8b-a407-fee1ed9ac634")]
    public class MainWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow() : base(null)
        {
            this.Caption = "MainWindow";

            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.
            this.Content = new MainWindowControl();
        }
    }
}
