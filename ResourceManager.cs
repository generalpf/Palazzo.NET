using System;
using System.Collections;
using System.Xml;
using System.Xml.XPath;

namespace Palazzo
{
	/// <summary>
	/// Summary description for ResourceManager.
	/// </summary>
	public class ResourceManager
	{
		public static void LoadMonies(ArrayList deck)
		{
			// assume deck is empty.
			XmlDocument xd = new XmlDocument();
			xd.Load("resources.xml");
			XmlNodeList xnl = xd.SelectNodes("/resources/monies/money");
			IEnumerator e = xnl.GetEnumerator();
			while (e.MoveNext())
			{
				XmlNode n = (XmlNode) e.Current;
				int val = 0;
				string currency = "";
				int quantity = 0;
				string image = "";
				if (n.Attributes["value"] != null)
					val = Int32.Parse(n.Attributes["value"].Value);
				if (n.Attributes["currency"] != null)
					currency = n.Attributes["currency"].Value;
				if (n.Attributes["quantity"] != null)
					quantity = Int32.Parse(n.Attributes["quantity"].Value);
				if (n.Attributes["image"] != null)
					image = n.Attributes["image"].Value;
				CurrencyEnum c = new CurrencyEnum();
				switch (currency)
				{
					case "brown":
						c = CurrencyEnum.Brown;
						break;
					case "red":
						c = CurrencyEnum.Red;
						break;
					case "white":
						c = CurrencyEnum.White;
						break;
					case "certificate":
						c = CurrencyEnum.Certificate;
						break;
				}
				while (quantity-- > 0)
					deck.Add(new Money(c,val,image));
			}

			RandomizeArrayList(deck);
		}

		public static void LoadTiles(Stack stageOne, Stack stageTwo, Stack stageThree)
		{
			// we'll load 'em into an ArrayList, then we'll randomize them, then push them onto a Stack.
			ArrayList[] stages = new ArrayList[3];
			stages[0] = new ArrayList();
			stages[1] = new ArrayList();
			stages[2] = new ArrayList();

			XmlDocument xd = new XmlDocument();
			xd.Load("resources.xml");
			XmlNodeList xnl = xd.SelectNodes("/resources/tiles/tile");
			IEnumerator e = xnl.GetEnumerator();
			while (e.MoveNext())
			{
				XmlNode n = (XmlNode) e.Current;
				int stage = 0;
				string material = "";
				int floor = 0;
				int windows = 0;
				string image = "";
				if (n.Attributes["stage"] != null)
					stage = Int32.Parse(n.Attributes["stage"].Value);
				if (n.Attributes["material"] != null)
					material = n.Attributes["material"].Value;
				if (n.Attributes["floor"] != null)
					floor = Int32.Parse(n.Attributes["floor"].Value);
				if (n.Attributes["windows"] != null)
					windows = Int32.Parse(n.Attributes["windows"].Value);
				if (n.Attributes["image"] != null)
					image = n.Attributes["image"].Value;
				MaterialEnum m = new MaterialEnum();
				switch (material)
				{
					case "sandstone":
						m = MaterialEnum.Sandstone;
						break;
					case "marble":
						m = MaterialEnum.Marble;
						break;
					case "brick":
						m = MaterialEnum.Brick;
						break;
					case "rider":
						m = MaterialEnum.Rider;
						break;
				}
				Tile t = new Tile(stage,m,floor,windows,image);
				stages[stage - 1].Add(t);
			}

			for (int i = 0; i < 3; i++)
			{
				RandomizeArrayList(stages[i]);
				Stack s = (i == 0 ? stageOne : i == 1 ? stageTwo : stageThree);
				for (int j = 0; j < stages[i].Count; j++)
					s.Push(stages[i][j]);
			}
		}

		public static void RandomizeArrayList(ArrayList al)
		{
			System.Random r = new System.Random();
			for (int i = 0; i < 1000; i++)
			{
				int j = r.Next(0,al.Count - 2);	// not the top one, please.
				object o = al[j];
				al.RemoveAt(j);
				al.Add(o);
			}
		}
	}
}
