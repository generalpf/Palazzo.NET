using System;
using System.Collections;

namespace Palazzo
{
	/// <summary>
	/// Summary description for Palace.
	/// </summary>
	public class Palace
	{
		//Stack _tiles;
		ArrayList _tiles;

		public Palace()
		{
			_tiles = new ArrayList(5);
		}

		public void AddTile(Tile tile)
		{
			if (CanAddTile(tile))
				_tiles.Add(tile);
			else
				throw new ApplicationException("New tile cannot be added to palace.");
		}

		public bool CanAddTile(Tile tile)
		{
			// ensure the new tile's floor is higher than our highest floor.
			bool okay = false;
			if (_tiles.Count == 0)
				okay = true;
			else
			{
				Tile top = (Tile) _tiles[_tiles.Count - 1];
				okay = tile.Floor > top.Floor;
			}
			return okay;
		}

		public void InsertTile(Tile tile)
		{
			if (_tiles.Count == 0) 
			{
				_tiles.Add(tile);
				return;
			}
			
			IEnumerator e = _tiles.GetEnumerator();
			int i = -1;
			while (e.MoveNext())
			{
				i++;
				Tile cur = (Tile) e.Current;
				if (cur.Floor == tile.Floor)
					throw new ApplicationException("Inserted tile cannot be added to palace.");
				if (cur.Floor > tile.Floor)
				{
					// found where it goes, so add it and let's go.
					_tiles.Insert(i,tile);
					return;
				}
			}

			// it's a higher floor than all the others, so add it and go.
			_tiles.Add(tile);
		}

		/// <summary>
		/// Helper function to determine if a palace is eligible for extra points.
		/// </summary>
		/// <returns>True if this palace is made of all one type of material, false otherwise.</returns>
		public bool IsPure()
		{
			if (_tiles.Count == 0)
				return true;

			MaterialEnum m = new MaterialEnum();
			IEnumerator e = _tiles.GetEnumerator();
			e.MoveNext();
			m = ((Tile) e.Current).Material;
			while (e.MoveNext())
			{
				if (((Tile) e.Current).Material != m)
					return false;
			}
					   
			return true;
		}

		public int PointValue()
		{
			if (_tiles.Count == 1)
				return -5;

			if (_tiles.Count == 2)
				return 0;

			int windows = 0;
			IEnumerator e = _tiles.GetEnumerator();
			while (e.MoveNext())
			{
				Tile tile = (Tile) e.Current;
				windows += tile.Windows;
			}

			int points = windows;
			if (_tiles.Count == 4)
				points += 3;
			else if (_tiles.Count == 5)
				points += 6;

			if (IsPure())
			{
				if (_tiles.Count == 5)
					points += 6;
				else
					points += 3;
			}

			return points;
		}

		public ArrayList Tiles
		{
			get
			{
				return _tiles;
			}
		}
	}
}
