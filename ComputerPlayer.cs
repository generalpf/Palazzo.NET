using System;
using System.Collections;

namespace Palazzo
{
	/// <summary>
	/// Summary description for ComputerPlayer.
	/// </summary>
	public class ComputerPlayer : Player
	{
		public ComputerPlayer(GameState gs, string playerName) : base(gs,playerName)
		{
		}

		public override TurnTypeEnum ChooseTurnType()
		{
			// always take money, for now.
			return TurnTypeEnum.TakeMoney;
		}

		public override void TakeMoney(System.Collections.ArrayList moneyCards, int howMany, out Money[] taken)
		{
			// take the first one(s), for now.
			Money[] takeThese = new Money[howMany];
			while (howMany-- > 0)
				takeThese[howMany] = (Money) moneyCards[howMany];
			taken = takeThese;
		}

		public override bool BuyOrAuction()
		{
			return false;	// false = auction
		}

		public override void BuyTiles(out Money[] paid, out Tile[] bought)
		{
			// for now, don't buy anything (illegal).
			paid = null;
			bought = null;
		}

		public override void AllocateTiles(Tile[] tiles)
		{
		}

		public override ArrayList AddCardsToBid(ArrayList tiles, ArrayList bidSoFar, int bidToBeat, bool hasCertificato)
		{
			if (bidSoFar.Count == 0)
			{
				Money[] red = CurrencyHelper.GetMoneyOfCurrency((Money[]) this.Hand.ToArray(typeof(Money)),CurrencyEnum.Red);
				if (red.Length != 0)
					return new ArrayList(red);
				Money[] brown = CurrencyHelper.GetMoneyOfCurrency((Money[]) this.Hand.ToArray(typeof(Money)),CurrencyEnum.Brown);
				if (brown.Length != 0)
					return new ArrayList(brown);
				Money[] white = CurrencyHelper.GetMoneyOfCurrency((Money[]) this.Hand.ToArray(typeof(Money)),CurrencyEnum.White);
				if (white.Length != 0)
					return new ArrayList(white);
				return null;
			}
			else
				return null;		// drop out (don't raise)
		}
	}
}
