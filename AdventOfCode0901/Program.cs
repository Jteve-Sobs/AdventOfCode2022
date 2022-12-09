using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0901
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var positions = new List<KeyValuePair<int, int>>();

            var positionTail = new KeyValuePair<int, int>(0, 0);
            var positionHead = new KeyValuePair<int, int>(0, 0);

            foreach (var move in input)
            {
                var direction = move.First();
                var range = Convert.ToInt32(move.Split(' ').Last());

                for (int i = 0; i < range; i++)
                {
                    switch (direction)
                    {
                        case 'R':
                            positionHead = new KeyValuePair<int, int>(positionHead.Key + 1, positionHead.Value);
                            break;
                        case 'L':
                            positionHead = new KeyValuePair<int, int>(positionHead.Key - 1, positionHead.Value);
                            break;
                        case 'U':
                            positionHead = new KeyValuePair<int, int>(positionHead.Key, positionHead.Value + 1);
                            break;
                        case 'D':
                            positionHead = new KeyValuePair<int, int>(positionHead.Key, positionHead.Value - 1);
                            break;
                        default:
                            break;
                    }

                    positionTail = MoveTailToHead(positionHead, positionTail, direction);

                    positions.Add(positionTail);
                }
            }

            var possiblePositions = positions.Distinct().ToList().Count();

            // Assert for input1
            Assert.AreEqual(13, possiblePositions, "Result is not correct");

            Console.WriteLine("Result: " + possiblePositions);
        }

        public static KeyValuePair<int, int> MoveTailToHead(KeyValuePair<int, int> positionHead, KeyValuePair<int, int> positionTail, char direction)
        {
            if (!TailIsAdjacentToHead(positionHead, positionTail))
            {
                if (!TailIsDiagonalToHead(positionHead, positionTail))
                {
                    switch (direction)
                    {
                        case 'R':
                            return new KeyValuePair<int, int>(positionHead.Key - 1, positionHead.Value);
                        case 'L':
                            return new KeyValuePair<int, int>(positionHead.Key + 1, positionHead.Value);
                        case 'U':
                            return new KeyValuePair<int, int>(positionHead.Key, positionHead.Value - 1);
                        case 'D':
                            return new KeyValuePair<int, int>(positionHead.Key, positionHead.Value + 1);
                        default:
                            break;
                    }
                }
            }
            return positionTail;
        }

        public static bool TailIsAdjacentToHead(KeyValuePair<int, int> positionHead, KeyValuePair<int, int> positionTail)
        {
            // Overlapping
            if (positionHead.Equals(positionTail))
            {
                return true;
            }
            // Top
            if (positionHead.Key == positionTail.Key && positionHead.Value == positionTail.Value + 1)
            {
                return true;
            }
            // Right
            if (positionHead.Key == positionTail.Key + 1 && positionHead.Value == positionTail.Value)
            {
                return true;
            }
            // Bottom
            if (positionHead.Key == positionTail.Key && positionHead.Value == positionTail.Value - 1)
            {
                return true;
            }
            // Left
            if (positionHead.Key == positionTail.Key - 1 && positionHead.Value == positionTail.Value)
            {
                return true;
            }
            // Else diagonally or not
            return TailIsDiagonalToHead(positionHead, positionTail);
        }

        public static bool TailIsDiagonalToHead(KeyValuePair<int, int> positionHead, KeyValuePair<int, int> positionTail)
        {
            // Diagonally top right
            if (positionHead.Key == positionTail.Key + 1 && positionHead.Value == positionTail.Value + 1)
            {
                return true;
            }
            // Diagonally bottom right
            if (positionHead.Key == positionTail.Key + 1 && positionHead.Value == positionTail.Value - 1)
            {
                return true;
            }
            // Diagonally bottom left
            if (positionHead.Key == positionTail.Key - 1 && positionHead.Value == positionTail.Value - 1)
            {
                return true;
            }
            // Diagonally top left
            if (positionHead.Key == positionTail.Key - 1 && positionHead.Value == positionTail.Value + 1)
            {
                return true;
            }
            return false;
        }
    }
}
