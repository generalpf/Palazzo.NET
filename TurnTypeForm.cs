using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Palazzo
{
	/// <summary>
	/// Summary description for TurnTypeForm.
	/// </summary>
	public class TurnTypeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdTakeMoney;
		private System.Windows.Forms.Button cmdBuyOrAuction;
		private System.Windows.Forms.Button cmdReconstruction;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private TurnTypeEnum _turnType;

		public TurnTypeForm(string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.cmdTakeMoney = new System.Windows.Forms.Button();
			this.cmdBuyOrAuction = new System.Windows.Forms.Button();
			this.cmdReconstruction = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdTakeMoney
			// 
			this.cmdTakeMoney.Location = new System.Drawing.Point(8, 8);
			this.cmdTakeMoney.Name = "cmdTakeMoney";
			this.cmdTakeMoney.Size = new System.Drawing.Size(80, 23);
			this.cmdTakeMoney.TabIndex = 0;
			this.cmdTakeMoney.Text = "Take Money";
			this.cmdTakeMoney.Click += new System.EventHandler(this.cmdTakeMoney_Click);
			// 
			// cmdBuyOrAuction
			// 
			this.cmdBuyOrAuction.Location = new System.Drawing.Point(96, 8);
			this.cmdBuyOrAuction.Name = "cmdBuyOrAuction";
			this.cmdBuyOrAuction.Size = new System.Drawing.Size(88, 23);
			this.cmdBuyOrAuction.TabIndex = 1;
			this.cmdBuyOrAuction.Text = "Buy or Auction";
			this.cmdBuyOrAuction.Click += new System.EventHandler(this.cmdBuyOrAuction_Click);
			// 
			// cmdReconstruction
			// 
			this.cmdReconstruction.Location = new System.Drawing.Point(192, 8);
			this.cmdReconstruction.Name = "cmdReconstruction";
			this.cmdReconstruction.Size = new System.Drawing.Size(88, 23);
			this.cmdReconstruction.TabIndex = 2;
			this.cmdReconstruction.Text = "Reconstruction";
			this.cmdReconstruction.Click += new System.EventHandler(this.cmdReconstruction_Click);
			// 
			// TurnTypeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 39);
			this.ControlBox = false;
			this.Controls.Add(this.cmdReconstruction);
			this.Controls.Add(this.cmdBuyOrAuction);
			this.Controls.Add(this.cmdTakeMoney);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "TurnTypeForm";
			this.Text = "It\'s Your Turn";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdTakeMoney_Click(object sender, System.EventArgs e)
		{
			_turnType = TurnTypeEnum.TakeMoney;
			this.Close();
		}

		private void cmdBuyOrAuction_Click(object sender, System.EventArgs e)
		{
			_turnType = TurnTypeEnum.BuyOrAuction;
			this.Close();
		}

		private void cmdReconstruction_Click(object sender, System.EventArgs e)
		{
			_turnType = TurnTypeEnum.Reconstruction;
			this.Close();
		}

		public TurnTypeEnum TurnType
		{
			get
			{
				return _turnType;
			}
		}
	}
}
