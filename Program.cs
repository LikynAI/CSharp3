using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace treads2
{
	class Program
	{
		public static object lockObject = new object();
		static void Main(string[] args)
		{
			int n;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out n))
				{
					Thread thread1 = new Thread(new ParameterizedThreadStart(Factorial));
					thread1.Start(n);
					Thread thread2 = new Thread(new ParameterizedThreadStart(Sum));
					thread2.Start(n);
				}
			}
		}

		private static void Factorial(object obj)
		{
			int n = Convert.ToInt32(obj);
			if (n > 0)
			{
				int fact = 1;
				int i = 0;
				while (i < n)
				{
					fact *= ++i;
				}
				Console.WriteLine("Поток 1 " + fact);
			}
			else Console.WriteLine("Поток 1 " + 0);
		}

		private static void Sum(object obj)
		{
			int n = Convert.ToInt32(obj);
			int sum = 0;
			int i = 0;
			while (i <= n)
			{
				sum += i++;
			}
			Console.WriteLine("Поток 2 " + sum);
		}
	}
}
