using System;
using System.Linq;
using System.Collections.Generic;

namespace MissingNumberFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your numbers (separated by spaces):");
            
            try
            {
                string input = Console.ReadLine();
                int[] numbers = input.Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToArray();
                
                Console.WriteLine($"Your array: [{string.Join(", ", numbers)}]");
                ValidateArray(numbers);
                int missingNumber = FindMissingNumber(numbers);
                Console.WriteLine($"Missing number: {missingNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        static void ValidateArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Array cannot be empty");
                
            if (!numbers.Contains(0))
                throw new ArgumentException("Array must contain 0");
                
            if (numbers.Length != numbers.Distinct().Count())
                throw new ArgumentException("Array must contain distinct numbers");
                
            int n = numbers.Length;
            if (numbers.Any(num => num < 0 || num > n))
                throw new ArgumentException($"Invalid numbers detected");
        }
        
        static int FindMissingNumber(int[] numbers)
        {
            HashSet<int> numSet = new HashSet<int>(numbers);
            
            for (int i = 0; i <= numbers.Length; i++)
            {
                if (!numSet.Contains(i))
                    return i;
            }
            
            throw new InvalidOperationException("No missing number was found");
        }
    }
}