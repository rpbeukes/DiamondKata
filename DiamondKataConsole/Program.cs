using DiamondKataLib;
using System;

namespace DiamondKataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input != "EXIT")
            {
                Console.WriteLine("Print Diamond Pattern for: ");
                input = Console.ReadLine().ToUpper();
                if (input == "CLS")
                {
                    Console.Clear();
                }
                else if (input.Length >= 1 && input != "EXIT")
                {
                    var chr = input.Substring(0, 1).ToCharArray()[0];
                    if (chr >= 'A' && chr <= 'Z')
                    {
                        //print
                        var array = new DiamondEngine(chr).CreateArray();
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            for (int k = 0; k < array.GetLength(1); k++)
                            {
                                var printVal = array[i, k].ToString();
                                Console.Write(string.IsNullOrEmpty(printVal) ? "" : printVal);
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

