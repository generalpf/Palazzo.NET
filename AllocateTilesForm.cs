using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for AllocateTilesForm.
	/// </summary>
	public class AllocateTilesForm : System.Windows.Forms.Form
	{
		private Palazzo.TilePool tilePool1;
		private Palazzo.PalacePool palacePool1;
		private System.Windows.Forms.Button cmdNewPalace;
		private System.Windows.Forms.Button cmdStack;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button cmdFinished;

		protected HumanPlayer _hp;

		public AllocateTilesForm(HumanPlayer hp, Tile[] tiles, string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tilePool1.TheTiles = new ArrayList(tiles);
			palacePool1.ThePalaces = hp.Palaces;
			_hp = hp;

			this.Text = title;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tilePool1 = new Palazzo.TilePool();
			this.palacePool1 = new Palazzo.PalacePool();
			this.cmdNewPalace = new System.Windows.Forms.Button();
			this.cmdStack = new System.Windows.Forms.Button();
			this.cmdFinished = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tilePool1
			// 
			this.tilePool1.Columns = 2;
			this.tilePool1.Gap = 3;
			this.tilePool1.Location = new System.Drawing.Point(8, 8);
			this.tilePool1.Name = "tilePool1";
			this.tilePool1.Rows = 5;
			this.tilePool1.Selected = false;
			this.tilePool1.SelectionMode = Palazzo.TileSelectionModeEnum.SelectSingle;
			this.tilePool1.Size = new System.Drawing.Size(448, 128);
			this.tilePool1.TabIndex = 0;
			this.tilePool1.TheTiles = null;
			this.tilePool1.TileHeight = 40;
			this.tilePool1.TileWidth = 100;
			this.tilePool1.SelectionChanged += new System.EventHandler(this.tilePool1_SelectionChanged);
			// 
			// palacePool1
			// 
			this.palacePool1.Gap = 3;
			this.palacePool1.Location = new System.Drawing.Point(8, 176);
			this.palacePool1.Name = "palacePool1";
			this.palacePool1.SelectionMode = Palazzo.PalaceSelectionModeEnum.SelectPalace;
			this.palacePool1.Size = new System.Drawing.Size(448, 168);
			this.palacePool1.TabIndex = 1;
			this.palacePool1.ThePalaces = null;
			this.palacePool1.TileHeight = 40;
			this.palacePool1.TileWidth = 100;
			this.palacePool1.SelectionChanged += new System.EventHandler(this.palacePool1_SelectionChanged);
			// 
			// cmdNewPalace
			// 
			this.cmdNewPalace.Enabled = false;
			this.cmdNewPalace.Location = new System.Drawing.Point(8, 144);
			this.cmdNewPalace.Name = "cmdNewPalace";
			this.cmdNewPalace.Size = new System.Drawing.Size(88, 23);
			this.cmdNewPalace.TabIndex = 2;
			this.cmdNewPalace.Text = "&New Palace";
			this.cmdNewPalace.Click += new System.EventHandler(this.cmdNewPalace_Click);
			// 
			// cmdStack
			// 
			this.cmdStack.Enabled = false;
			this.cmdStack.Location = new System.Drawing.Point(104, 144);
			this.cmdStack.Name = "cmdStack";
			this.cmdStack.Size = new System.Drawing.Size(112, 23);
			this.cmdStack.TabIndex = 3;
			this.cmdStack.Text = "&Stack on Palace";
			this.cmdStack.Click += new System.EventHandler(this.cmdStack_Click);
			// 
			// cmdFinished
			// 
			this.cmdFinished.Enabled = false;
			this.cmdFinished.Location = new System.Drawing.Point(384, 144);
			this.cmdFinished.Name = "cmdFinished";
			this.cmdFinished.TabIndex = 4;
			this.cmdFinished.Text = "&Finished";
			this.cmdFinished.Click += new System.EventHandler(this.cmdFinished_Click);
			// 
			// AllocateTilesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 349);
			this.ControlBox = false;
			this.Controls.Add(this.cmdFinished);
			this.Controls.Add(this.cmdStack);
			this.Controls.Add(this.cmdNewPalace);
			this.Controls.Add(this.palacePool1);
			this.Controls.Add(this.tilePool1);
			this.Name = "AllocateTilesForm";
			this.Text = "AllocateTilesForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdNewPalace_Click(object sender, System.EventArgs e)
		{
			Tile t = tilePool1.GetSelectedTile();
			Palace p = new Palace();
			p.AddTile(t);
			_hp.Palaces.Add(p);
			tilePool1.TheTiles.Remove(t);

			// will force a refresh.
			tilePool1.TheTiles = tilePool1.TheTiles;
			palacePool1.ThePalaces = _hp.Palaces;

			SetButtons();
		}

		private void tilePool1_SelectionChanged(object sender, System.EventArgs e)
		{
			SetButtons();
		}

		private void palacePool1_SelectionChanged(object sender, System.EventArgs e)
		{
			SetButtons();
		}

		private void SetButtons()
		{
			if (tilePool1.GetSelectedTile() == null)
				cmdNewPalace.Enabled = cmdStack.Enabled = false;
			else if (palacePool1.GetSelectedPalace() == null)
			{
				cmdNewPalace.Enabled = true;
				cmdStack.Enabled = false;
			}
			else if (palacePool1.GetSelectedPalace().CanAddTile(tilePool1.GetSelectedTile()))
			{
				cmdNewPalace.Enabled = false;
				cmdStack.Enabled = true;
			}
			else
			{
				cmdNewPalace.Enabled = cmdStack.Enabled = false;
			}

			cmdFinished.Enabled = (tilePool1.TheTiles.Count == 0);
		}

		private void cmdStack_Click(object sender, System.EventArgs e)
		{
			Palace p = palacePool1.GetSelectedPalace();
			Tile t = tilePool1.GetSelectedTile();
			p.AddTile(t);
			tilePool1.TheTiles.Remove(t);

			// will force a refresh.
			tilePool1.TheTiles = tilePool1.TheTiles;
			palacePool1.ThePalaces = _hp.Palaces;

			SetButtons();
		}

		private void cmdFinished_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
