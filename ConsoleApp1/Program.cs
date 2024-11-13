using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            string key;
            Console.WriteLine("Введите слово:");
            string input = Console.ReadLine();
            if (input == null) {
                Console.WriteLine("Слово не может быть пустым");
                Environment.Exit(0);
            }
            Console.WriteLine("Выберите способ подсчета символов:");
            Console.WriteLine("1 - с помощью словаря");
            Console.WriteLine("2 - с помощью LINQ");
            Console.WriteLine("3 - вывести оба метода");
            key = Console.ReadLine();
            if (key == "1") { Uniq_value(input.ToLower()); }
            else if (key == "2") { Uniq_value_LINQ(input.ToLower()); }
            else if (key == "3")
            {
                Console.WriteLine("с помощью словаря");
                Uniq_value(input.ToLower());
                Console.WriteLine("с помощью LINQ");
                Uniq_value_LINQ(input.ToLower());
            }
        }
        public static void Uniq_value(string input)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();


            foreach (char c in input)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
            foreach (var k in charCount)
            {
                Console.WriteLine($"{k.Key}: {k.Value}");
            }
        }
        public static void Uniq_value_LINQ(string input)
        {
            var charCount = input.GroupBy(c => c)
                           .Select(g => new { Character = g.Key, Count = g.Count() })
                           .ToList();

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Character}: {item.Count}");
            }
        }
    }
}
