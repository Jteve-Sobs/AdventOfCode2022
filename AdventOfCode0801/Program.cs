using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0801
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var result = 0;

            var trees = new List<List<int>>();

            foreach (var line in input)
            {
                trees.Add(new List<int>());
                foreach (var tree in line)
                {
                    trees.Last().Add(Convert.ToInt32(tree.ToString()));
                }
            }

            // Add outer trees
            for (int i = 0; i < trees.Count; i++)
            {
                for (int j = 0; j < trees.ElementAt(i).Count; j++)
                {
                    if (i == 0 || i == trees.Count - 1 || j == 0 || j == trees.ElementAt(i).Count - 1)
                    {
                        result++;
                    }
                }
            }

            // Evalute inner trees
            for (int i = 1; i < trees.Count - 1; i++)
            {
                for (int j = 1; j < trees.ElementAt(i).Count - 1; j++)
                {
                    var currentTree = trees.ElementAt(i).ElementAt(j);

                    // Top
                    var counter = 0;
                    for (int k = 0; k < i; k++)
                    {
                        if (trees.ElementAt(k).ElementAt(j) >= currentTree)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        result++;
                        continue;
                    }

                    // Bottom
                    counter = 0;
                    for (int k = i + 1; k < trees.Count; k++)
                    {
                        if (trees.ElementAt(k).ElementAt(j) >= currentTree)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        result++;
                        continue;
                    }

                    // Left
                    counter = 0;
                    for (int k = 0; k < j; k++)
                    {
                        if (trees.ElementAt(i).ElementAt(k) >= currentTree)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        result++;
                        continue;
                    }

                    // Right
                    counter = 0;
                    for (int k = j + 1; k < trees.First().Count; k++)
                    {
                        if (trees.ElementAt(i).ElementAt(k) >= currentTree)
                        {
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        result++;
                        continue;
                    }
                }
            }

            // Assert for input1
            //Assert.AreEqual(21, result, "Result is not correct");
            
            Console.WriteLine("Result: " + result);
        }
    }
}