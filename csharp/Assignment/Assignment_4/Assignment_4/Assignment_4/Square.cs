using System;
using System.Collections.Generic;
using System.Linq;

class Square
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers :");
        string input = Console.ReadLine();
        List<int> numbers = input.Split(' ').Select(int.Parse).ToList();

        var result = numbers.Select(n => new { Number = n, Square = n * n })
                            .Where(x => x.Square > 20)
                            .ToList();

        foreach (var item in result)
        {
            Console.WriteLine($"Number: {item.Number}, Square: {item.Square}");
        }

        Console.Read();
    }
}
