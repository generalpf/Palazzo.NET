using System;
using System.Windows.Forms;
using System.Collections;

namespace Palazzo
{
	/// <summary>
	/// Summary description for HumanPlayer.
	/// </summary>
	public class HumanPlayer : Player
	{
		public HumanPlayer(GameState gs,string playerName) : base(gs,playerName)
		{
		}

		public override TurnTypeEnum ChooseTurnType()
		{
			TurnTypeForm ttf = new TurnTypeForm(_playerName + ": choose turn type");
			ttf.ShowDialog();
			return ttf.TurnType;
		}

		public override void TakeMoney(System.Collections.ArrayList moneyCards, int howMany, out Money[] taken)
		{
			TakeMoneyForm tmf = new TakeMoneyForm(moneyCards,howMany,_playerName + ": take " + howMany + " card(s)");
			tmf.ShowDialog();

			taken = tmf.SelectedMoney;
		}

		public override bool BuyOrAuction()
		{
			return (MessageBox.Show(null,"Click Yes to buy, No to auction.","Buy or Auction",MessageBoxButtons.YesNo) == DialogResult.Yes);
		}

		public override void BuyTiles(out Money[] paid, out Tile[] bought)
		{
			BuyTilesForm btf = new BuyTilesForm(_gs.MaterialSupply,this._hand,_playerName + ": buy 1 or 2 tiles (" + (int) (10 - _gs.MaterialSupply.Count) + " each)");
			btf.ShowDialog();

			paid = btf.SelectedMoney;
			bought = btf.SelectedTiles;
		}

		public override void AllocateTiles(Tile[] tiles)
		{
			AllocateTilesForm atf = new AllocateTilesForm(this,tiles,_playerName + ": allocate tile(s)");
			atf.ShowDialog();
		}

		public override ArrayList AddCardsToBid(ArrayList tiles, ArrayList bidSoFar, int bidToBeat, bool hasCertificato)
		{
			AddToBidForm atbf = new AddToBidForm(bidSoFar,this.Hand,bidToBeat,hasCertificato,_playerName + ": add to bid (current bid: " + bidToBeat + ")");
			atbf.ShowDialog();

			if (atbf.SelectedMoney == null)
				return null;
			else
				return new ArrayList(atbf.SelectedMoney);
		}
	}
}
