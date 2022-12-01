using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0101
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

            // Assert for input1
            //Assert.AreEqual(24000, results.Max(), "Result is not correct");

            Console.WriteLine("Result: " + results.Max());
        }
    }
}
