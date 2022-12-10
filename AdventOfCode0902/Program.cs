using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0902
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1_2.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var positions = new List<KeyValuePair<int, int>>();
            
            var directions = new List<char>(); 

            var positionHead = new KeyValuePair<int, int>(0, 0);
            var positionTail1 = new KeyValuePair<int, int>(0, 0);
            var positionTail2 = new KeyValuePair<int, int>(0, 0);
            var positionTail3 = new KeyValuePair<int, int>(0, 0);
            var positionTail4 = new KeyValuePair<int, int>(0, 0);
            var positionTail5 = new KeyValuePair<int, int>(0, 0);
            var positionTail6 = new KeyValuePair<int, int>(0, 0);
            var positionTail7 = new KeyValuePair<int, int>(0, 0);
            var positionTail8 = new KeyValuePair<int, int>(0, 0);
            var positionTail9 = new KeyValuePair<int, int>(0, 0);

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

                    directions.Add(direction);

                    positionTail1 = MoveTailToHead(positionHead, positionTail1, directions.ElementAt(Math.Max(0, directions.Count - 1)));
                    positionTail2 = MoveTailToHead(positionTail1, positionTail2, directions.ElementAt(Math.Max(0, directions.Count - 2)));
                    positionTail3 = MoveTailToHead(positionTail2, positionTail3, directions.ElementAt(Math.Max(0, directions.Count - 3)));
                    positionTail4 = MoveTailToHead(positionTail3, positionTail4, directions.ElementAt(Math.Max(0, directions.Count - 4)));
                    positionTail5 = MoveTailToHead(positionTail4, positionTail5, directions.ElementAt(Math.Max(0, directions.Count - 5)));
                    positionTail6 = MoveTailToHead(positionTail5, positionTail6, directions.ElementAt(Math.Max(0, directions.Count - 6)));
                    positionTail7 = MoveTailToHead(positionTail6, positionTail7, directions.ElementAt(Math.Max(0, directions.Count - 7)));
                    positionTail8 = MoveTailToHead(positionTail7, positionTail8, directions.ElementAt(Math.Max(0, directions.Count - 8)));
                    positionTail9 = MoveTailToHead(positionTail8, positionTail9, directions.ElementAt(Math.Max(0, directions.Count - 9)));

                    positions.Add(positionTail9);
                }
            }

            var possiblePositions = positions.Distinct().ToList().Count();

            // Assert for input1
            Assert.AreEqual(36, possiblePositions, "Result is not correct");

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

            //if (TailIsAdjacentToHead(positionHead, positionTail))
            //{
            //    return positionTail;
            //}
            //var offsetX = FindSign(positionHead.Key - positionTail.Key);
            //var offsetY = FindSign(positionHead.Value - positionTail.Value);

            //return new KeyValuePair<int, int>(positionTail.Key + offsetX, positionTail.Value + offsetY);
        }

        public static int FindSign(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
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
