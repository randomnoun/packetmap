using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

/// <summary>
/// This is public domain software - that is, you can do whatever you want
/// with it, and include it software that is licensed under the GNU or the
/// BSD license, or whatever other licence you choose, including proprietary
/// closed source licenses.  I do ask that you leave this lcHeader in tact.
///
/// QAlbum.NET makes use of this control to display pictures.
/// Please visit <a href="http://www.qalbum.net/en/">http://www.qalbum.net/en/</a>
/// </summary>
namespace QAlbum
{

    /// <summary>
    /// A scrollable, zoomable and scalable picture box.
    /// It is data aware, and creates zoom rate context menu dynamicly.
    /// 
    /// Now supports overlays with callbacks.
    /// </summary>
	public partial class ScalablePictureBox : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The name of fit width ToolStripMenuItem
        /// </summary>
        const String FIT_WIDTH_MENU_ITEM_NAME = "fitWidthScaleToolStripMenuItem";

        /// <summary>
        /// The name of show whole ToolStripMenuItem
        /// </summary>
        const String SHOW_WHOLE_MENU_ITEM_NAME = "showWholeToolStripMenuItem";

        /// <summary>
        /// Maximum scale percent(100%)
        /// </summary>
        const float MAX_SCALE_PERCENT = 1;

        /// <summary>
        /// Zoom in cursor
        /// </summary>
        private static Cursor zoomInCursor = null;

        /// <summary>
        /// Zoom out cursor
        /// </summary>
        private static Cursor zoomOutCursor = null;

        /// <summary>
        /// Picture size mode
        /// </summary>
        private PictureBoxSizeMode pictureBoxSizeMode = PictureBoxSizeMode.Zoom;

        /// <summary>
        /// Need dispose image when new image is set
        /// </summary>
        private bool needDisposeImage = false;

        /// <summary>
        /// Scale percentage of picture box in zoom mode
        /// </summary>
        private float currentScalePercent = MAX_SCALE_PERCENT;

        /// <summary>
        /// Last selected menu item name
        /// </summary>
        private String lastSelectedMenuItemName = SHOW_WHOLE_MENU_ITEM_NAME;

        /// <summary>
        /// Fit width image
        /// </summary>
        Image fitWidthImage;

        /// <summary>
        /// Show whole image
        /// </summary>
        Image showWholeImage;

        /// <summary>
        /// Show actual image
        /// </summary>
        Image showActualSizeImage;

        /// <summary>
        /// Offset of picturebox image within component
        /// </summary>
        private Point internalLocation;
        public Point InternalLocation {
            get { return internalLocation; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
		public ScalablePictureBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            // Read icon images
            fitWidthImage = Util.GetImageFromScalablePictureBoxEmbeddedResource("QAlbum.showFitWidth.png");
            showWholeImage = Util.GetImageFromScalablePictureBoxEmbeddedResource("QAlbum.showWhole.png");
            showActualSizeImage = Util.GetImageFromScalablePictureBoxEmbeddedResource("QAlbum.showActualSize.png");

            // read cursors
            zoomInCursor = Util.CreateCursorFromFile("QAlbum.ZoomIn32.cur");
            zoomOutCursor = Util.CreateCursorFromFile("QAlbum.ZoomOut32.cur");

            // set size mode of picture box to zoom mode
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Enable auto scroll of this control
            this.AutoScroll = true;
        }

        /// <summary>
        /// Get picture box control
        /// </summary>
        [Bindable(false)]
        public PictureBox PictureBox
        {
            get { return this.pictureBox; }
        }

        /// <summary>
        /// Need dispose image when new image is set
        /// </summary>
        [Bindable(true), DefaultValue(true)]
        public bool NeedDisposeImage
        {
            get { return this.needDisposeImage; }
            set { this.needDisposeImage = value; }
        }


        private Image backingImage;

		/// <summary>
		/// Image in picture box
		/// </summary>
        [Bindable(true)]
        public Image BackingImage
		{
            get { return backingImage; }
			set
			{
                if (backingImage != null && this.NeedDisposeImage)
                {
                    backingImage.Dispose();
                }
                backingImage = value;
                this.pictureBox.Image = backingImage;
                ScalePictureBoxToFit();
                RefreshContextMenuStrip();
            }
		}

        
        OverlayGenerator overlayGenerator = null;
        /// <summary>
        /// Set overlay generator for this image. Will be called whenever image is resized
        /// </summary>
        /// <param name="overlayGenerator"></param>
        public void SetOverlayGenerator(OverlayGenerator overlayGenerator) {
            this.overlayGenerator = overlayGenerator;
            this.pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
        }

        void pictureBox_Paint(object sender, PaintEventArgs e) {
            overlayGenerator.PaintOverlay(e);
        }

        public void OverlayChanged() {
            this.Invalidate();
        }
        

        /// <summary>
        /// Image size mode
        /// </summary>
        [Bindable(true), DefaultValue(PictureBoxSizeMode.Zoom)]
        public PictureBoxSizeMode ImageSizeMode
		{
            get { return this.pictureBoxSizeMode; }
			set
			{
                this.pictureBoxSizeMode = value;
                this.ScalePictureBoxToFit();
			}
		}

        /// <summary>
        /// Scale percentage for the picture box
        /// </summary>
        public float ScalePercent
        {
            get { return this.currentScalePercent; }
            set
            {
                this.currentScalePercent = value;
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// Scale picture box to fit to current control size and image size
        /// </summary>
		private void ScalePictureBoxToFit()
		{
            if (this.BackingImage == null)
            {
                this.pictureBox.Width = this.ClientSize.Width;
                this.pictureBox.Height = this.ClientSize.Height;
                this.pictureBox.Left = 0;
                this.pictureBox.Top = 0;
                this.internalLocation.X = 0;
                this.internalLocation.Y = 0;
                this.AutoScroll = false;
                this.currentScalePercent = GetMinScalePercent();
                this.pictureBoxSizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (this.pictureBoxSizeMode == PictureBoxSizeMode.Zoom ||
                    (this.BackingImage.Width <= this.ClientSize.Width && this.BackingImage.Height <= this.ClientSize.Height))
            {
                this.pictureBox.Width = Math.Min(this.ClientSize.Width, this.BackingImage.Width);
                this.pictureBox.Height = Math.Min(this.ClientSize.Height, this.BackingImage.Height);
                this.pictureBox.Top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
                this.pictureBox.Left = (this.ClientSize.Width - this.pictureBox.Width) / 2;
                this.AutoScroll = false;
                this.currentScalePercent = GetMinScalePercent();
                this.pictureBoxSizeMode = PictureBoxSizeMode.Zoom;

                float minScalePercent = Math.Min((float)this.ClientSize.Width / (float)this.BackingImage.Width,
                                                 (float)this.ClientSize.Height / (float)this.BackingImage.Height);
                this.internalLocation.X = (int)((this.ClientSize.Width - this.BackingImage.Width * minScalePercent) / 2);
                this.internalLocation.Y = (int)((this.ClientSize.Height - this.BackingImage.Height * minScalePercent) / 2);
            }
            else
            {
                this.pictureBox.Width = Math.Max((int) (this.BackingImage.Width * this.currentScalePercent), this.ClientSize.Width);
                this.pictureBox.Height = Math.Max((int) (this.BackingImage.Height * this.currentScalePercent), this.ClientSize.Height);

                // Centering picture box control
                int top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
                int left = (this.ClientSize.Width - this.pictureBox.Width) / 2;
                if (top < 0) {
                    top = this.AutoScrollPosition.Y;
                }
                if (left < 0) {
                    left = this.AutoScrollPosition.X;
                }
                this.pictureBox.Left = left;
                this.pictureBox.Top = top;
                this.AutoScroll = true;
            }

            // set cursor for picture box
            SetCursor4PictureBox();
            this.pictureBox.Invalidate();
        }



        /// <summary>
        /// Set cursor for the picture box
        ///     DefaultCursor:if need not scale picture,
        ///     ZoomOutCursor:if can zoom out picture,
        ///     ZoomInCursor:if can zoom in picture
        /// </summary>
        private void SetCursor4PictureBox()
        {
            if (this.BackingImage == null || this.ContextMenuStrip == null)
            {
                // returen default cursor
                this.pictureBox.Cursor = Cursors.Default;
            }
            else
            {
                if (this.pictureBoxSizeMode == PictureBoxSizeMode.Zoom)
                {
                    // return zoom in cursor if the picture is zoomed out
                    this.pictureBox.Cursor = zoomInCursor;
                }
                else
                {
                    // return zoom out cursor if the picture is zoomed in
                    this.pictureBox.Cursor = zoomOutCursor;
                }
            }
        }

        /// <summary>
        /// Resize picture box on resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnResize(object sender, System.EventArgs e)
		{
            ScalePictureBoxToFit();
            RefreshContextMenuStrip();
        }

        /// <summary>
        /// Scale current picture if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (this.BackingImage == null ||
                (this.BackingImage.Width <= this.ClientSize.Width && this.BackingImage.Height <= this.ClientSize.Height))
            {
                // do nothing if it is not needed to scale the picture
                return;
            }

            if (this.ImageSizeMode == PictureBoxSizeMode.Zoom)
            {
                this.ImageSizeMode = PictureBoxSizeMode.Normal;
                this.currentScalePercent = MAX_SCALE_PERCENT;
                this.lastSelectedMenuItemName = MAX_SCALE_PERCENT.ToString();
            }
            else
            {
                this.ImageSizeMode = PictureBoxSizeMode.Zoom;
                this.currentScalePercent = GetMinScalePercent();
                this.lastSelectedMenuItemName = SHOW_WHOLE_MENU_ITEM_NAME;
            }

            ScalePictureBoxToFit();

            // check last selected menu item
            CheckLastSelectedMenuItem();
        }

        /// <summary>
        /// Repaint picture box when its location changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_LocationChanged(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// Get minimum scale percent of current image
        /// </summary>
        /// <returns>minimum scale percent</returns>
        private float GetMinScalePercent()
        {
            if ((this.BackingImage == null) ||
                (this.BackingImage.Width <= this.ClientSize.Width) && (this.BackingImage.Height <= this.ClientSize.Height))
            {
                return MAX_SCALE_PERCENT;
            }

            float minScalePercent = Math.Min((float)this.ClientSize.Width / (float)this.BackingImage.Width,
                                             (float)this.ClientSize.Height / (float)this.BackingImage.Height);
            return minScalePercent;
        }

        /// <summary>
        /// Get fit width scale percent of current image
        /// </summary>
        /// <returns>fit width scale percent which is bigger than minimum scale percent</returns>
        private float GetFitWidthScalePercent()
        {
            if (this.BackingImage == null)
            {
                return MAX_SCALE_PERCENT;
            }

            float fitWidthScalePercent = Math.Min(this.ClientSize.Width / this.BackingImage.Width, 1);
            return Math.Max(fitWidthScalePercent, GetMinScalePercent());
        }

        /// <summary>
        /// Refresh context menu strip according to current image
        /// </summary>
        private void RefreshContextMenuStrip()
        {
            float minScalePercent = GetMinScalePercent();
            if (minScalePercent == MAX_SCALE_PERCENT)
            {
                // no need popup context menu
                this.ContextMenuStrip = null;
            }
            else
            {
                this.pictureBoxContextMenuStrip.SuspendLayout();
                this.pictureBoxContextMenuStrip.Items.Clear();

                // add show whole menu item
                ToolStripMenuItem showWholeScaleMenuItem = CreateToolStripMenuItem(minScalePercent);
                showWholeScaleMenuItem.Name = SHOW_WHOLE_MENU_ITEM_NAME;
                showWholeScaleMenuItem.Text = "Show whole(" + (minScalePercent*100) + "%)";
                showWholeScaleMenuItem.Image = this.showWholeImage;
                showWholeScaleMenuItem.Checked = this.pictureBoxSizeMode == PictureBoxSizeMode.Zoom;
                this.pictureBoxContextMenuStrip.Items.Add(showWholeScaleMenuItem);

                // add scale to fit width menu item
                float fitWidthScalePercent = GetFitWidthScalePercent();
                ToolStripMenuItem fitWidthScaleMenuItem = CreateToolStripMenuItem(fitWidthScalePercent);
                fitWidthScaleMenuItem.Name = FIT_WIDTH_MENU_ITEM_NAME;
                fitWidthScaleMenuItem.Text = "Fit width(" + (fitWidthScalePercent*100)+ "%)";
                fitWidthScaleMenuItem.Image = this.fitWidthImage;
                this.pictureBoxContextMenuStrip.Items.Add(fitWidthScaleMenuItem);

                // add other scale menu items
                for (int scale = ((int)minScalePercent * 100) / 10 * 10 + 10; scale <= MAX_SCALE_PERCENT*100; scale += 10)
                {
                    ToolStripMenuItem menuItem = CreateToolStripMenuItem(scale);
                    if (scale == 100)
                    {
                        menuItem.Image = this.showActualSizeImage;
                    }
                    this.pictureBoxContextMenuStrip.Items.Add(menuItem);
                }
                this.pictureBoxContextMenuStrip.ResumeLayout();
                this.ContextMenuStrip = this.pictureBoxContextMenuStrip;

                // check last selected menu item
                CheckLastSelectedMenuItem();
            }
            SetCursor4PictureBox();
        }

        /// <summary>
        /// Create a tool strip menu item with given scale percent
        /// </summary>
        /// <param name="scalePercent">the percentage to scale picture</param>
        /// <returns>a tool strip menu item</returns>
        private ToolStripMenuItem CreateToolStripMenuItem(float scalePercent)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = scalePercent.ToString();
            toolStripMenuItem.Text = scalePercent.ToString() + "%";
            toolStripMenuItem.Tag = scalePercent;
            toolStripMenuItem.Click += new EventHandler(toolStripMenuItem_Click);
            return toolStripMenuItem;
        }

        /// <summary>
        /// check last selected menu item
        /// </summary>
        private void CheckLastSelectedMenuItem()
        {
            // check the selected menu item
            foreach (ToolStripMenuItem menuItem in this.pictureBoxContextMenuStrip.Items)
            {
                menuItem.Checked = this.lastSelectedMenuItemName == menuItem.Name;
            }
        }

        /// <summary>
        /// Scale the picture box size with the scale percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedMenuItem = sender as ToolStripMenuItem;
            this.currentScalePercent = (float)selectedMenuItem.Tag / 100;
            ImageSizeMode = selectedMenuItem.Name == SHOW_WHOLE_MENU_ITEM_NAME ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;

            // Adjust picture box size again for fit picture box width to the scalable control width
            // because the client size may be changed.
            float currentFitWidthScalePercent = GetFitWidthScalePercent();
            if (selectedMenuItem.Name == FIT_WIDTH_MENU_ITEM_NAME && currentFitWidthScalePercent != this.currentScalePercent)
            {
                this.currentScalePercent = GetFitWidthScalePercent();
                ImageSizeMode = selectedMenuItem.Name == SHOW_WHOLE_MENU_ITEM_NAME ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
            }

            this.lastSelectedMenuItemName = selectedMenuItem.Name;

            // check last selected menu item
            CheckLastSelectedMenuItem();
        }

    }

    
    public interface OverlayGenerator {
        void PaintOverlay(PaintEventArgs e);
    }


}
