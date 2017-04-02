using System;
using System.Linq;

namespace Primes
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 1_000_000;
			int[] primes = FindPrimes(count);
			Console.WriteLine($"Count of first {count} primes: {primes.Length}");
			foreach (var prime in primes)
				Console.WriteLine(prime);
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
			return notPrime.Select((x,i) => i)
				.Where(x => !notPrime[x]).ToArray();
		}
	}
}