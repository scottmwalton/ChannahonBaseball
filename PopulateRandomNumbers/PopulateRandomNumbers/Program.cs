using System;
using System.Collections.Generic;
using System.Threading;

namespace PopulateRandomNumbers
{
	// Original source code from Stack Overflow:
	// https://stackoverflow.com/questions/273313/randomize-a-listt

	class Program
	{
		static void Main()
		{
			// Generate our square list 1 is the top left and 100 is the bottom right
			var squares = new List<int>();
			for(int i = 1; i <=100; i++)
			{
				squares.Add(i);
			}
			//squares.Shuffle();

			// Generate the AFC and NFC numbers 0 - 9
			var afc = new List<int>();
			var nfc = new List<int>();
			for(int i = 0; i < 10; i++)
			{
				afc.Add(i);
				nfc.Add(i);
			}
			afc.Shuffle();
			nfc.Shuffle();

			//using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\code\ChannahonBaseball\PopulateRandomNumbers.csv"))
			{
				// For each NFC number
				for (int i = 0; i < 10; i++)
				{
					// For each AFC number
					for (int j = 0; j < 10; j++)
					{
						//file.WriteLine($"{squares[(i * 10) + j]},{nfc[i]},{afc[j]}");
						Console.WriteLine($"{squares[(i * 10) + j]},{nfc[i]},{afc[j]}");
					}
				}
			}
		}
	}

	public static class ThreadSafeRandom
	{
		[ThreadStatic] private static Random local;
		public static Random ThisThreadsRandom
		{
			get { return local ??= new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)); }
		}
	}

	static class MyExtensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
