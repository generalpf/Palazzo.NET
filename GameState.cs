using System;
using System.Collections;

namespace Palazzo
{
	public enum GameAction 
	{
		ActionSelection,
		TakeMoney,
		AuctionOrBuy,
		SelectTilesToBuy,
		RaiseBidOrDropOut,
		PositionTiles,
		Reposition
	}

	/// <summary>
	/// Summary description for GameState.
	/// </summary>
	public class GameState
	{
		private int _masterBuilder;
		private Stack _stageOne, _stageTwo, _stageThree;
		private ArrayList _moneyDeck, _discardPile;
		private int _players;
		private Player[] _player;
		private int _activePlayer;
		private int _innerPlayer;
		private GameAction _currentAction;
		private ArrayList _materialSupply;
		private ArrayList[] _quarry;
		private Tile[] _riderTiles;
		private ArrayList[] _currentBid;
		private bool[] _passedBid;

		public GameState()
		{
		}

		public void InitializeGame(int players, int humanPlayers)
		{
			_players = players;

			// create the players and bid ArrayLists;
			// player 0 is the human player.
			_player = new Player[_players];
			_currentBid = new ArrayList[_players];
			_passedBid = new bool[_players];
			string[] humanNames = new string[4] { "Alice", "Bob", "Chuck", "Danielle" };
			for (int i = 0; i < _players; i++)
			{
				if (i < humanPlayers)
					_player[i] = new HumanPlayer(this,humanNames[i]);
				else
					_player[i] = new ComputerPlayer(this,"Computer " + (i - humanPlayers));
				_currentBid[i] = new ArrayList();
			}
			
			// load the building tiles into the three stacks.
			_stageOne = new Stack();
			_stageTwo = new Stack();
			_stageThree = new Stack();
			ResourceManager.LoadTiles(_stageOne,_stageTwo,_stageThree);

			// load the money deck.
			_moneyDeck = new ArrayList();
			ResourceManager.LoadMonies(_moneyDeck);
			_discardPile = new ArrayList();

			// deal the money.
			for (int i = 0; i < _players; i++)
			{
				ArrayList topFour = _moneyDeck.GetRange(_moneyDeck.Count - 4,4);
				_player[i].Hand.AddRange(topFour);
				_moneyDeck.RemoveRange(_moneyDeck.Count - 4,4);
			}

			// create the material supply and populate it.
			_materialSupply = new ArrayList();
			_materialSupply.Add(ActiveTileStack.Pop());
			
			// creat the four quarries and populate them.
			_quarry = new ArrayList[4];
			for (int i = 0; i < 4; i++)
			{
				_quarry[i] = new ArrayList();
				_quarry[i].Add(ActiveTileStack.Pop());
			}

			_masterBuilder = 0;
			_riderTiles = new Tile[5];

			_activePlayer = (new System.Random()).Next(0,_players - 1);
			_currentAction = GameAction.ActionSelection;
		}

		public Stack ActiveTileStack
		{
			get
			{
				if (_stageOne.Count > 0)
					return _stageOne;
				else if (_stageTwo.Count > 0)
					return _stageTwo;
				else
					return _stageThree;
			}
		}

		public Stack StageOne
		{
			get
			{
				return _stageOne;
			}
		}

		public Stack StageTwo
		{
			get
			{
				return _stageTwo;
			}
		}

		public Stack StageThree
		{
			get
			{
				return _stageThree;
			}
		}

		private int getAuctionQuarry()
		{
			for (int i = 1; i <= 4; i++)
			{
				int lookAtThisQuarry = (_masterBuilder + i) % 4;
				if (_quarry[lookAtThisQuarry].Count > 0)
					return lookAtThisQuarry;
			}
			// hmmm, there's nothing out there.
			return _masterBuilder;
		}

		public int ActivePlayer
		{
			get
			{
				return _activePlayer;
			}
		}

		public ArrayList MoneyDeck
		{
			get
			{
				return _moneyDeck;
			}
		}

		public ArrayList DiscardPile
		{
			get
			{
				return _discardPile;
			}
		}

		public Player GetPlayer(int p)
		{
			return _player[p];
		}

		public ArrayList GetCurrentPlayerBid(int p)
		{
			return _currentBid[p];
		}

		public void StartBidding()
		{
			for (int i = 0; i < _players; i++)
				_passedBid[i] = false;
		}

		public void AddCardsToPlayerBid(int p, ArrayList cards)
		{
			// if cards == null, that player passed.
			if (cards == null)
			{
				_passedBid[p] = true;
				_currentBid[p].Clear();
			}
			else
				_currentBid[p].AddRange(cards);
		}
		
		public bool IsBiddingComplete()
		{
			int bidders = 0;
			for (int i = 0; i < _players; i++)
				if (_passedBid[i] == false)
					bidders++;
			return (bidders == 1);
		}

		public int GetWinningBidder()
		{
			for (int i = 0; i < _players; i++)
				if (_passedBid[i] == false)
					return i;
			throw new ApplicationException("No winning bidder?!?");
		}

		public Tile[] RiderTiles
		{
			get
			{
				return _riderTiles;
			}
		}

		public void NextTurn()
		{
			_activePlayer = (_activePlayer + 1) % _players;
		}

		public int Players
		{
			get
			{
				return _players;
			}
		}

		public void ShuffleMoney()
		{
			_moneyDeck.AddRange(_discardPile);
			_discardPile.Clear();
			ResourceManager.RandomizeArrayList(_moneyDeck);
		}

		public int MasterBuilder
		{
			get
			{
				return _masterBuilder;
			}
		}

		public void AdvanceMasterBuilder()
		{
			// look ahead to the first non-empty quarry.
			for (int i = 1; i <= 4; i++)
				if (_quarry[(_masterBuilder + i) % 4].Count != 0)
				{
					_masterBuilder = (_masterBuilder + i) % 4;
					return;
				}
		}

		public ArrayList MaterialSupply
		{
			get
			{
				return _materialSupply;
			}
		}

		public ArrayList[] Quarry
		{
			get
			{
				return _quarry;
			}
		}

		public GameAction CurrentAction
		{
			get
			{
				return _currentAction;
			}
			set
			{
				_currentAction = value;
			}
		}

		public int InnerPlayer
		{
			get
			{
				return _innerPlayer;
			}
			set
			{
				_innerPlayer = value;
			}
		}
		
	}
}
