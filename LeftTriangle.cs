using System;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arrey = new int[8, 8];
            long dobutok = 1;           
            Random rand = new Random();
            for (int i = 0; i < arrey.GetLength(0); i++)
            {
                for (int j = 0; j < arrey.GetLength(1); j++)
                {
                    arrey[i, j] = rand.Next(1, 10);
                    Console.Write(arrey[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();        
            for (int i = 0; i < arrey.GetLength(0); i++)
            {              
                for (int j = arrey.GetLength(1)-i; j < arrey.GetLength(1); j++)
                {
                    if (j < i)
                    {
                        continue;
                    }
                    dobutok *= arrey[i, j];
                    Console.Write(arrey[i, j]+"\t");   
                }               
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Добуток = {dobutok}");           
        }
    }
}
