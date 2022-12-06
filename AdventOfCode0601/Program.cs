using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0601
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var marker = 0;

            var charactersUsed = new List<char>();

            foreach (var character in input.First())
            {
                marker++;
                charactersUsed.Add(character);
                if (charactersUsed.Count == 4)
                {
                    if (charactersUsed.Distinct().Count() == 4)
                    {
                        break;
                    }
                    charactersUsed.RemoveAt(0);
                }
            }

            // Assert for input1
            //Assert.AreEqual(10, marker, "Result is not correct");

            Console.WriteLine("Result: " + marker);
        }
    }
}
