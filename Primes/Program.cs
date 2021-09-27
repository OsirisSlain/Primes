using System;
using System.Collections;
using System.Collections.Generic;

namespace Primes
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 1_000;
			var ePrimes = Erastothenes(count);
			var primes = new List<int>();
			for (var i = 0; i < ePrimes.Count; i++)
				if (ePrimes[i]) primes.Add(i);
			Console.WriteLine(string.Join(", ", primes));
		}

		static BitArray Erastothenes(int max)
		{
			var primes = new BitArray(max + 1);
			primes.SetAll(true);
			primes[0] = false;
			primes[1] = false;

			for (var i = 2; i <= max; i++)
				if (primes[i])
					for (var j = i + i; j <= max; j += i)
						primes[j] = false;
			return primes;
		}
	}
}