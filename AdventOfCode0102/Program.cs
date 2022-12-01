using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0102
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            input.Add(""); // Add line at the end to add last result to list

            var results = new List<int>();

            var tmp = 0;

            foreach (var elfCalories in input)
            {
                if (elfCalories == "")
                {
                    results.Add(tmp);
                    tmp = 0;
                    continue;
                }

                tmp += Convert.ToInt32(elfCalories);
            }

            var endresults = new List<int>() { 0, 0, 0 };
            foreach (var result in results)
            {
                // Change smallest result with larger result
                if (endresults.Min() < result)
                {
                    endresults.Remove(endresults.Min());
                    endresults.Add(result);
                }
            }

            // Assert for input1
            Assert.AreEqual(45000, endresults.Sum(), "Result is not correct");

            Console.WriteLine("Result: " + endresults.Sum());
        }
    }
}
