using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0402
{
    internal class Elf
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Length { get; private set; }
        public Elf(string start, string end)
        {
            this.Start = Convert.ToInt32(start);
            this.End = Convert.ToInt32(end);
            this.Length = this.End - this.Start + 1; // Length is inlcuded start and end
        }

        public override string ToString()
        {
            return $"{this.Start} - {this.End} ({this.Length})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var doubleAssignments = 0;

            foreach (var pair in input)
            {
                var doubleAssignmentProcessed = false;
                var elvesPair = new List<Elf>();
                var elves = pair.Split(',');

                foreach (var elf in elves)
                {
                    var range = elf.Split('-');
                    elvesPair.Add(new Elf(range.First(), range.Last()));
                }

                for (int i = elvesPair.First().Start; i <= elvesPair.First().End; i++)
                {
                    if (doubleAssignmentProcessed)
                    {
                        break;
                    }
                    for (int j = elvesPair.Last().Start; j <= elvesPair.Last().End; j++)
                    {
                        if (i == j)
                        {
                            doubleAssignmentProcessed = true;
                            doubleAssignments++;
                            break;
                        }
                    }
                }
            }

            // Assert for input1
            //Assert.AreEqual(4, doubleAssignments, "Result is not correct");

            Console.WriteLine("Result: " + doubleAssignments);
        }
    }
}
