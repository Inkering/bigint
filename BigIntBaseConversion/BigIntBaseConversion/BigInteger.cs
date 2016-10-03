using System;
using System.Collections;
using System.Collections.Generic;
namespace BigIntBaseConversion
{
	public class BigInteger
	{
		/// <summary>
		/// Stores the numerals that make up this number as characters
		/// in a list.
		/// 
		/// These characters are in order such that their INDEX in the List
		/// corresponds to place-value power of the base.
		/// 
		/// e.g.  the 0th position is the one's place, 
		/// </summary>
		/// <value>The numerals.</value>
		protected List<char> Numerals 
		{
			get; set;
		}

		/// <summary>
		/// The 
		/// </summary>
		/// <value>The base.</value>
		public int Base 
		{
			get; protected set;
		}

		public String Value 
		{
			get 
			{
				String output = "";
				List<char> numerals = Numerals;
				numerals.Reverse ();
				foreach (char numeral in numerals)
				{
					output += numeral;
				}

				return output;
			}
		}

		/// <summary>
		/// Converts the input to a reversed character list.
		/// e.g.  "13827" -> { '7', '2', '8', '3', '1' }
		/// this is to facilitate computation using the index of each
		/// numeral as the power of the base for the place value. 
		/// </summary>
		/// <returns>The to place value array.</returns>
		/// <param name="input">Input.</param>
		private static List<char> StringToPlaceValueArray (String input)
		{
			List<char> output = new List<char> ();

			for (int i = input.Length - 1; i >= 0; i--) 
			{
				output.Add (input [i]);
			}

			return output;
		}

		/// <summary>
		/// Create a new Base 10 BigInteger
		/// </summary>
		/// <param name="base10Numeral">Base10 numeral.</param>
		public BigInteger (String base10Numeral)
		{
			Base = 10;
			Numerals = StringToPlaceValueArray (base10Numeral);
		}
	}
}
