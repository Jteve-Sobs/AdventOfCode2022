using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var message = "";

            var stackAndMovesSeparator = input.Where(x => x == "").First();
            var stackAndMovesSeparatorIndex = input.IndexOf(stackAndMovesSeparator);

            var stack = input.GetRange(0, stackAndMovesSeparatorIndex - 1);
            var moves = input.GetRange(stackAndMovesSeparatorIndex + 1, input.Count - stackAndMovesSeparatorIndex - 1);

            // Init stack
            var stackList = new List<List<string>>();
            for (int i = 0; i < stack.First().Length; i += 4)
            {
                stackList.Add(new List<string>());
            }

            foreach (var stackElement in stack)
            {
                var tmpStackElement = stackElement;
                tmpStackElement = tmpStackElement.Replace(" ", "");
                var positionStackElement = 0;
                for (int i = 0; i < stackElement.Length; i += 4)
                {
                    var currentStackElement = $"{stackElement[i]}{stackElement[i + 1]}{stackElement[i + 2]}";
                    // Handle last column (is shorter)
                    if (stackElement.Length > i + 3)
                    {
                        currentStackElement += stackElement[i + 3];
                    }
                    if (currentStackElement == "    " || currentStackElement == "   ")
                    {
                        positionStackElement++;
                    }
                    else
                    {
                        currentStackElement = currentStackElement.Replace(" ", "");
                        currentStackElement = currentStackElement.Replace("[", "");
                        currentStackElement = currentStackElement.Replace("]", "");
                        stackList.ElementAt(positionStackElement).Add(currentStackElement);
                        positionStackElement++;
                    }
                }
            }

            foreach (var move in moves)
            {
                var sanitizedMoveSequence = move.Replace("move ", "");
                sanitizedMoveSequence = sanitizedMoveSequence.Replace("from ", "");
                sanitizedMoveSequence = sanitizedMoveSequence.Replace("to ", "");

                var sanitizedMoves = sanitizedMoveSequence.Split(new string[] { " " }, StringSplitOptions.None);

                var count = Convert.ToInt32(sanitizedMoves.First());
                var from = Convert.ToInt32(sanitizedMoves.ElementAt(1));
                var to = Convert.ToInt32(sanitizedMoves.Last());

                var clipboard = stackList.ElementAt(from - 1).GetRange(0, count);
                stackList.ElementAt(from - 1).RemoveRange(0, count);
                stackList.ElementAt(to - 1).InsertRange(0, clipboard);
            }

            foreach (var stackElement in stackList)
            {
                message += stackElement.First();
            }

            // Assert for input1
            //Assert.AreEqual("MCD", message, "Result is not correct");

            Console.WriteLine("Result: " + message);
        }
    }
}