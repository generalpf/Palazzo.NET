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
	/// Summary description for PalazzoForm.
	/// </summary>
	public class PalazzoForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button cmdStartGame;

		private GameState _gs;
		private Palazzo.TilePool tpQuarry0;
		private Palazzo.TilePool tpMaterialSupply;
		private Palazzo.TilePool tpQuarry1;
		private Palazzo.TilePool tpQuarry2;
		private Palazzo.TilePool tpQuarry3;
		//private GameManager _gm;
		private ArrayList _moneyCards = null;
		private System.Windows.Forms.Button cmdStackOne;
		private System.Windows.Forms.Button cmdStackTwo;
		private System.Windows.Forms.Button cmdStackThree;
		private System.Windows.Forms.StatusBar sbStatus;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.Panel pnlPlayer0;
		private System.Windows.Forms.Panel pnlPlayer1;
		private System.Windows.Forms.Panel pnlPlayer2;
		private System.Windows.Forms.Panel pnlPlayer3;
		private Palazzo.MoneyPool mpHand;
		private Palazzo.PalacePool palacePool0;
		private Palazzo.PalacePool palacePool1;
		private Palazzo.PalacePool palacePool2;
		private Palazzo.PalacePool palacePool3;
		private System.Windows.Forms.Label lblRiderTiles;

		public event EventHandler OnGameStateChanged;
		//public event EventHandler OnSelectMoneyFromDrawn;

		private ManualResetEvent _mreDrawing = new ManualResetEvent(true);

		public PalazzoForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PalazzoForm));
			this.cmdStartGame = new System.Windows.Forms.Button();
			this.tpQuarry0 = new Palazzo.TilePool();
			this.tpMaterialSupply = new Palazzo.TilePool();
			this.tpQuarry1 = new Palazzo.TilePool();
			this.tpQuarry2 = new Palazzo.TilePool();
			this.tpQuarry3 = new Palazzo.TilePool();
			this.cmdStackOne = new System.Windows.Forms.Button();
			this.cmdStackTwo = new System.Windows.Forms.Button();
			this.cmdStackThree = new System.Windows.Forms.Button();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
			this.pnlPlayer0 = new System.Windows.Forms.Panel();
			this.palacePool0 = new Palazzo.PalacePool();
			this.pnlPlayer1 = new System.Windows.Forms.Panel();
			this.palacePool1 = new Palazzo.PalacePool();
			this.pnlPlayer2 = new System.Windows.Forms.Panel();
			this.palacePool2 = new Palazzo.PalacePool();
			this.pnlPlayer3 = new System.Windows.Forms.Panel();
			this.palacePool3 = new Palazzo.PalacePool();
			this.mpHand = new Palazzo.MoneyPool();
			this.lblRiderTiles = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
			this.pnlPlayer0.SuspendLayout();
			this.pnlPlayer1.SuspendLayout();
			this.pnlPlayer2.SuspendLayout();
			this.pnlPlayer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdStartGame
			// 
			this.cmdStartGame.Location = new System.Drawing.Point(24, 488);
			this.cmdStartGame.Name = "cmdStartGame";
			this.cmdStartGame.TabIndex = 9;
			this.cmdStartGame.Text = "Start Game";
			this.cmdStartGame.Click += new System.EventHandler(this.cmdStartGame_Click);
			// 
			// tpQuarry0
			// 
			this.tpQuarry0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tpQuarry0.Columns = 2;
			this.tpQuarry0.Gap = 3;
			this.tpQuarry0.Location = new System.Drawing.Point(176, 8);
			this.tpQuarry0.Name = "tpQuarry0";
			this.tpQuarry0.Rows = 5;
			this.tpQuarry0.Selected = false;
			this.tpQuarry0.SelectionMode = Palazzo.TileSelectionModeEnum.NoSelection;
			this.tpQuarry0.Size = new System.Drawing.Size(160, 160);
			this.tpQuarry0.TabIndex = 15;
			this.tpQuarry0.Text = "tilePool2";
			this.tpQuarry0.TheTiles = null;
			this.tpQuarry0.TileHeight = 40;
			this.tpQuarry0.TileWidth = 100;
			// 
			// tpMaterialSupply
			// 
			this.tpMaterialSupply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tpMaterialSupply.Columns = 2;
			this.tpMaterialSupply.Gap = 3;
			this.tpMaterialSupply.Location = new System.Drawing.Point(8, 8);
			this.tpMaterialSupply.Name = "tpMaterialSupply";
			this.tpMaterialSupply.Rows = 5;
			this.tpMaterialSupply.Selected = false;
			this.tpMaterialSupply.SelectionMode = Palazzo.TileSelectionModeEnum.NoSelection;
			this.tpMaterialSupply.Size = new System.Drawing.Size(160, 160);
			this.tpMaterialSupply.TabIndex = 16;
			this.tpMaterialSupply.Text = "tilePool2";
			this.tpMaterialSupply.TheTiles = null;
			this.tpMaterialSupply.TileHeight = 40;
			this.tpMaterialSupply.TileWidth = 100;
			// 
			// tpQuarry1
			// 
			this.tpQuarry1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tpQuarry1.Columns = 2;
			this.tpQuarry1.Gap = 3;
			this.tpQuarry1.Location = new System.Drawing.Point(344, 8);
			this.tpQuarry1.Name = "tpQuarry1";
			this.tpQuarry1.Rows = 5;
			this.tpQuarry1.Selected = false;
			this.tpQuarry1.SelectionMode = Palazzo.TileSelectionModeEnum.NoSelection;
			this.tpQuarry1.Size = new System.Drawing.Size(160, 160);
			this.tpQuarry1.TabIndex = 17;
			this.tpQuarry1.Text = "tilePool2";
			this.tpQuarry1.TheTiles = null;
			this.tpQuarry1.TileHeight = 40;
			this.tpQuarry1.TileWidth = 100;
			// 
			// tpQuarry2
			// 
			this.tpQuarry2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tpQuarry2.Columns = 2;
			this.tpQuarry2.Gap = 3;
			this.tpQuarry2.Location = new System.Drawing.Point(512, 8);
			this.tpQuarry2.Name = "tpQuarry2";
			this.tpQuarry2.Rows = 5;
			this.tpQuarry2.Selected = false;
			this.tpQuarry2.SelectionMode = Palazzo.TileSelectionModeEnum.NoSelection;
			this.tpQuarry2.Size = new System.Drawing.Size(160, 160);
			this.tpQuarry2.TabIndex = 18;
			this.tpQuarry2.Text = "tilePool2";
			this.tpQuarry2.TheTiles = null;
			this.tpQuarry2.TileHeight = 40;
			this.tpQuarry2.TileWidth = 100;
			// 
			// tpQuarry3
			// 
			this.tpQuarry3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tpQuarry3.Columns = 2;
			this.tpQuarry3.Gap = 3;
			this.tpQuarry3.Location = new System.Drawing.Point(680, 8);
			this.tpQuarry3.Name = "tpQuarry3";
			this.tpQuarry3.Rows = 5;
			this.tpQuarry3.Selected = false;
			this.tpQuarry3.SelectionMode = Palazzo.TileSelectionModeEnum.NoSelection;
			this.tpQuarry3.Size = new System.Drawing.Size(160, 160);
			this.tpQuarry3.TabIndex = 19;
			this.tpQuarry3.Text = "tilePool2";
			this.tpQuarry3.TheTiles = null;
			this.tpQuarry3.TileHeight = 40;
			this.tpQuarry3.TileWidth = 100;
			// 
			// cmdStackOne
			// 
			this.cmdStackOne.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdStackOne.BackgroundImage")));
			this.cmdStackOne.Image = ((System.Drawing.Image)(resources.GetObject("cmdStackOne.Image")));
			this.cmdStackOne.Location = new System.Drawing.Point(16, 456);
			this.cmdStackOne.Name = "cmdStackOne";
			this.cmdStackOne.TabIndex = 22;
			// 
			// cmdStackTwo
			// 
			this.cmdStackTwo.Image = ((System.Drawing.Image)(resources.GetObject("cmdStackTwo.Image")));
			this.cmdStackTwo.Location = new System.Drawing.Point(104, 456);
			this.cmdStackTwo.Name = "cmdStackTwo";
			this.cmdStackTwo.TabIndex = 23;
			// 
			// cmdStackThree
			// 
			this.cmdStackThree.Image = ((System.Drawing.Image)(resources.GetObject("cmdStackThree.Image")));
			this.cmdStackThree.Location = new System.Drawing.Point(192, 456);
			this.cmdStackThree.Name = "cmdStackThree";
			this.cmdStackThree.TabIndex = 0;
			// 
			// sbStatus
			// 
			this.sbStatus.Location = new System.Drawing.Point(0, 567);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						this.statusBarPanel1,
																						this.statusBarPanel2,
																						this.statusBarPanel3,
																						this.statusBarPanel4,
																						this.statusBarPanel5});
			this.sbStatus.Size = new System.Drawing.Size(840, 22);
			this.sbStatus.TabIndex = 24;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Text = "statusBarPanel2";
			this.statusBarPanel2.Width = 30;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Text = "statusBarPanel3";
			this.statusBarPanel3.Width = 30;
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.Text = "statusBarPanel4";
			this.statusBarPanel4.Width = 30;
			// 
			// statusBarPanel5
			// 
			this.statusBarPanel5.Text = "statusBarPanel5";
			this.statusBarPanel5.Width = 30;
			// 
			// pnlPlayer0
			// 
			this.pnlPlayer0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer0.Controls.Add(this.palacePool0);
			this.pnlPlayer0.Location = new System.Drawing.Point(176, 176);
			this.pnlPlayer0.Name = "pnlPlayer0";
			this.pnlPlayer0.Size = new System.Drawing.Size(160, 160);
			this.pnlPlayer0.TabIndex = 25;
			// 
			// palacePool0
			// 
			this.palacePool0.Gap = 3;
			this.palacePool0.Location = new System.Drawing.Point(8, 8);
			this.palacePool0.Name = "palacePool0";
			this.palacePool0.SelectionMode = Palazzo.PalaceSelectionModeEnum.NoSelection;
			this.palacePool0.Size = new System.Drawing.Size(144, 144);
			this.palacePool0.TabIndex = 0;
			this.palacePool0.ThePalaces = null;
			this.palacePool0.TileHeight = 40;
			this.palacePool0.TileWidth = 100;
			// 
			// pnlPlayer1
			// 
			this.pnlPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer1.Controls.Add(this.palacePool1);
			this.pnlPlayer1.Location = new System.Drawing.Point(344, 176);
			this.pnlPlayer1.Name = "pnlPlayer1";
			this.pnlPlayer1.Size = new System.Drawing.Size(160, 160);
			this.pnlPlayer1.TabIndex = 26;
			// 
			// palacePool1
			// 
			this.palacePool1.Gap = 3;
			this.palacePool1.Location = new System.Drawing.Point(8, 8);
			this.palacePool1.Name = "palacePool1";
			this.palacePool1.SelectionMode = Palazzo.PalaceSelectionModeEnum.NoSelection;
			this.palacePool1.Size = new System.Drawing.Size(144, 144);
			this.palacePool1.TabIndex = 0;
			this.palacePool1.ThePalaces = null;
			this.palacePool1.TileHeight = 40;
			this.palacePool1.TileWidth = 100;
			// 
			// pnlPlayer2
			// 
			this.pnlPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer2.Controls.Add(this.palacePool2);
			this.pnlPlayer2.Location = new System.Drawing.Point(512, 176);
			this.pnlPlayer2.Name = "pnlPlayer2";
			this.pnlPlayer2.Size = new System.Drawing.Size(160, 160);
			this.pnlPlayer2.TabIndex = 27;
			// 
			// palacePool2
			// 
			this.palacePool2.Gap = 3;
			this.palacePool2.Location = new System.Drawing.Point(7, 7);
			this.palacePool2.Name = "palacePool2";
			this.palacePool2.SelectionMode = Palazzo.PalaceSelectionModeEnum.NoSelection;
			this.palacePool2.Size = new System.Drawing.Size(144, 144);
			this.palacePool2.TabIndex = 1;
			this.palacePool2.ThePalaces = null;
			this.palacePool2.TileHeight = 40;
			this.palacePool2.TileWidth = 100;
			// 
			// pnlPlayer3
			// 
			this.pnlPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer3.Controls.Add(this.palacePool3);
			this.pnlPlayer3.Location = new System.Drawing.Point(680, 176);
			this.pnlPlayer3.Name = "pnlPlayer3";
			this.pnlPlayer3.Size = new System.Drawing.Size(160, 160);
			this.pnlPlayer3.TabIndex = 28;
			// 
			// palacePool3
			// 
			this.palacePool3.Gap = 3;
			this.palacePool3.Location = new System.Drawing.Point(7, 7);
			this.palacePool3.Name = "palacePool3";
			this.palacePool3.SelectionMode = Palazzo.PalaceSelectionModeEnum.NoSelection;
			this.palacePool3.Size = new System.Drawing.Size(144, 144);
			this.palacePool3.TabIndex = 1;
			this.palacePool3.ThePalaces = null;
			this.palacePool3.TileHeight = 40;
			this.palacePool3.TileWidth = 100;
			// 
			// mpHand
			// 
			this.mpHand.CardHeight = 100;
			this.mpHand.CardWidth = 65;
			this.mpHand.Columns = 20;
			this.mpHand.DisabledMoney = null;
			this.mpHand.Gap = 3;
			this.mpHand.Location = new System.Drawing.Point(8, 344);
			this.mpHand.Name = "mpHand";
			this.mpHand.Rows = 1;
			this.mpHand.SelectionMode = Palazzo.MoneySelectionModeEnum.NoSelection;
			this.mpHand.Size = new System.Drawing.Size(824, 100);
			this.mpHand.TabIndex = 29;
			this.mpHand.TheMoney = null;
			// 
			// lblRiderTiles
			// 
			this.lblRiderTiles.Location = new System.Drawing.Point(320, 456);
			this.lblRiderTiles.Name = "lblRiderTiles";
			this.lblRiderTiles.TabIndex = 30;
			this.lblRiderTiles.Text = "no rider tiles";
			// 
			// PalazzoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(840, 589);
			this.Controls.Add(this.lblRiderTiles);
			this.Controls.Add(this.mpHand);
			this.Controls.Add(this.pnlPlayer3);
			this.Controls.Add(this.pnlPlayer2);
			this.Controls.Add(this.pnlPlayer1);
			this.Controls.Add(this.pnlPlayer0);
			this.Controls.Add(this.sbStatus);
			this.Controls.Add(this.cmdStackThree);
			this.Controls.Add(this.cmdStackTwo);
			this.Controls.Add(this.cmdStackOne);
			this.Controls.Add(this.tpQuarry3);
			this.Controls.Add(this.tpQuarry2);
			this.Controls.Add(this.tpQuarry1);
			this.Controls.Add(this.tpMaterialSupply);
			this.Controls.Add(this.tpQuarry0);
			this.Controls.Add(this.cmdStartGame);
			this.Name = "PalazzoForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Reiner Knizia\'s Palazzo";
			this.Load += new System.EventHandler(this.PalazzoForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
			this.pnlPlayer0.ResumeLayout(false);
			this.pnlPlayer1.ResumeLayout(false);
			this.pnlPlayer2.ResumeLayout(false);
			this.pnlPlayer3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PalazzoForm());
		}

		private void PalazzoForm_Load(object sender, System.EventArgs e)
		{
			
		}

		private string tilesToString(IEnumerable tiles)
		{
			StringBuilder sb = new StringBuilder();
			IEnumerator e = tiles.GetEnumerator();
			while (e.MoveNext())
			{
				Tile t = (Tile) e.Current;
				sb.Append(t.ToString() + ",");
			}
			return sb.ToString();
		}

		private void cmdStartGame_Click(object sender, System.EventArgs e)
		{
			_gs = new GameState();
			//_gm = new GameManager(_gs);
			this.OnGameStateChanged += new EventHandler(gm_OnGameStateChanged);
			//this.OnSelectMoneyFromDrawn += new EventHandler(PalazzoForm_OnSelectMoneyFromDrawn);
			//Thread t = new Thread(new ThreadStart(this.RunGame));
			//t.Start();
			RunGame();
		}

		private void gm_OnGameStateChanged(object sender, EventArgs e)
		{
			cmdStackOne.Text = _gs.StageOne.Count.ToString();
			cmdStackTwo.Text = _gs.StageTwo.Count.ToString();
			cmdStackThree.Text = _gs.StageThree.Count.ToString();

			switch (_gs.CurrentAction)
			{
				case GameAction.ActionSelection:
					sbStatus.Panels[0].Text = "Select an action.";
					break;
			}

			for (int i = 0; i < _gs.Players; i++)
				sbStatus.Panels[i + 1].Text = "P" + (i + 1) + ": " + _gs.GetPlayer(i).GetPoints();

			tpQuarry0.TheTiles = _gs.Quarry[0];
			tpQuarry1.TheTiles = _gs.Quarry[1];
			tpQuarry2.TheTiles = _gs.Quarry[2];
			tpQuarry3.TheTiles = _gs.Quarry[3];
			tpMaterialSupply.TheTiles = _gs.MaterialSupply;
			// TODO: fix flicker.
			mpHand.TheMoney = _gs.GetPlayer(_gs.ActivePlayer).Hand;
			palacePool0.ThePalaces = _gs.GetPlayer(0).Palaces;
			palacePool1.ThePalaces = _gs.GetPlayer(1).Palaces;
			if (_gs.Players > 2)
				palacePool2.ThePalaces = _gs.GetPlayer(2).Palaces;
			if (_gs.Players > 3)
				palacePool3.ThePalaces = _gs.GetPlayer(3).Palaces;

			tpQuarry0.BorderStyle = tpQuarry1.BorderStyle = tpQuarry2.BorderStyle = tpQuarry3.BorderStyle = BorderStyle.FixedSingle;
			if (_gs.MasterBuilder == 0)
				tpQuarry0.BorderStyle = BorderStyle.Fixed3D;
			else if (_gs.MasterBuilder == 1)
				tpQuarry1.BorderStyle = BorderStyle.Fixed3D;
			else if (_gs.MasterBuilder == 2)
				tpQuarry2.BorderStyle = BorderStyle.Fixed3D;
			else if (_gs.MasterBuilder == 3)
				tpQuarry3.BorderStyle = BorderStyle.Fixed3D;

			//lblRiderTiles.Text = _gs.RiderTiles.Length

			this.Refresh();
		}

		private void RunGame()
		{
			// ask how many players we want.
			int players = 2;
			int humanPlayers = 2;
			_gs.InitializeGame(players,humanPlayers);
			OnGameStateChanged(this,new EventArgs());

			while (!IsGameOver())
			{
				Player theActivePlayer = _gs.GetPlayer(_gs.ActivePlayer);
				TurnTypeEnum tt = theActivePlayer.ChooseTurnType();
				switch (tt)
				{
					case TurnTypeEnum.TakeMoney:
						/* 1. draw money cards. */
						_moneyCards = new ArrayList();
						int draw = _gs.Players + 1;
						while (draw-- > 0)
						{
							if (_gs.MoneyDeck.Count == 0)
								_gs.ShuffleMoney();
							_moneyCards.Add(_gs.MoneyDeck[_gs.MoneyDeck.Count - 1]);
							_gs.MoneyDeck.RemoveAt(_gs.MoneyDeck.Count - 1);
						}
						OnGameStateChanged(this,new EventArgs());

						Money[] taken;
						/* 2. tell the active player to take 2 cards. */
						theActivePlayer.TakeMoney(_moneyCards,2,out taken);
						for (int i = 0; i < 2; i++)
						{
							theActivePlayer.Hand.Add(taken[i]);
							_moneyCards.Remove(taken[i]);
						}
						OnGameStateChanged(this,new EventArgs());

						/* 3. tell everyone else to take 1 card. */
						for (int i = 1; i <= _gs.Players - 1; i++)
						{
							Player thePlayer = _gs.GetPlayer((_gs.ActivePlayer + i) % _gs.Players);
							
							thePlayer.TakeMoney(_moneyCards,1,out taken);
							thePlayer.Hand.Add(taken[0]);
							_moneyCards.Remove(taken[0]);
							
							OnGameStateChanged(this,new EventArgs());
						}
						_moneyCards = null;

						break;

					case TurnTypeEnum.BuyOrAuction:
						/* 1. draw a tile and add it to the material supply. */
						Tile t = (Tile) _gs.ActiveTileStack.Pop();
						if (t.Material == MaterialEnum.Rider)
							// the floor is 1-based while the array is 0-based.
							_gs.RiderTiles[t.Floor - 1] = t;
						else
							_gs.MaterialSupply.Add(_gs.ActiveTileStack.Pop());
						OnGameStateChanged(this,new EventArgs());
						
						/* 2. draw a tile and add it to the appropriate quarry. */
						t = (Tile) _gs.ActiveTileStack.Pop();
						if (t.Material == MaterialEnum.Rider)
							// the floor is 1-based while the array is 0-based.
							_gs.RiderTiles[t.Floor - 1] = t;
						else
						{
							int q = (_gs.MasterBuilder + t.Windows) % 4;
							_gs.Quarry[q].Add(t);
							OnGameStateChanged(this,new EventArgs());
						}

						// we don't buy/auction if we're all full up on Riders.
						if (IsGameOver())
							continue;

						/* 3. ask the active player if they want to buy or auction. */
						bool buy = theActivePlayer.BuyOrAuction();

						if (buy)
						{
							Money[] paid;
							Tile[] bought;
							theActivePlayer.BuyTiles(out paid,out bought);
							foreach (Money p in paid)
							{
								_gs.DiscardPile.Add(p);
								theActivePlayer.Hand.Remove(p);
							}
							foreach (Tile b in bought)
							{
								_gs.MaterialSupply.Remove(b);
							}
							OnGameStateChanged(this,new EventArgs());
							theActivePlayer.AllocateTiles(bought);
							OnGameStateChanged(this,new EventArgs());
						}
						else
						{
							// move the Master Builder.
							_gs.AdvanceMasterBuilder();
							OnGameStateChanged(this,new EventArgs());
							_gs.StartBidding();
							
							// the active player's bid is 3, so ask the next guy.
							int bidder = _gs.ActivePlayer;
							int bidToBeat = 3;

							while (!_gs.IsBiddingComplete())
							{
								bidder = (bidder + 1) % _gs.Players;

								Player p = _gs.GetPlayer(bidder);
								ArrayList cards = p.AddCardsToBid(_gs.Quarry[_gs.MasterBuilder],_gs.GetCurrentPlayerBid(bidder),bidToBeat,bidder == _gs.ActivePlayer);
								_gs.AddCardsToPlayerBid(bidder,cards);
								if (cards != null)
								{
									bidToBeat = CurrencyHelper.CurrencyValue((Money []) _gs.GetCurrentPlayerBid(bidder).ToArray(typeof(Money)));
									if (bidder == _gs.ActivePlayer)
										bidToBeat += 3;
								}
							}

							int winner = _gs.GetWinningBidder();
							// this player's bid cards are lost, the others' are not.
							ArrayList winningBid = _gs.GetCurrentPlayerBid(winner);
							foreach (Money m in winningBid)
                                _gs.GetPlayer(winner).Hand.Remove(m);
							for (int i = 0; i < _gs.Players; i++)
								_gs.GetCurrentPlayerBid(i).Clear();
							OnGameStateChanged(this,new EventArgs());
							
							_gs.GetPlayer(winner).AllocateTiles((Tile []) _gs.Quarry[_gs.MasterBuilder].ToArray(typeof(Tile)));
						}

						break;
				}
				_gs.NextTurn();
				OnGameStateChanged(this,new EventArgs());
			}
		}

		private bool IsGameOver()
		{	
			return (_gs.RiderTiles[0] != null && 
				_gs.RiderTiles[1] != null && 
				_gs.RiderTiles[2] != null && 
				_gs.RiderTiles[3] != null && 
				_gs.RiderTiles[4] != null);
		}

		private void PalazzoForm_OnSelectMoneyFromDrawn(object sender, EventArgs e)
		{
			_mreDrawing.Reset();
		}

		private void mpDrawnCards_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int hitIndex = 0; //mpDrawnCards.HitIndex(e.X,e.Y);
			Money m = (Money) _moneyCards[hitIndex];
			_moneyCards.RemoveAt(hitIndex);
			_gs.GetPlayer(0).Hand.Add(m);
			_mreDrawing.Set();
		}
	}
}
