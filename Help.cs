char[] alphabet =
			{
				'a', 'b', 'c','d', 'e',
				'f', 'g',  'h', 'i','k',
				'l','m','n','o','p',
				'q','r','s','t','u' ,
				'v','w','x','y','z'
			};
			char[] key = "comander".ToCharArray();
			string s = "";
			int b = -1;
			int[,] result = new int[5, 5];
			int a = 0;
			for (int i = 0; i < result.GetLength(0); i++)
			{
				for (int j = 0; j < result.GetLength(1); j++)
				{
					if (b < key.Length - 1)
					{
						b++;
						result[i, j] = key[b];
					}
					else
					{
						a++;
						if (Array.IndexOf(key, alphabet[a]) > -1)
						{
							continue;
						}
						result[i, j] = alphabet[a];
					}
					


					Console.Write((char)result[i, j] + " ");
				}
				Console.WriteLine();
			}