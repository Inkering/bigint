using System;

namespace BigIntBaseConversion
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			try
			{
				char [] sum = Numeral.AddSingleNumerals ('C', 'Q', 64);
				Console.WriteLine ("C + F = {0}{1}", sum [0], sum [1]);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine ("You done it wrong:  {0}", e.Message);
			}
			Console.ReadKey ();
		}
	}
}
