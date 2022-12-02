using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0202
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
                var outcome = game.Last();

                var myChoice = "";

                // Evaluate game outcome
                switch (game.First())
                {
                    // Rock
                    case 'A':
                        switch (outcome)
                        {
                            // Lose
                            case 'X':
                                myChoice = "Scissors";
                                score += 0;
                                break;
                            // Draw
                            case 'Y':
                                myChoice = "Rock";
                                score += 3;
                                break;
                            // Win
                            case 'Z':
                                myChoice = "Paper";
                                score += 6;
                                break;
                            default:
                                break;
                        }
                        break;
                    // Paper
                    case 'B':
                        switch (outcome)
                        {
                            // Lose
                            case 'X':
                                myChoice = "Rock";
                                score += 0;
                                break;
                            // Draw
                            case 'Y':
                                myChoice = "Paper";
                                score += 3;
                                break;
                            // Win
                            case 'Z':
                                myChoice = "Scissors";
                                score += 6;
                                break;
                            default:
                                break;
                        }
                        break;
                    // Scissors
                    case 'C':
                        switch (outcome)
                        {
                            // Lose
                            case 'X':
                                myChoice = "Paper";
                                score += 0;
                                break;
                            // Draw
                            case 'Y':
                                myChoice = "Scissors";
                                score += 3;
                                break;
                            // Win
                            case 'Z':
                                myChoice = "Rock";
                                score += 6;
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
                    case "Rock":
                        score += 1;
                        break;
                    // Paper
                    case "Paper":
                        score += 2;
                        break;
                    // Scissors
                    case "Scissors":
                        score += 3;
                        break;
                    default:
                        break;
                }
            }

            // Assert for input1
            //Assert.AreEqual(12, score, "Result is not correct");

            Console.WriteLine("Result: " + score);
        }
    }
}
