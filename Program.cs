using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread3
{
	class Program
	{
		static int[,] MartixA;
		static int[,] MartixB;
		static int[,] MartixMultiplied;
		static Random r;

		static void Main(string[] args)
		{
			Console.SetBufferSize(600, 300);

			MartixA = new int[100, 100];
			MartixB = new int[100, 100];

			MartixMultiplied = new int[MartixA.GetLength(0), MartixA.GetLength(1)];
			Task FillMatrixA = new Task(() => FillMatrix(ref MartixA));
			FillMatrixA.Start();
			Task FillMatrixB = new Task(() => FillMatrix(ref MartixB));
			FillMatrixB.Start();

			while (!FillMatrixA.IsCompleted || !FillMatrixB.IsCompleted)
			{
				Console.WriteLine("Ожидание");
				Thread.Sleep(10);
			}

			Console.WriteLine("Матрицы заполнены");

			Parallel.For(0, MartixA.GetLength(0), Multiply);

			Show(MartixMultiplied);

			Console.ReadLine();
		}

		public static void Show(int[,] Matrix)
		{
			int y = Console.CursorTop;

			for (int i = 0; i < Matrix.GetLength(0); i++)
			{
				for (int j = 0; j < Matrix.GetLength(1); j++)
				{
					Console.SetCursorPosition(i * 3, j * 2 + y);
					Console.Write(Matrix[i, j]);
				}
			}
		}

		private static void Multiply(int value)
		{
			for (int i = 0; i < MartixA.GetLength(1); i++)
			{
				if (MartixB.GetLength(1) <= i || MartixB.GetLength(0) <= value)
				{
					MartixMultiplied[value, i] = 0;
				}
				else
				{
					MartixMultiplied[value, i] = MartixA[value, i] * MartixB[value, i];
				}
			}
		}

		private static void FillMatrix(ref int[,] Martix)
		{
			r = new Random();
			for (int i = 0; i < Martix.GetLength(0); i++)
			{
				for (int j = 0; j < Martix.GetLength(1); j++)
				{
					Martix[i,j] = r.Next(10);
				}
			}
			Console.WriteLine("Матрица создана");
		}
	}
}
