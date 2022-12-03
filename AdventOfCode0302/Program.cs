using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0302
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

            for (int i = 0; i < input.Count; i += 3)
            {
                string rucksack = input[i];
                var rucksack1 = input[i + 1];
                var rucksack2 = input[i + 2];

                foreach (var character in rucksack)
                {
                    if (rucksack1.Contains(character) && rucksack2.Contains(character))
                    {
                        priotity += PriorityList.IndexOf(character);
                        break;
                    }
                }
            }

            // Assert for input1
            //Assert.AreEqual(70, priotity, "Result is not correct");

            Console.WriteLine("Result: " + priotity);
        }
    }
}
