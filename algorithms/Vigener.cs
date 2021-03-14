using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Wiegener_code
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.OutputEncoding = Encoding.GetEncoding(65001);


			Console.WriteLine("Enter Key");
			string key = Console.ReadLine();
			Console.WriteLine("Enter text");
			string text = Console.ReadLine();


			Console.WriteLine("Encripted");
			
			int modul = 123;
			while(key.Length < text.Length)
			{
				key += key;
			}	
			key = key.Substring(0, text.Length);

			int[] Encripted = new int[text.Length];
			int[] Decripted = new int[text.Length];
			
			for (int i = 0; i < Encripted.Length; i++)
			{
				Encripted[i] = (key.ToCharArray()[i] + text.ToCharArray()[i]) % modul;

				Console.Write((char)Encripted[i] + " ");

				
				
			}
			Console.WriteLine();
			Console.WriteLine("Decripted");
			
			for (int i = 0; i < Decripted.Length; i++)
			{
				Decripted[i] = Encripted[i] + modul - key[i] ;

				Console.Write((char)Decripted[i]);

			}
			Console.WriteLine();


			
		}
	}
}
