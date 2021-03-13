using System;
using System.Linq;

namespace PlaferCode
{
	class Program
	{
		public static char[] alphabet =
		{
				'a', 'b', 'c','d', 'e',
				'f', 'g',  'h', 'i','k',
				'l','m','n','o','p',
				'q','r','s','t','u' ,
				'v','w','x','y','z'
		};




		static void Main(string[] args)
		{

			Console.WriteLine("Ведіть текст ключ");
			char[] key = getKey(Console.ReadLine()).ToCharArray();


			Console.WriteLine("Ведіть текст який хочете зашифрувати");
			string text = getText(Console.ReadLine());

			int[,] matrix = getMatrix(key);

			int len = text.Length / 2;
			string[] str = new string[len];

			int l = -1;

			for (int i = 0; i < text.Length; i += 2)
			{
				l++;
				if (l < len)
				{

					str[l] = Convert.ToString(text[i]) + Convert.ToString(text[i + 1]);
				}

			}

			int FirstLiter_i = 0, FirstLiter_j = 0;
			int SecondLiter_i = 0, SecondLiter_j = 0;
			string literOne = "", LiterSecond = "";
			string encod = "";
			foreach (string both in str)
			{
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = 0; j < matrix.GetLength(1); j++)
					{

						if (both[0] == (matrix[i, j]))
						{
							FirstLiter_i = i;
							FirstLiter_j = j;

						}

						if (both[1] == (matrix[i, j]))
						{
							SecondLiter_i = i;
							SecondLiter_j = j;

						}
					}

				}

				if (literOne == LiterSecond)
				{



					Console.WriteLine(literOne + FirstLiter_i + FirstLiter_j);
					Console.WriteLine(LiterSecond + SecondLiter_i + SecondLiter_j);
				}

				(literOne, LiterSecond) = IfInSameColumn(matrix, literOne, LiterSecond, FirstLiter_i, SecondLiter_i, FirstLiter_j, SecondLiter_j);
				(literOne, LiterSecond) = IfInSameRow(matrix, literOne, LiterSecond, FirstLiter_i, SecondLiter_i, FirstLiter_j, SecondLiter_j);
				(literOne, LiterSecond) = NOTInSameRowANDcolumn(matrix, literOne, LiterSecond, FirstLiter_i, SecondLiter_i, FirstLiter_j, SecondLiter_j);



				encod += ((char)int.Parse(literOne)).ToString() + ((char)int.Parse(LiterSecond)).ToString();


				Console.WriteLine(encod);

			}
			Console.WriteLine("Матрица плейфера");
			Console.WriteLine("---------");
			print(matrix);
			Console.WriteLine("---------");

			Console.WriteLine(encod.ToLower());


		}

		public static string getText(string text)
		{

			text = text.ToLower();
			text = text.Replace("j", "i");
			for (int i = 0; i < text.Length; i++)
			{
				if (!alphabet.Contains(text.ToCharArray()[i]))
				{
					text = text.Replace(text[i], ' ');
				}

			}
			text = text.Replace(" ", "");

			if (text.Length % 2 != 0)
				text += "x";

			Console.WriteLine(text);
			return text;
		}

		public static string getKey(string key)
		{
			key = key.ToLower();
			key = key.Replace("j", "i");

			for (int i = 0; i < key.Length; i++)
			{
				if (!alphabet.Contains(key.ToCharArray()[i]))
				{
					key = key.Replace(key[i], ' '); ;
				}

			}
			key = new string(key.Distinct().ToArray());
			key = key.Replace(" ", "");


			Console.WriteLine(key);

			return key;

		}
		public static (string, string) NOTInSameRowANDcolumn(int[,] matrix, string literOne, string LiterSecond, int FirstLiter_i, int SecondLiter_i, int FirstLiter_j, int SecondLiter_j)
		{
			if (FirstLiter_i != SecondLiter_i && FirstLiter_j != SecondLiter_j)
			{

				literOne = Convert.ToString(matrix[FirstLiter_i, SecondLiter_j]);
				LiterSecond = Convert.ToString(matrix[SecondLiter_i, FirstLiter_j]);
			}

			return (literOne, LiterSecond);
		}
		public static (string, string) IfInSameRow(int[,] matrix, string literOne, string LiterSecond, int FirstLiter_i, int SecondLiter_i, int FirstLiter_j, int SecondLiter_j)
		{
			if (FirstLiter_i == SecondLiter_i)
			{
				if (FirstLiter_j == 4)
				{
					literOne = Convert.ToString(matrix[FirstLiter_i, 0]);
				}

				else
				{
					literOne = Convert.ToString(matrix[FirstLiter_i, FirstLiter_j + 1]);
				}

				if (SecondLiter_j == 4)
				{
					LiterSecond = Convert.ToString(matrix[SecondLiter_i, 0]);
				}

				else
				{
					LiterSecond = Convert.ToString(matrix[SecondLiter_i, SecondLiter_j + 1]);
				}

			}

			return (literOne, LiterSecond);
		}
		public static (string, string) IfInSameColumn(int[,] matrix, string literOne, string LiterSecond, int FirstLiter_i, int SecondLiter_i, int FirstLiter_j, int SecondLiter_j)
		{
			if (FirstLiter_j == SecondLiter_j)
			{
				if (FirstLiter_i == 4)
				{
					literOne = Convert.ToString(matrix[0, FirstLiter_j]);
				}
				else
				{
					literOne = Convert.ToString(matrix[FirstLiter_i + 1, FirstLiter_j]);
				}

				if (SecondLiter_i == 4)
				{
					LiterSecond = Convert.ToString(matrix[0, SecondLiter_j]);
				}

				else
				{
					LiterSecond = Convert.ToString(matrix[SecondLiter_i + 1, SecondLiter_j]);
				}
			}


			return (literOne, LiterSecond);
		}
		public static void print(int[,] arrey)
		{

			for (int i = 0; i < arrey.GetLength(0); i++)
			{
				for (int j = 0; j < arrey.GetLength(1); j++)
				{
					Console.Write((char)arrey[i, j] + " ");
				}
				Console.WriteLine();
			}

		}

		public static int[,] getMatrix(char[] key)
		{
			int b = -1;
			int[] result = new int[alphabet.Length + key.Length];


			int a = 0;
			if (key.Contains('a'))
				a = 0;
			else
				a = -1;


			int[,] matrix = new int[5, 5];
			for (int i = 0; i < result.Length; i++)
			{
				if (b < key.Length - 1)
				{
					b++;
					result[i] = key[b];
				}
				else
				{
					if (a < alphabet.Length - 1)
						a++;
					if (Array.IndexOf(key, alphabet[a]) > -1)
					{
						continue;
					}
					result[i] = alphabet[a];
				}

			}


			result = result.Where(val => val != 0).ToArray();

			int g = -1;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{

				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (g < result.Length - 1)
					{
						g++;
					}
					matrix[i, j] = result[g];

				}

			}
			return matrix;
		}

	}

}



