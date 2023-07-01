using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for TakeMoneyForm.
	/// </summary>
	public class TakeMoneyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private int _howMany;
		private Palazzo.MoneyPool moneyPool1;
		private Money[] _selectedMoney;

		public TakeMoneyForm(ArrayList moneyCards, int howMany, string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			moneyPool1.TheMoney = moneyCards;
			moneyPool1.SelectionMode = (howMany == 1 ? MoneySelectionModeEnum.SelectSingle : MoneySelectionModeEnum.SelectMultiple);
			_howMany = howMany;
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
			this.moneyPool1 = new Palazzo.MoneyPool();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(168, 128);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// moneyPool1
			// 
			this.moneyPool1.CardHeight = 100;
			this.moneyPool1.CardWidth = 65;
			this.moneyPool1.Columns = 10;
			this.moneyPool1.Gap = 3;
			this.moneyPool1.Location = new System.Drawing.Point(8, 8);
			this.moneyPool1.Name = "moneyPool1";
			this.moneyPool1.Rows = 1;
			this.moneyPool1.SelectionMode = Palazzo.MoneySelectionModeEnum.SelectSingle;
			this.moneyPool1.Size = new System.Drawing.Size(392, 112);
			this.moneyPool1.TabIndex = 2;
			this.moneyPool1.TheMoney = null;
			this.moneyPool1.SelectionChanged += new System.EventHandler(this.moneyPool1_SelectionChanged);
			// 
			// TakeMoneyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 159);
			this.ControlBox = false;
			this.Controls.Add(this.moneyPool1);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "TakeMoneyForm";
			this.Text = "Take Money";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			_selectedMoney = new Money[_howMany];
			moneyPool1.GetSelectedMoneyCards().CopyTo(_selectedMoney,0);

			this.Close();
		}

		private void moneyPool1_SelectionChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = (moneyPool1.GetSelectedMoneyCards().Length == _howMany);
		}

		public Money[] SelectedMoney
		{
			get
			{
				return _selectedMoney;
			}
		}
	}
}
