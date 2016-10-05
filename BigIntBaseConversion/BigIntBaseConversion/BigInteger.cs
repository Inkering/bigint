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
		/// Stores the base property
		/// </summary>
		/// <value>The base</value>
		public int Base
		{
			get; protected set;
		}
		/// <summary>
		/// The sign value. Stores whether the bigInteger is considered negative or not.
		/// </summary>
		/// <returns>Either bool True or False </returns>
		public bool Sign
		{
			get; protected set;
		}

		/// <summary>
		/// Returns the value of the bigInt in the form of a string
		/// </summary>
		/// <returns> string of bigint </returns>
		public override string ToString()
		{
			return string.Format("BigInteger: Value={0}", Value);
		}
		/// <summary>
		/// Returns the value of the bigInt in the form of a string plus the string form of its base.
		/// </summary>
		/// <returns> string of bigint and its base</returns>
		public string ToLongString()
		{
			return string.Format("BigInteger: Value={0}, Base={1}", Value, Base);
		}
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public String Value
		{
			get
			{
				String output = "";
				List<char> numerals = new List<char>(Numerals);
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
				output.Add(input [i]);
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
			Numerals = StringToPlaceValueArray(base10Numeral);
		}
		/// <summary>
		/// Create a new m-base BigInteger
		/// </summary>
		/// <param name="numeral">Numeral.</param>
		/// <param name="aBase">its base.</param>
		public BigInteger(String numeral, int aBase)
		{
			Base = aBase;
			Numerals = StringToPlaceValueArray(numeral);
		}
	}
}
