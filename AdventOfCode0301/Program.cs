using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0301
{
    internal class Program
    {
        /// <summary>
        /// Priority based on position and case sensitivity of alphabet (space in the front because a is priotity 1)
        /// </summary>
        public const string PriorityList = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var priotity = 0;

            foreach (var rucksack in input)
            {
                var compartment1 = rucksack.Substring(0, rucksack.Length / 2);
                var compartment2 = rucksack.Substring(rucksack.Length / 2);

                foreach (var character in compartment1)
                {
                    if (compartment2.Contains(character))
                    {
                        priotity += PriorityList.IndexOf(character);
                        break;
                    }
                }
            }

            // Assert for input1
            //Assert.AreEqual(157, priotity, "Result is not correct");

            Console.WriteLine("Result: " + priotity);
        }
    }
}
