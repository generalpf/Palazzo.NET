using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for BuyTilesForm.
	/// </summary>
	public class BuyTilesForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblCost;
		private System.Windows.Forms.Label lblPaid;
		private System.Windows.Forms.Button cmdOK;
		
		private Tile[] _selectedTiles;
		private Palazzo.TilePool tilePool1;
		private Palazzo.MoneyPool moneyPool1;
		private Money[] _selectedMoney;

		public BuyTilesForm(ArrayList materialSupply, ArrayList hand, string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tilePool1.TheTiles = materialSupply;
			moneyPool1.TheMoney = hand;
			
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
			this.cmdOK = new System.Windows.Forms.Button();
			this.lblCost = new System.Windows.Forms.Label();
			this.lblPaid = new System.Windows.Forms.Label();
			this.tilePool1 = new Palazzo.TilePool();
			this.moneyPool1 = new Palazzo.MoneyPool();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(288, 312);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// lblCost
			// 
			this.lblCost.Location = new System.Drawing.Point(8, 288);
			this.lblCost.Name = "lblCost";
			this.lblCost.TabIndex = 3;
			this.lblCost.Text = "Cost: 0";
			// 
			// lblPaid
			// 
			this.lblPaid.Location = new System.Drawing.Point(8, 312);
			this.lblPaid.Name = "lblPaid";
			this.lblPaid.TabIndex = 4;
			this.lblPaid.Text = "Paid: 0";
			// 
			// tilePool1
			// 
			this.tilePool1.Columns = 3;
			this.tilePool1.Gap = 3;
			this.tilePool1.Location = new System.Drawing.Point(8, 8);
			this.tilePool1.Name = "tilePool1";
			this.tilePool1.Rows = 2;
			this.tilePool1.Selected = false;
			this.tilePool1.SelectionMode = Palazzo.TileSelectionModeEnum.SelectMultiple;
			this.tilePool1.Size = new System.Drawing.Size(552, 100);
			this.tilePool1.TabIndex = 5;
			this.tilePool1.TheTiles = null;
			this.tilePool1.TileHeight = 40;
			this.tilePool1.TileWidth = 100;
			this.tilePool1.SelectionChanged += new System.EventHandler(this.tilePool1_SelectionChanged);
			// 
			// moneyPool1
			// 
			this.moneyPool1.CardHeight = 100;
			this.moneyPool1.CardWidth = 50;
			this.moneyPool1.Columns = 8;
			this.moneyPool1.DisabledMoney = null;
			this.moneyPool1.Gap = 3;
			this.moneyPool1.Location = new System.Drawing.Point(8, 120);
			this.moneyPool1.Name = "moneyPool1";
			this.moneyPool1.Rows = 2;
			this.moneyPool1.SelectionMode = Palazzo.MoneySelectionModeEnum.SelectMultiple;
			this.moneyPool1.Size = new System.Drawing.Size(552, 160);
			this.moneyPool1.TabIndex = 6;
			this.moneyPool1.TheMoney = null;
			this.moneyPool1.SelectionChanged += new System.EventHandler(this.moneyPool1_SelectionChanged);
			// 
			// BuyTilesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 341);
			this.ControlBox = false;
			this.Controls.Add(this.moneyPool1);
			this.Controls.Add(this.tilePool1);
			this.Controls.Add(this.lblPaid);
			this.Controls.Add(this.lblCost);
			this.Controls.Add(this.cmdOK);
			this.Name = "BuyTilesForm";
			this.Text = "Buy From Material Supply";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			Money[] selMoney = moneyPool1.GetSelectedMoneyCards();
			_selectedMoney = new Money[selMoney.Length];
			selMoney.CopyTo(_selectedMoney,0);

			Tile[] selTiles = tilePool1.GetSelectedTiles();
			_selectedTiles = new Tile[selTiles.Length];
			selTiles.CopyTo(_selectedTiles,0);

			this.Close();
		}

		private int CalculatePayment()
		{
			return CurrencyHelper.CurrencyValue(moneyPool1.GetSelectedMoneyCards());
		}

		private void tilePool1_SelectionChanged(object sender, System.EventArgs e)
		{
			SetOK();
		}

		private void moneyPool1_SelectionChanged(object sender, System.EventArgs e)
		{
			SetOK();
		}

		private void SetOK()
		{
			int total = CalculatePayment();
			lblPaid.Text = (total == -1 ? "Invalid payment." : "Paid: " + total);

			int howMany = tilePool1.GetSelectedTiles().Length;
			int cost = (10 - tilePool1.TheTiles.Count) * howMany;
			lblCost.Text = "Cost: " + cost.ToString();

			cmdOK.Enabled = (howMany == 1 || howMany == 2) && (total >= cost);
		}

		public Money[] SelectedMoney
		{
			get
			{
				return _selectedMoney;
			}
		}

		public Tile[] SelectedTiles
		{
			get
			{
				return _selectedTiles;
			}
		}
	}
}
