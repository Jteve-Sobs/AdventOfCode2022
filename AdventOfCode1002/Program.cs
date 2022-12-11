using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1002
{
    internal class Program
    {
        public static List<char> Screen { get; set; }

        private static int m_CycleCounter;
        public static int CycleCounter
        {
            get
            {
                return m_CycleCounter;
            }
            set
            {
                m_CycleCounter = value;

                if (m_CycleCounter == 20
                    || m_CycleCounter == 60
                    || m_CycleCounter == 100
                    || m_CycleCounter == 140
                    || m_CycleCounter == 180
                    || m_CycleCounter == 220
                )
                {
                    SignalStrength += m_CycleCounter * Register;
                }
            }
        }
        public static int SignalStrength = 0;
        public static int Register = 1;

        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            CycleCounter = 0;
            Screen = new List<char>();

            foreach (var command in input)
            {
                if (command == "noop")
                {
                    DrawScreen();
                    CycleCounter++;
                }
                else if (command.StartsWith("addx "))
                {
                    var value = Convert.ToInt32(command.Split(' ').Last());

                    DrawScreen();
                    CycleCounter++;
                    DrawScreen();
                    CycleCounter++;

                    Register += value;
                }
            }

            var screen = String.Join("", Screen);

            var expectedScreen = "##..##..##..##..##..##..##..##..##..##.." +
                                 "###...###...###...###...###...###...###." +
                                 "####....####....####....####....####...." +
                                 "#####.....#####.....#####.....#####....." +
                                 "######......######......######......####" +
                                 "#######.......#######.......#######.....";

            // Assert for input1
            //Assert.AreEqual(expectedScreen, screen, "Result is not correct");

            Console.WriteLine("Result: ");
            for (int i = 0; i < screen.Length; i++)
            {
                if (i % 40 == 0)
                {
                    Console.Write("\r\n");
                }
                Console.Write(screen.ElementAt(i));
            }

            ;
        }

        public static void DrawScreen()
        {
            var symbol = ' ';
            if (CycleCounter % 40 == Register - 1
                || CycleCounter % 40 == Register
                || CycleCounter % 40 == Register + 1
            )
            {
                symbol = '#';
            }
            else
            {
                symbol = '.';
            }

            Screen.Add(symbol);
        }
    }
}
