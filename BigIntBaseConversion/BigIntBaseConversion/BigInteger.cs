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
		///
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
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static BigInteger operator+ (BigInteger a, BigInteger b)
		{
			//find out how long we need our sum to be minus one
			//This is because any two numbers added will, at maximum, add one digit of length to their resultant
			int LongestInputLength = (b.Numerals.Count > a.Numerals.Count) ? b.Numerals.Count : a.Numerals.Count;

			//make it one larger than our longest input
			char[] sum = new char[LongestInputLength + 1];

			//next we will fill in the first number so that we can add the second later.
			for (int i = 0; i < sum.Length; i++)
			{
				if (i < a.Numerals.Count)
				{
					sum[i] = a.Numerals[i];
				}
				else
				{
					sum[i] = '0';
				}
			}

			//create variables with a narrower scope that contains the numerals of each input
			char[] B = b.Numerals.ToArray();

			//Loop through the places of the sum character list
			for (int i = 0; i < sum.Length - 1; i++)
			{
				//it's of size 2(the maximum size that any two single digit numbers added could result in
				char[] DigitHolder = new char[2];

				//add up the digits of the place we are at in the resultant(which we already put the numerals of a into)
				DigitHolder = (i < b.Numerals.Count) ? Numeral.AddSingleNumerals(sum[i], B[i]) : Numeral.AddSingleNumerals(sum[i], '0');
				sum[i] = DigitHolder[1];

				// carrying
				// If the first numeral in DigitHolder resets one past
				if (DigitHolder[0] == '1')
				{
					
					sum[i + 1] = Numeral.Increment(sum[i + 1]);

					for (int j = i + 1; sum[j] == '0'; j++)
					{
						sum[j + 1] = Numeral.Increment(sum[j + 1]);
					}

				}
			}

			//create a new instance of the class that we will then return(containing our resultant)
			BigInteger result = new BigInteger(sum);
			return result;
		}

		//multiply two instances of Biginteger
		public static BigInteger operator* (BigInteger a, BigInteger b)
		{
			//create a bigint instance for the result, (Assumes bases are the same between inputs)
			BigInteger result = new BigInteger("0", a.Base);
			//create a life of bigint instances to store our partials that we will later add up and put in result(grade school method)
			List<BigInteger> partial = new List<BigInteger>();

			//loop through the columns of the number we want to multiply by
			for (int column = 0; column < b.Numerals.Count; column++)
			{
				//store the value of b at that column
				int oneValue = Numeral.Numerals.IndexOf(b.Numerals[column]);
				//create a place to store the value of the partial for just that row
				BigInteger partRow = new BigInteger("0", a.Base);
				//loop through elementary style by adding a the partial back into it self as many times as dictated by a
				for (int i = 0; i < oneValue; i++)
				{
					partRow = partRow + a;
				}
				//Padd result in zeros just in case
				for (int k = 0; k < column; k++)
				{
					partRow.Numerals.Insert(0, '0');
				}
				//add the partial row to the total partial
				partial.Add(partRow);
			}
			//loop through partial bigint list to add up all the partials
			foreach (BigInteger part in partial)
			{
				result = result + part;

			}
			//return our completly finished resultant
			return result;
		}
		/// <summary>
		/// Create a new Base 10 BigInteger
		/// </summary>	
		/// <param name="base10Numeral">Base10 numeral.</param>
		public BigInteger (String base10Numeral)
		{
			foreach (char a in base10Numeral)
			{
				if (("0123456789").IndexOf(a) < 0)
				{
					throw new FormatException("Invalid bigint base 10 numeral");
				}
			}
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
		public BigInteger(char[] NewNumerals)
		{
			Base = 10;
			Numerals = new List<char>(NewNumerals);
		}
	}
}
