static void Main(string[] args)
		{
			Random rand = new Random();


			// 98 - 123 букви алфавіту
			// a b c d e f g h i j k l m n o p q r s t u v w x y z

			char[] alphabet =
			{
				'a', 'b', 'c','d', 'e',
				'f', 'g',  'h', 'i','k',
				'l','m','n','o','p',
				'q','r','s','t','u' ,
				'v','w','x','y','z'
			};
			char[] key = "comander".ToCharArray();
			
			int b = -1;
			int[] result = new int[alphabet.Length + key.Length - 1];
			int a = -1;
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
					a++;
					if (Array.IndexOf(key, alphabet[a]) > 0)
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
			print(matrix);


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
	}