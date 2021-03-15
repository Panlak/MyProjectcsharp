using System;
using System.Text;

namespace Wiegener_code
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.OutputEncoding = Encoding.GetEncoding(65001);
		



			Console.WriteLine("Enter text");
			string text = Console.ReadLine();

			Console.WriteLine("Ведідь кілість ключів");
			int KeyLength = int.Parse( Console.ReadLine());		
			string[] key = new string[KeyLength];

			Console.WriteLine("Enter Key");
			for (int i = 0; i < key.Length; i++)
			{
				key[i] = Console.ReadLine();				
			}

			string keyresult = "";

			int l = -1;
			while (keyresult.Length < text.Length)
			{
				
				if (l < key.Length - 1)
				{
					l++;
					
				}
				else
				{
					l--;
				}
				keyresult += key[l];
			}		
			keyresult = keyresult.Substring(0, text.Length);



			Console.WriteLine("Encripted");

			int modul = 123;


			int[] Encripted = new int[text.Length];
			int[] Decripted = new int[text.Length];

			for (int i = 0; i < Encripted.Length; i++)
			{
				Encripted[i] = (keyresult.ToCharArray()[i] + text.ToCharArray()[i]) % modul;

				Console.Write((char)Encripted[i] + " ");



			}
			Console.WriteLine();
			Console.WriteLine("Decripted");

			for (int i = 0; i < Decripted.Length; i++)
			{
				Decripted[i] = Encripted[i] + modul - keyresult.ToCharArray()[i];

				Console.Write((char)Decripted[i]);

			}
			Console.WriteLine();



		}
	}
}
