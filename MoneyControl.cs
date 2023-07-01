using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for MoneyControl.
	/// </summary>
	public class MoneyControl : System.Windows.Forms.Button
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Money _money;
		private bool _selectable;
		private bool _selected;
		protected Image _moneyImage, _sizedImage;
		
		public MoneyControl()
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

		public Money TheMoney
		{
			get
			{
				return _money;
			}
			set
			{
				_money = value;
				if (_money == null)
					_moneyImage = _sizedImage = null;
				else if (!_money.Image.Equals(""))
				{
					_moneyImage = Image.FromFile(_money.Image);
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
				pevent.Graphics.DrawRectangle(new Pen(Color.Black,2),1,1,this.Width - 2,this.Height - 2);
		
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
			if (_moneyImage != null)
				BuildSizedImage();

			base.OnSizeChanged (e);
		}

		private void BuildSizedImage()
		{
			Image.GetThumbnailImageAbort gtia = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
			_sizedImage = _moneyImage.GetThumbnailImage(this.Width,this.Height,gtia,IntPtr.Zero);
		}

		private bool ThumbnailCallback()
		{
			return false;
		}
	}
}
