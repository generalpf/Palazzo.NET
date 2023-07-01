using System;
using System.Collections;

namespace Palazzo
{
	public enum TurnTypeEnum { TakeMoney, BuyOrAuction, Reconstruction };

	/// <summary>
	/// Summary description for Player.  Will be inherited for physical players and computer players.
	/// </summary>
	public abstract class Player
	{
		protected ArrayList _palaces;
		protected ArrayList _hand;
		protected GameState _gs;
		protected string _playerName;
		
		public Player(GameState gs, string playerName)
		{
			_palaces = new ArrayList();
			_hand = new ArrayList();
			_gs = gs;
			_playerName = playerName;
		}

		public ArrayList Palaces
		{
			get
			{
				return _palaces;
			}
		}

		public ArrayList Hand
		{
			get
			{
				return _hand;
			}
		}

		public int GetPoints()
		{
			int points = 0;
			foreach (Palace p in Palaces)
			{
				points += p.PointValue();
			}
			return points;
		}

		public abstract TurnTypeEnum ChooseTurnType();
		public abstract void TakeMoney(ArrayList moneyCards, int howMany, out Money[] taken);
		public abstract bool BuyOrAuction();
		public abstract void BuyTiles(out Money[] paid, out Tile[] bought);
		public abstract void AllocateTiles(Tile[] tiles);
		// return NULL to drop out.
		public abstract ArrayList AddCardsToBid(ArrayList tiles, ArrayList bidSoFar, int bidToBeat, bool hasCertificato);
	}
}
