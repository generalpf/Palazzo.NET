using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for AddToBidForm.
	/// </summary>
	public class AddToBidForm : System.Windows.Forms.Form
	{
		private Palazzo.MoneyPool mpBidSoFar;
		private Palazzo.MoneyPool mpHand;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdDropOut;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int _bidToBeat;
		private Money[] _selectedMoney;
		private bool _hasCertificato;

		public AddToBidForm(ArrayList bidSoFar, ArrayList hand, int bidToBeat, bool hasCertificato, string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			mpBidSoFar.TheMoney = bidSoFar;
			mpHand.TheMoney = hand;
			_bidToBeat = bidToBeat;
			mpHand.DisabledMoney = bidSoFar;
			_hasCertificato = hasCertificato;

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
			this.mpBidSoFar = new Palazzo.MoneyPool();
			this.mpHand = new Palazzo.MoneyPool();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDropOut = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mpBidSoFar
			// 
			this.mpBidSoFar.CardHeight = 100;
			this.mpBidSoFar.CardWidth = 65;
			this.mpBidSoFar.Columns = 10;
			this.mpBidSoFar.Gap = 3;
			this.mpBidSoFar.Location = new System.Drawing.Point(8, 8);
			this.mpBidSoFar.Name = "mpBidSoFar";
			this.mpBidSoFar.Rows = 1;
			this.mpBidSoFar.SelectionMode = Palazzo.MoneySelectionModeEnum.NoSelection;
			this.mpBidSoFar.Size = new System.Drawing.Size(560, 120);
			this.mpBidSoFar.TabIndex = 0;
			this.mpBidSoFar.TheMoney = null;
			// 
			// mpHand
			// 
			this.mpHand.CardHeight = 100;
			this.mpHand.CardWidth = 65;
			this.mpHand.Columns = 10;
			this.mpHand.Gap = 3;
			this.mpHand.Location = new System.Drawing.Point(8, 136);
			this.mpHand.Name = "mpHand";
			this.mpHand.Rows = 1;
			this.mpHand.SelectionMode = Palazzo.MoneySelectionModeEnum.SelectMultiple;
			this.mpHand.Size = new System.Drawing.Size(560, 120);
			this.mpHand.TabIndex = 1;
			this.mpHand.TheMoney = null;
			this.mpHand.SelectionChanged += new System.EventHandler(this.mpHand_SelectionChanged);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Enabled = false;
			this.cmdAdd.Location = new System.Drawing.Point(216, 264);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "&Add";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDropOut
			// 
			this.cmdDropOut.Location = new System.Drawing.Point(296, 264);
			this.cmdDropOut.Name = "cmdDropOut";
			this.cmdDropOut.TabIndex = 3;
			this.cmdDropOut.Text = "&Drop Out";
			this.cmdDropOut.Click += new System.EventHandler(this.cmdDropOut_Click);
			// 
			// AddToBidForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 293);
			this.ControlBox = false;
			this.Controls.Add(this.cmdDropOut);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.mpHand);
			this.Controls.Add(this.mpBidSoFar);
			this.Name = "AddToBidForm";
			this.Text = "Add To Bid";
			this.ResumeLayout(false);

		}
		#endregion

		private void mpHand_SelectionChanged(object sender, System.EventArgs e)
		{
			// calculate new total.
			ArrayList temp = new ArrayList();
			temp.AddRange(mpBidSoFar.TheMoney);
			temp.AddRange(mpHand.GetSelectedMoneyCards());
			int valueBid = CurrencyHelper.CurrencyValue((Money[]) temp.ToArray(typeof(Money)));
			if (_hasCertificato)
				valueBid += 3;
			cmdAdd.Enabled = valueBid > _bidToBeat;
			temp.Clear();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			_selectedMoney = new Money[mpHand.GetSelectedMoneyCards().Length];
			mpHand.GetSelectedMoneyCards().CopyTo(_selectedMoney,0);

			this.Close();
		}

		private void cmdDropOut_Click(object sender, System.EventArgs e)
		{
			_selectedMoney = null;

			this.Close();
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
