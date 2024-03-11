using System;
using System.Collections.Generic;
using System.Linq;

class Letter

{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter words :");
        string input = Console.ReadLine();
        List<string> words = input.Split(' ').ToList();


        var result = words.Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) && word.EndsWith("m", StringComparison.OrdinalIgnoreCase));

        if (result.Count() > 2 || result.Count() > 3)
        {
            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine("No words are starting with 'a' and ending with 'm'.");
        }

        Console.Read();
    }
}
