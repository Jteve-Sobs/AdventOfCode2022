using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();
            var score = 0;

            foreach (var game in input)
            {
                var myChoice = game.Last();

                // Evaluate game outcome
                switch (game.First())
                {
                    // Rock
                    case 'A':
                        switch (myChoice)
                        {
                            // Rock
                            case 'X':
                                score += 3;
                                break;
                            // Paper
                            case 'Y':
                                score += 6;
                                break;
                            // Scissors
                            case 'Z':
                                score += 0;
                                break;
                            default:
                                break;
                        }
                        break;
                    // Paper
                    case 'B':
                        switch (myChoice)
                        {
                            // Rock
                            case 'X':
                                score += 0;
                                break;
                            // Paper
                            case 'Y':
                                score += 3;
                                break;
                            // Scissors
                            case 'Z':
                                score += 6;
                                break;
                            default:
                                break;
                        }
                        break;
                    // Scissors
                    case 'C':
                        switch (myChoice)
                        {
                            // Rock
                            case 'X':
                                score += 6;
                                break;
                            // Paper
                            case 'Y':
                                score += 0;
                                break;
                            // Scissors
                            case 'Z':
                                score += 3;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                // Score based on input
                switch (myChoice)
                {
                    // Rock
                    case 'X':
                        score += 1;
                        break;
                    // Paper
                    case 'Y':
                        score += 2;
                        break;
                    // Scissors
                    case 'Z':
                        score += 3;
                        break;
                    default:
                        break;
                }
            }

            // Assert for input1
            //Assert.AreEqual(15, score, "Result is not correct");

            Console.WriteLine("Result: " + score);
        }
    }
}
