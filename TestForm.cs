using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Threading;

namespace Palazzo
{
	/// <summary>
	/// Summary description for TestForm.
	/// </summary>
	public class TestForm : System.Windows.Forms.Form
	{
		private Palazzo.MoneyPool moneyPool1;
		private Palazzo.TilePool tilePool1;
		private Palazzo.PalacePool palacePool1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.moneyPool1 = new Palazzo.MoneyPool();
			this.tilePool1 = new Palazzo.TilePool();
			this.palacePool1 = new Palazzo.PalacePool();
			this.SuspendLayout();
			// 
			// moneyPool1
			// 
			this.moneyPool1.CardHeight = 100;
			this.moneyPool1.CardWidth = 65;
			this.moneyPool1.Columns = 10;
			this.moneyPool1.Gap = 5;
			this.moneyPool1.Location = new System.Drawing.Point(32, 8);
			this.moneyPool1.Name = "moneyPool1";
			this.moneyPool1.Rows = 2;
			this.moneyPool1.Selectable = true;
			this.moneyPool1.SingleSelection = true;
			this.moneyPool1.Size = new System.Drawing.Size(320, 216);
			this.moneyPool1.TabIndex = 2;
			this.moneyPool1.TheMoney = null;
			// 
			// tilePool1
			// 
			this.tilePool1.Columns = 4;
			this.tilePool1.Gap = 5;
			this.tilePool1.Location = new System.Drawing.Point(32, 240);
			this.tilePool1.Name = "tilePool1";
			this.tilePool1.Rows = 2;
			this.tilePool1.Selected = false;
			this.tilePool1.SelectTiles = true;
			this.tilePool1.SingleSelection = true;
			this.tilePool1.Size = new System.Drawing.Size(320, 100);
			this.tilePool1.TabIndex = 3;
			this.tilePool1.TheTiles = null;
			this.tilePool1.TileHeight = 40;
			this.tilePool1.TileWidth = 100;
			// 
			// palacePool1
			// 
			this.palacePool1.Gap = 3;
			this.palacePool1.Location = new System.Drawing.Point(360, 8);
			this.palacePool1.Name = "palacePool1";
			this.palacePool1.Selectable = true;
			this.palacePool1.SingleSelection = true;
			this.palacePool1.Size = new System.Drawing.Size(360, 192);
			this.palacePool1.TabIndex = 4;
			this.palacePool1.ThePalaces = null;
			this.palacePool1.TileHeight = 40;
			this.palacePool1.TileWidth = 100;
			// 
			// TestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 373);
			this.Controls.Add(this.palacePool1);
			this.Controls.Add(this.tilePool1);
			this.Controls.Add(this.moneyPool1);
			this.Name = "TestForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Test Form";
			this.Load += new System.EventHandler(this.TestForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TestForm());
		}

		private void TestForm_Load(object sender, System.EventArgs e)
		{
			/*Tile t = new Tile(3,MaterialEnum.Sandstone,5,2,"images/III.sandstone.5.2.jpg");
			tileControl1.TheTile = t;

			Money m = new Money(CurrencyEnum.Red,5,"images/red.5.jpg");
			moneyControl1.TheMoney = m;*/

			ArrayList monies = new ArrayList();
			monies.Add(new Money(CurrencyEnum.Red,5,"images/red.5.jpg"));
			monies.Add(new Money(CurrencyEnum.Red,3,"images/red.3.jpg"));
			monies.Add(new Money(CurrencyEnum.White,5,"images/white.5.jpg"));
			monies.Add(new Money(CurrencyEnum.Red,5,"images/red.5.jpg"));
			monies.Add(new Money(CurrencyEnum.Red,3,"images/red.3.jpg"));
			monies.Add(new Money(CurrencyEnum.White,5,"images/white.5.jpg"));
			monies.Add(new Money(CurrencyEnum.Red,5,"images/red.5.jpg"));
			monies.Add(new Money(CurrencyEnum.Red,3,"images/red.3.jpg"));
			monies.Add(new Money(CurrencyEnum.White,5,"images/white.5.jpg"));
			moneyPool1.TheMoney = monies;

			ArrayList tiles = new ArrayList();
			tiles.Add(new Tile(3,MaterialEnum.Sandstone,5,2,"images/III.sandstone.5.2.jpg"));
			tiles.Add(new Tile(3,MaterialEnum.Brick,5,2,"images/III.brick.5.2.jpg"));
			tiles.Add(new Tile(3,MaterialEnum.Marble,5,2,"images/III.marble.5.2.jpg"));
			tilePool1.TheTiles = tiles;

			ArrayList palaces = new ArrayList();
			Palace p = new Palace();
			p.AddTile(new Tile(1,MaterialEnum.Sandstone,1,3,"images/I.sandstone.1.3.jpg"));
			p.AddTile(new Tile(1,MaterialEnum.Sandstone,2,3,"images/I.sandstone.2.3.jpg"));
			p.AddTile(new Tile(1,MaterialEnum.Marble,3,2,"images/I.marble.3.2.jpg"));
			palaces.Add(p);
			p = new Palace();
			p.AddTile(new Tile(1,MaterialEnum.Brick,1,3,"images/I.brick.1.3.jpg"));
			p.AddTile(new Tile(1,MaterialEnum.Marble,2,3,"images/I.marble.2.3.jpg"));
			p.AddTile(new Tile(1,MaterialEnum.Marble,3,2,"images/I.marble.3.2.jpg"));
			palaces.Add(p);
			palacePool1.ThePalaces = palaces;
		}

		private void tileControl1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(((Button) sender).Name);
		}
	}
}
