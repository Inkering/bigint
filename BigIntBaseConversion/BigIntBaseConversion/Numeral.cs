using System;
using System.Linq;

namespace BigIntBaseConversion
{
	/// <summary>
	/// Static class used for ensuring that everyone's encoding of numerals is consistent.
	/// The Numerals string has the characters in the standard ordering.
	///
	/// Base64StandardEncoding is used for encoding raw data for transmission over different
	/// stream protocols (such as the internet!).  There is a very particular algorithm for
	/// doing this encoding! Hint-hint-hint~
	/// </summary>
	public static class Numeral
	{
		/// <summary>
		/// The numerals for bases up to Base64
		/// </summary>
		public static readonly String Numerals =
			"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

#region for future use

		/// <summary>
		/// The base64 standard encoding.
		/// Note that this is not used for representing numbers!
		/// This is used for base64 encoding of raw data.
		///
		/// Use of this is not yet implemented in this project
		/// but is primarily here as a curiosity~
		/// </summary>
		public static readonly String Base64StandardEncoding =
			"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

		#endregion

		/// <summary>
		/// Adds the single numerals.
		/// </summary>
		/// <returns>The sum of the two single numerals.</returns>
		/// <param name="a">a single numeral.</param>
		/// <param name="b">a single numeral.</param>
		public static char [] AddSingleNumerals (char a, char b, int inBase = 10)
		{
			// Check to make sure that n is a vaild Numeral in the given base.
			if (!Numerals.Substring (0, inBase).Contains (a)) {
				// if it isn't, then throw an ArgumentOutOfRangeException.
				throw new ArgumentOutOfRangeException (
					nameof (a),
					String.Format ("'{0}' is not a valid base {1} Numeral", a, inBase));
			}

			// Check to make sure that n is a vaild Numeral in the given base.
			if (!Numerals.Substring (0, inBase).Contains (b)) {
				// if it isn't, then throw an ArgumentOutOfRangeException.
				throw new ArgumentOutOfRangeException (
					nameof (b),
					String.Format ("'{0}' is not a valid base {1} Numeral", b, inBase));
			}

			char [] sum = { '0', a };

			for (char count = '0'; count != b; count = Increment (count, inBase))
			{
				sum[1] = Increment (sum [1], inBase);

				if (sum [1] == '0') // if the Increment wrapped around back to zero.
				{
					sum [0] = '1';
				}
			}

			return sum;
		} 



#region Change between Int32 and Char

		/// <summary>
		/// Gets the base10 value of the given numeral.
		/// If the character is invalid, throws an Argument Out Of Range Exception.
		/// </summary>
		/// <returns>The base10 value.</returns>
		/// <param name="numeral">Numeral character.</param>
		public static int GetBase10Value (char numeral)
		{
			// if the numeral character given is not valid
			// throw an Argument Out Of Range Exception.
			if (Numerals.IndexOf (numeral) < 0)
			{
				throw new ArgumentOutOfRangeException (
					nameof (numeral),  // Gets the Name of the numeral variable
					"Numeral must be a character in the standard (up-to) Base-64 character set.");
			}

			return Numerals.IndexOf (numeral);
		}

		/// <summary>
		/// Gets the numeral from base10 number.
		/// </summary>
		/// <returns>The numeral encoding of the given base 10 number as a single numeral.</returns>
		/// <param name="value">base 10 number to convert to a single numeral.</param>
		public static char GetNumeralFromBase10 (int value)
		{
			if (value > 63 || value < 0)
			{
				throw new ArgumentOutOfRangeException (
					nameof (value),
					"Value must be between 0 and 63.");
			}

			return Numerals [value];
		}

		#endregion


		/// <summary>
		/// Increment the specified Numeral and in the given Base.
		/// </summary>
		/// <param name="n">N.</param>
		/// <param name="inBase">In base.</param>
		public static char Increment (char n, int inBase = 10)
		{
			// Check to make sure that n is a vaild Numeral in the given base.
			if (!Numerals.Substring (0, inBase).Contains (n))
			{
				// if it isn't, then throw an ArgumentOutOfRangeException.
				throw new ArgumentOutOfRangeException (
					nameof (n),
					String.Format ("'{0}' is not a valid base {1} Numeral", n, inBase));
			}

			// convert the Numeral Character into an abstract Number.
			int index = Numerals.IndexOf (n);
			index = (index + 1) % inBase;
			// "% inBase" ensures the wrap-around!
			// e.g.  in Base 10, '9' -> 9 + 1 = 10 -> 10 % 10 = 0.

			return Numerals [index];
		}
	}
}
