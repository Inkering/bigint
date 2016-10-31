using System;

namespace BigIntBaseConversion
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			try
			{
				//char [] sum = Numeral.AddSingleNumerals ('C', 'Q', 64);
				//Console.WriteLine ("C + F = {0}{1}", sum [0], sum [1]);
				//BigInteger newInt = new BigInteger("100", 10);
				//BigInteger secondInt = new BigInteger("9", 10);
				//BigInteger thirdInt = BigInteger.Multiply(newInt, secondInt);
				Console.WriteLine("First base 10 Numeral?");
				BigInteger IntA = new BigInteger(Console.ReadLine(), 10);
				Console.WriteLine("Second base 10 Numeral?");
				BigInteger IntB = new BigInteger(Console.ReadLine(), 10);
				Console.WriteLine("Add or multiply them?");
				Console.WriteLine("1: Add\n2: Multiply");
				BigInteger IntC = new BigInteger("0");
				int Operator = Convert.ToInt32(Console.ReadLine());
				if (Operator == 1)
				{
					IntC = IntA + IntB;
				}
				else if(Operator == 2)
				{
					IntC = IntA * IntB;
				}
				else
				{
					Console.WriteLine("invalid option");
				}
				Console.WriteLine(IntC.ToLongString());
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine ("You done it wrong:  {0}", e.Message);
			}
			Console.ReadKey ();
		}
	}
}
