using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Palazzo
{
	public enum TileSelectionModeEnum { NoSelection, SelectSingle, SelectMultiple, SelectAll };

	/// <summary>
	/// Summary description for TilePool.
	/// </summary>
	public class TilePool : System.Windows.Forms.Panel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private const int INSET = 2;

		private ArrayList _tiles;
		private int _tileWidth = 100;
		private int _tileHeight = 40;
		private int _gap = 3;
		private bool _selected = false;
		private int _rows = 5;
		private int _columns = 2;
		private TileSelectionModeEnum _selectionMode = TileSelectionModeEnum.NoSelection;

		public event EventHandler SelectionChanged;

		public TilePool()
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

		public ArrayList TheTiles
		{
			get
			{
				return _tiles;
			}
			set
			{
				_tiles = value;
				RebuildChildren();
				this.Invalidate();
			}
		}

		public TileSelectionModeEnum SelectionMode
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

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				//RebuildChildren();
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

		public int TileWidth
		{
			get
			{
				return _tileWidth;
			}
			set
			{
				_tileWidth = value;
				RebuildChildren();
				Invalidate();
			}
		}

		public int TileHeight
		{
			get
			{
				return _tileHeight;
			}
			set
			{
				_tileHeight = value;
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

			if (this.Selected && this.SelectionMode == TileSelectionModeEnum.SelectAll)
				pevent.Graphics.DrawRectangle(new Pen(Color.Black,INSET),1,1,this.Width - INSET,this.Height - INSET);
		}

		private void RebuildChildren()
		{
			this.Controls.Clear();
			if (TheTiles != null)
			{
				int i = 0;
				foreach (Tile t in TheTiles)
				{
					int row = i % _rows;
					int col = i / _rows;

					TileControl tc = new TileControl();
					tc.TheTile = t;
					tc.Selectable = (this.SelectionMode != TileSelectionModeEnum.NoSelection);
					tc.Enabled = this.Enabled;
					tc.Left = (col * this.TileWidth) + (col * this.Gap) + INSET;
					tc.Top = this.Height - ((row + 1) * TileHeight) - (row * this.Gap) - INSET;
					tc.Width = this.TileWidth;
					tc.Height = this.TileHeight;
					tc.Click += new EventHandler(tc_Click);
					this.Controls.Add(tc);
					
					i++;
				}
			}
		}

		private void tc_Click(object sender, EventArgs e)
		{
			TileControl tc = (TileControl) sender;
			if (tc.Selected && this.SelectionMode == TileSelectionModeEnum.SelectSingle)
			{
				foreach (Control c in this.Controls)
				{
					if (sender != c)
					{
						TileControl thisTc = (TileControl) c;
						if (thisTc.Selected)
							thisTc.Selected = false;
					}
				}
			}
			else if (this.SelectionMode == TileSelectionModeEnum.SelectAll)
			{
				this.Selected = !this.Selected;
				// the TileControl should not be itself selected.
				tc.Selected = false;
			}
			
			if (SelectionChanged != null)
				SelectionChanged(sender,new EventArgs());
			
			base.OnClick(e);
		}

		public Tile GetSelectedTile()
		{
			foreach (Control c in Controls)
			{
				TileControl tc = (TileControl) c;
				if (tc.Selected)
					return tc.TheTile;
			}
			return null;
		}

		public Tile[] GetSelectedTiles()
		{
			ArrayList tiles = new ArrayList();
			foreach (Control c in Controls)
			{
				TileControl tc = (TileControl) c;
				if (tc.Selected)
					tiles.Add(tc.TheTile);
			}
			return (Tile[]) tiles.ToArray(typeof(Tile));
		}

		public void DeselectAll()
		{
			foreach (Control c in Controls)
			{
				TileControl tc = (TileControl) c;
				if (tc.Selected)
					tc.Selected = false;
			}
		}
	}
}
