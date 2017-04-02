using System;
using System.Linq;

namespace Primes
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 1_000_000;
			Console.WriteLine($"Count of first {count} primes: {FindPrimes(count).Length}");
		}

		static int[] FindPrimes(int max)
		{
			if (max < 2) return new int[0];
			bool[] notPrime = new bool[max + 1];
			notPrime[0] = true;
			notPrime[1] = true;
			for(int i = 2; i <= max; i++)
			{
				if (notPrime[i]) continue;
				for(int j = i + i; j <= max; j += i)
					notPrime[j] = true;
			}
			return notPrime.Where(x => !x).Select((x,i) => i).ToArray();
		}
	}
}