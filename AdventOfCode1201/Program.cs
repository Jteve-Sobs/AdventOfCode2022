using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            //var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            // current position(S)
            // the location that should get the best signal(E)

            var steps = 0;


            // Assert for input1
            Assert.AreEqual(31, steps, "Result is not correct");

            Console.WriteLine("Result: " + steps);
        }
    }
}
