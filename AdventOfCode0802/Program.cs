using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0802
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

            // Evalute trees
            for (int i = 1; i < trees.Count - 1; i++)
            {
                for (int j = 1; j < trees.ElementAt(i).Count - 1; j++)
                {
                    var currentTree = trees.ElementAt(i).ElementAt(j);

                    var partResults = new List<int>();

                    var tmpResult = 0;
                    // Top
                    for (int k = i - 1; k >= 0; k--)
                    {
                        tmpResult++;
                        if (trees.ElementAt(k).ElementAt(j) >= currentTree)
                        {
                            break;
                        }
                    }
                    partResults.Add(tmpResult);

                    // Bottom
                    tmpResult = 0;
                    for (int k = i + 1; k < trees.Count; k++)
                    {
                        tmpResult++;
                        if (trees.ElementAt(k).ElementAt(j) >= currentTree)
                        {
                            break;
                        }
                    }
                    partResults.Add(tmpResult);

                    // Left
                    tmpResult = 0;
                    for (int k = j - 1; k >= 0; k--)
                    {
                        tmpResult++;
                        if (trees.ElementAt(i).ElementAt(k) >= currentTree)
                        {
                            break;
                        }
                    }
                    partResults.Add(tmpResult);

                    // Right
                    tmpResult = 0;
                    for (int k = j + 1; k < trees.First().Count; k++)
                    {
                        tmpResult++;
                        if (trees.ElementAt(i).ElementAt(k) >= currentTree)
                        {
                            break;
                        }
                    }
                    partResults.Add(tmpResult);

                    // Calculate and evalute result
                    var resultCandidate = 1;
                    foreach (var item in partResults)
                    {
                        resultCandidate *= item;
                    }

                    if (resultCandidate > result)
                    {
                        result = resultCandidate;
                    }
                }
            }

            // Assert for input1
            //Assert.AreEqual(8, result, "Result is not correct");

            Console.WriteLine("Result: " + result);
        }
    }
}