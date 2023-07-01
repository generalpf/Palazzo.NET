using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Palazzo
{
	public enum MoneySelectionModeEnum { NoSelection, SelectSingle, SelectMultiple };
	
	/// <summary>
	/// Summary description for MoneyPool.
	/// </summary>
	
	public class MoneyPool : System.Windows.Forms.Panel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ArrayList _money;
		private ArrayList _disabledMoney;
		private int _cardWidth = 50;
		private int _cardHeight = 100;
		private int _gap = 3;
		private int _rows = 1;
		private int _columns = 10;
		private MoneySelectionModeEnum _selectionMode = MoneySelectionModeEnum.NoSelection;

		public event EventHandler SelectionChanged;
		
		public MoneyPool()
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

		public ArrayList TheMoney
		{
			get
			{
				return _money;
			}
			set
			{
				_money = value;
				RebuildChildren();
				this.Invalidate();
			}
		}

		public ArrayList DisabledMoney
		{
			get
			{
				return _disabledMoney;
			}
			set
			{
				_disabledMoney = value;
				RebuildChildren();
				this.Invalidate();
			}
		}

		public MoneySelectionModeEnum SelectionMode
		{
			get
			{
				return _selectionMode;
			}
			set
			{
				_selectionMode = value;
				this.Invalidate();
			}
		}

		public int Gap
		{
			get
			{
				return _gap;
			}
			set
			{
				_gap = value;
				RebuildChildren();
				Invalidate();
			}
		}

		public int CardWidth
		{
			get
			{
				return _cardWidth;
			}
			set
			{
				_cardWidth = value;
				RebuildChildren();
				Invalidate();
			}
		}

		public int CardHeight
		{
			get
			{
				return _cardHeight;
			}
			set
			{
				_cardHeight = value;
				RebuildChildren();
				Invalidate();
			}
		}

		public int Rows
		{
			get
			{
				return _rows;
			}
			set
			{
				_rows = value;
			}
		}

		public int Columns
		{
			get
			{
				return _columns;
			}
			set
			{
				_columns = value;
			}
		}
	
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint (pevent);
		}

		private void RebuildChildren()
		{
			this.Controls.Clear();
			if (_money != null)
			{
				int i = 0;
				foreach (Money m in _money)
				{
					int row = i % _rows;
					int col = i / _rows;

					MoneyControl mc = new MoneyControl();
					mc.TheMoney = m;
					mc.Selectable = (this.SelectionMode != MoneySelectionModeEnum.NoSelection);
					mc.Enabled = this.Enabled;
					mc.Left = (col * _cardWidth) + (col * _gap);
					mc.Top = this.Height - ((row + 1) * _cardHeight) - (row * _gap);
					mc.Width = _cardWidth;
					mc.Height = _cardHeight;
					mc.Click += new EventHandler(mc_Click);
					if (this.DisabledMoney != null && this.DisabledMoney.Contains(m))
						mc.Enabled = false;
					this.Controls.Add(mc);
					
					i++;
				}
			}
		}

		private void mc_Click(object sender, EventArgs e)
		{
			MoneyControl mc = (MoneyControl) sender;
			if (mc.Selected && this.SelectionMode == MoneySelectionModeEnum.SelectSingle)
			{
				foreach (Control c in this.Controls)
				{
					if (sender != c)
					{
						MoneyControl thisMc = (MoneyControl) c;
						if (thisMc.Selected)
							thisMc.Selected = false;
					}
				}
			}

			SelectionChanged(sender,new EventArgs());
		}

		public Money GetSelectedMoneyCard()
		{
			foreach (Control c in Controls)
			{
				MoneyControl mc = (MoneyControl) c;
				if (mc.Selected)
					return mc.TheMoney;
			}
			return null;
		}

		public Money[] GetSelectedMoneyCards()
		{
			ArrayList money = new ArrayList();
			foreach (Control c in Controls)
			{
				MoneyControl mc = (MoneyControl) c;
				if (mc.Selected)
					money.Add(mc.TheMoney);
			}
			return (Money[]) money.ToArray(typeof(Money));
		}
	}
}
