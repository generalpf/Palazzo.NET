using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for TileControl.
	/// </summary>
	public class TileControl : System.Windows.Forms.Button
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private const int INSET = 2;

		private Tile _tile;
		private bool _selectable;
		private bool _selected;
		protected Image _tileImage, _sizedImage;
		
		public TileControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			SetStyle(ControlStyles.ResizeRedraw,true);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		public Tile TheTile
		{
			get
			{
				return _tile;
			}
			set
			{
				_tile = value;
				if (_tile == null)
					_tileImage = _sizedImage = null;
				else if (!_tile.Image.Equals(""))
				{
					_tileImage = Image.FromFile(_tile.Image);
					BuildSizedImage();
				}
				this.Invalidate();
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				this.Invalidate();
			}
		}

		public bool Selectable
		{
			get
			{
				return _selectable;
			}
			set
			{
				_selectable = value;
				this.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			pevent.Graphics.FillRegion(new SolidBrush(this.BackColor),new Region(new Rectangle(0,0,this.Width,this.Height)));
			if (_sizedImage != null)
			{
				if (this.Enabled)
					pevent.Graphics.DrawImage(_sizedImage,0,0,this.Width,this.Height);
				else
					ControlPaint.DrawImageDisabled(pevent.Graphics,_sizedImage,0,0,this.BackColor);
			}
			if (_selected)
				pevent.Graphics.DrawRectangle(new Pen(Color.Black,INSET),1,1,this.Width - INSET,this.Height - INSET);
		
			//base.OnPaint (pevent);
		}
	
		protected override void OnClick(EventArgs e)
		{
			if (_selectable)
			{
				_selected = !_selected;
				this.Invalidate();
			}
			base.OnClick (e);
		}
	
		protected override void OnSizeChanged(EventArgs e)
		{
			if (_tileImage != null)
				BuildSizedImage();

			base.OnSizeChanged (e);
		}

		private void BuildSizedImage()
		{
			Image.GetThumbnailImageAbort gtia = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
			_sizedImage = _tileImage.GetThumbnailImage(this.Width,this.Height,gtia,IntPtr.Zero);
		}

		private bool ThumbnailCallback()
		{
			return false;
		}
	}
}
