using System;
using System.Drawing;

namespace Palazzo
{
	public enum CurrencyEnum { Red, Brown, White, Certificate };

	/// <summary>
	/// Summary description for Money.
	/// </summary>
	public class Money
	{
		protected CurrencyEnum _currency;
		protected int _value;
		protected string _image;
		
		public Money(CurrencyEnum currency, int val, string image)
		{
			_currency = currency;
			_value = val;
			_image = image;
		}

		public CurrencyEnum Currency
		{
			get
			{
				return _currency;
			}
		}

		public int Value
		{
			get
			{
				return _value;
			}
		}

		public override string ToString()
		{
			return _currency.ToString() + " " + _value.ToString();
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
