using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace wtf
{
   public class Program
    {
       /* static int factorial(int one)
        {
            
            
        }
        */
            
        static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.GetEncoding(1200);
            int result = 0;
            
                try
                {
                    
                    Console.WriteLine("Ведіть знаменник");
                    int factorial1 = Factorial(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Ведіть чисельник 1");
                    int factorial2 = Factorial(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Ведіть чисельник 2 якщо він є якщо нема наміть 1 ");
                    int factorial3 = Factorial(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Ведіть чисельник 3 якщо він є якщо нема наміть 1");
                    int factorial4 = Factorial(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("Ведіть чисельник 4 якщо він є якщо нема нажміть 1");
                    int factorial5 = Factorial(Convert.ToInt32(Console.ReadLine()));
                     result = factorial1 / (factorial2 * factorial3 * factorial4);
                    Console.WriteLine(result);
                }
                catch {  };
            Console.ReadLine();
        }
        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
         
        
        
    }
    
}
