using System;
using System.Drawing;

namespace Palazzo
{
	public enum MaterialEnum { Brick, Marble, Sandstone, Rider };

	/// <summary>
	/// Summary description for Tile.
	/// </summary>
	public class Tile
	{
		protected int _stage;
		protected MaterialEnum _material;
		protected int _floor;
		protected int _windows;
		protected string _image;
				
		public Tile(int stage, MaterialEnum material, int floor, int windows, string image)
		{
			_stage = stage;
			_material = material;
			_floor = floor;
			_windows = windows;
			_image = image;
		}

		public int Stage
		{
			get
			{
				return _stage;
			}
		}

		public MaterialEnum Material
		{
			get
			{
				return _material;
			}
		}

		public int Windows
		{
			get
			{
				return _windows;
			}
		}

		public int Floor
		{
			get
			{
				return _floor;
			}
		}

		public override string ToString()
		{
			return _floor.ToString() + "/" + _material.ToString() + "/" + _windows.ToString();
		}

		public string Image
		{
			get
			{
				return _image;
			}
		}		
	}
}
