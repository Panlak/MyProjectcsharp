using System;
using System.Collections.Generic;
using System.Linq;
namespace Arithmetic_coding
{



	public class Node
	{
		public char Symbol { get; set; }
		public double Low { get; set; }
		public double High { get; set; }
		public double Range { get; set; }
		public int Frequency { get; set; }
	}
	class Program
	{
		public static List<Node> nodes = new List<Node>();
		public static Dictionary<char, int> keyAndFrequencies = new Dictionary<char, int>();

		static void Main(string[] args)
		{
			string word = "India".ToLower();
			

			Console.WriteLine($"Word = {word}");
			Console.WriteLine();

			

			
			for (int i = 0; i < word.Length; i++)
			{
				if(!keyAndFrequencies.ContainsKey(word[i]))
				{
					keyAndFrequencies.Add(word[i], 0);
				}
				keyAndFrequencies[word[i]]++;
			}

			foreach (KeyValuePair<char, int> symbol in keyAndFrequencies)
				nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });

			double low = 0;
			int cout = 0;
			foreach (Node node in nodes)
			{
				
				node.Range = Math.Round(((double)(node.Frequency) / (word.Length)), 1);
				node.Low = Math.Round(low, 3);

				if (4 == cout)
					node.High = 1;
				else
					node.High = low + node.Range;
				node.High = Math.Round(node.High, 3);
				low += node.Range;
				

				
				Console.WriteLine($"Symbol ={node.Symbol}\nProbability = {node.Range}\nLow-bound ={node.Low }\nUp-bound = { node.High}\n----------");
				cout++;
			}

			nodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();


			Console.WriteLine("Encoded");
			List<Node> allNodes = new List<Node>();
			nodes.Reverse();
			for (int i = 0; i < word.Length; i++)
			{
				for (int j = 0; j < nodes.Count; j++)
				{
					if (word[i] == nodes[j].Symbol)
					{
						allNodes.Add(new Node() { Symbol = nodes[j].Symbol, Low = nodes[j].Low, High = nodes[j].High });
					}	
				}
			}
			
			for (int i = 1; i < allNodes.Count; i++)
			{
				for (int j = 0; j < nodes.Count; j++)
				{
					if (allNodes[i].Symbol == nodes[j].Symbol)
					{
						allNodes[i].High =  allNodes[i - 1].Low + ((allNodes[i - 1].High - allNodes[i - 1].Low) * nodes[j].High);
						allNodes[i].Low =  allNodes[i - 1].Low + ((allNodes[i - 1].High - allNodes[i - 1].Low) * nodes[j].Low);


						Console.WriteLine($"{allNodes[i].Symbol} = Hight = {allNodes[i].High} Low = {allNodes[i].Low}");
					}
				}
			}
			Console.WriteLine($"Encoded message = {allNodes[allNodes.Count - 1].Low}");
			Console.WriteLine("Decode");
			string decodedNodes = Decode(allNodes, word.Length);	
			Console.WriteLine($"Decode Mesage ==> {decodedNodes}");
		}

		public static string Decode(List<Node> allNodes, int count)
		{
			string decode = "";
			double code = allNodes[allNodes.Count -1].Low;
			int symbolsCount = 0;

			while (true)
			{
				for (int i = 0; i < nodes.Count ; i++)
				{
					if (code >= nodes[i].Low && code < nodes[i].High)
					{
						decode += nodes[i].Symbol;
						code = Math.Round((code - nodes[i].Low) / (nodes[i].High - nodes[i].Low), 8);

						Console.WriteLine(code);
						symbolsCount++;
						if (symbolsCount == count)
							return decode;
					}
				}
			}
		}
	}
}
