using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Palazzo
{
	public enum PalaceSelectionModeEnum { NoSelection, SelectPalace, SelectTile };

	/// <summary>
	/// Summary description for PalacePool.
	/// </summary>
	public class PalacePool : System.Windows.Forms.Panel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private const int INSET = 2;

		private ArrayList _palaces;
		private int _tileWidth = 100;
		private int _tileHeight = 40;
		private int _gap = 3;
		private PalaceSelectionModeEnum _selectionMode = PalaceSelectionModeEnum.NoSelection;

		public event EventHandler SelectionChanged;
		
		public PalacePool()
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

		public ArrayList ThePalaces
		{
			get
			{
				return _palaces;
			}
			set
			{
				_palaces = value;
				RebuildChildren();
				this.Invalidate();
			}
		}

		public PalaceSelectionModeEnum SelectionMode
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

		public Palace GetSelectedPalace()
		{
			if (this.SelectionMode != PalaceSelectionModeEnum.SelectPalace)
				throw new ApplicationException("Can't GetSelectedPalace() if SelectionMode != PalaceSelectionModeEnum.SelectPalace.");
			
			foreach (Control c in Controls)
			{
				TilePool tp = (TilePool) c;
				if (tp.Selected)
					return FindPalaceForTiles(tp.TheTiles);
			}

			return null;
		}

		/*public Palace[] GetSelectedPalaces()
		{
			ArrayList palaces = new ArrayList();
			foreach (Control c in Controls)
			{
				TilePool tp = (TilePool) c;
				if (tp.Selected)
					palaces.Add(FindPalaceForTiles(tp.TheTiles));
			}
			return (Palace[]) palaces.ToArray(typeof(Palace));
		}*/

		private Palace FindPalaceForTiles(ArrayList tiles)
		{
			foreach (Palace p in ThePalaces)
				if (p.Tiles == tiles)
					return p;
			return null;
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
		
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint (pevent);
		}

		private void RebuildChildren()
		{
			this.Controls.Clear();
			if (this.ThePalaces != null)
			{
				int i = 0;
				foreach (Palace p in this.ThePalaces)
				{
					TilePool tp = new TilePool();
					tp.TheTiles = p.Tiles;
					if (this.SelectionMode == PalaceSelectionModeEnum.NoSelection)
						tp.SelectionMode = TileSelectionModeEnum.NoSelection;
					else if (this.SelectionMode == PalaceSelectionModeEnum.SelectPalace)
						tp.SelectionMode = TileSelectionModeEnum.SelectAll;
					else if (this.SelectionMode == PalaceSelectionModeEnum.SelectTile)
						tp.SelectionMode = TileSelectionModeEnum.SelectSingle;
					tp.Enabled = this.Enabled;
					tp.Gap = 0;
					tp.Left = (i * this.TileWidth) + (i * this.Gap) + INSET * 2;
					tp.Top = this.Height - this.TileHeight * 5 - this.Gap * 4;
					tp.Width = this.TileWidth + INSET * 2;
					tp.Height = this.TileHeight * 5 + this.Gap * 4;
					tp.Click += new EventHandler(tp_Click);
					tp.TileWidth = this.TileWidth;
					tp.TileHeight = this.TileHeight;
					this.Controls.Add(tp);
					
					i++;
				}
			}
		}

		private void tp_Click(object sender, EventArgs e)
		{
			TilePool tp = (TilePool) sender;
			if (tp.Selected && this.SelectionMode == PalaceSelectionModeEnum.SelectPalace)
			{
				foreach (Control c in this.Controls)
				{
					if (sender != c)
					{
						TilePool thisTp = (TilePool) c;
						if (thisTp.Selected)
							thisTp.Selected = false;
					}
				}
			}
			else if (tp.Selected && this.SelectionMode	== PalaceSelectionModeEnum.SelectTile)
			{
				// go through all other palaces and deselect everything.
				foreach (Control c in this.Controls)
				{
					if (sender != c)
					{
						TilePool thisTp = (TilePool) c;
						thisTp.DeselectAll();
					}
				}
			}

			SelectionChanged(sender,new EventArgs());
		}
	}
}
