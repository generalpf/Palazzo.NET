using System;
using System.Collections;

namespace Palazzo
{
	/// <summary>
	/// Summary description for CurrencyHelper.
	/// </summary>
	public class CurrencyHelper
	{
		public static int CurrencyValue(Money[] money)
		{
			Money[] working = new Money[money.Length];
			money.CopyTo(working,0);

			int total = 0;

			/* 1. check for 15s. */
			int[] fifteens = FindFifteens(working);
			total += (15 * fifteens.Length);

			/* 2. remove the cards that make up the 15s (by nulling them). */
			for (int i = 0; i < fifteens.Length; i++)
			{
				if (fifteens[i] == 2)
				{
					// remove 3 value 2 cards.
					int foundCerts = 0;
					for (int j = 0; j < working.Length; j++)
					{
						if (working[j] == null)
							continue;

						if (working[j].Currency == CurrencyEnum.Certificate)
						{
							working[j] = null;
							if (++foundCerts == 3)
								break;
						}
					}
				}
				else
				{
					// remove one of each.
					bool foundBrown = false, foundRed = false, foundWhite = false;
					for (int j = 0; j < working.Length; j++)
					{
						if (working[j] == null)
							continue;

						if (!foundBrown && working[j].Currency == CurrencyEnum.Brown && working[j].Value == fifteens[i])
						{
							working[j] = null;
							foundBrown = true;
						}
						else if (!foundRed && working[j].Currency == CurrencyEnum.Red && working[j].Value == fifteens[i])
						{
							working[j] = null;
							foundRed = true;
						}
						else if (!foundWhite && working[j].Currency == CurrencyEnum.White && working[j].Value == fifteens[i])
						{
							working[j] = null;
							foundWhite = true;
						}
						if (foundBrown && foundRed && foundWhite)
							break;
					}
				}
			}

			/* 3. add up remaining cards, watching out for multiple currencies. */
			CurrencyEnum determinedCurrency = CurrencyEnum.Certificate;	// none yet.
			for (int i = 0; i < working.Length; i++)
			{
				if (working[i] == null)
					continue;

				if (determinedCurrency != CurrencyEnum.Certificate && 
							working[i].Currency != CurrencyEnum.Certificate && 
							determinedCurrency != working[i].Currency)
					return -1;
				total += working[i].Value;
				if (determinedCurrency == CurrencyEnum.Certificate)
					determinedCurrency = working[i].Currency;
			}

			return total;
		}

		/// <summary>
		/// Finds "fifteens" in the supplied money cards.
		/// </summary>
		/// <param name="money">Money cards to search.</param>
		/// <returns>An array of the values of the cards that makes up the 15, i.e. 2 (for 3x value 2), 5 (for 5-5-5), etc.</returns>
		public static int[] FindFifteens(Money[] money)
		{
			int certs = 0;
			int[] brown = new int[5];		// 3-7 -> 0-4
			int[] red = new int[5];
			int[] white = new int[5];
			int[] result = new int[0];
			ArrayList fifteens = new ArrayList();

			for (int i = 0; i < 5; i++)
				brown[i] = red[i] = white[i] = 0;

			for (int i = 0; i < money.Length; i++)
				switch (money[i].Currency)
				{
					case CurrencyEnum.Certificate:
						certs++;
						break;
					case CurrencyEnum.Brown:
						brown[money[i].Value - 3]++;
						break;
					case CurrencyEnum.Red:
						red[money[i].Value - 3]++;
						break;
					case CurrencyEnum.White:
						white[money[i].Value - 3]++;
						break;
				}

			bool found = true;

			while (found)
			{
				found = false;

				if (certs >= 3)
				{
					// add 2 to the array.
					fifteens.Add(2);
					certs -= 3;
					found = true;
				}
				else
				{
					for (int i = 0; i < 5; i++)
						if (brown[i] > 0 && red[i] > 0 && white[i] > 0)
						{
							fifteens.Add(i + 3);
							brown[i]--;
							red[i]--;
							white[i]--;
							found = true;
						}
				}
			}

			int[] foo = new int[fifteens.Count];
			fifteens.CopyTo(foo,0);

			return foo;
		}

		public static Money[] GetMoneyOfCurrency(Money[] money, CurrencyEnum currency)
		{
			ArrayList al = new ArrayList();
			foreach (Money m in money)
				if (m.Currency == currency)
					al.Add(m);
			return (Money[]) al.ToArray(typeof(Money));
		}
	}
}
