using System;
using System.Collections.Generic;

namespace Primes
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 1_000_000;
			List<int> primes = FindPrimes(count);
			Console.WriteLine($"Count of first {count} primes: {primes.Count}");
			foreach (var prime in primes)
				Console.WriteLine(prime);
		}

		static List<int> FindPrimes(int max)
		{
			List<int> primes = new List<int>();
			if (max < 2) return primes;

			bool[] notPrime = new bool[max + 1];
			notPrime[0] = true;
			notPrime[1] = true;

			for(int i = 2; i <= max; i++)
			{
				if (notPrime[i]) continue;
				primes.Add(i);
				for(int j = i + i; j <= max; j += i)
					notPrime[j] = true;
			}

			return primes;
		}
	}
}