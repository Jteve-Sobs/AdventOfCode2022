using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode1102
{
    public static class StringExtension
    {
        public static string TrimStart(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }
    }

    internal class Monkey
    {
        public int ID
        { get; set; }
        public void SetID(string line)
        {
            ID = Convert.ToInt32(Regex.Match(line, @"\d").Value);
        }

        public List<long> Items
        { get; set; }
        public void SetItems(string line)
        {
            Items = new List<long>();
            var items = Regex.Matches(line, @"\d+");

            for (int i = 0; i < items.Count; i++)
            {
                Items.Add(Convert.ToInt64(items[i].Value));
            }
        }

        public char Operation
        { get; set; }
        public string OperationValue
        { get; set; }
        public void SetOperation(string line)
        {
            line = line.Trim();
            line = line.TrimStart("Operation: new = old ");
            Operation = line.First();
            line = line.TrimStart(Operation);
            line = line.Trim();
            OperationValue = line;
        }

        public int Test
        { get; set; }
        public void SetTest(string line)
        {
            Test = Convert.ToInt32(line.Trim().TrimStart("Test: divisible by "));
        }

        public int TestTrue
        { get; set; }
        public void SetTestTrue(string line)
        {
            TestTrue = Convert.ToInt32(line.Trim().TrimStart("If true: throw to monkey "));
        }

        public int TestFalse
        { get; set; }
        public void SetTestFalse(string line)
        {
            TestFalse = Convert.ToInt32(line.Trim().TrimStart("If false: throw to monkey "));
        }

        public int InspectionCount
        { get; set; }

        public Monkey(int id, List<long> items, char operation, int test, int testTrue, int testFalse)
        {
            ID = id;
            Items = items;
            Operation = operation;
            Test = test;
            TestTrue = testTrue;
            TestFalse = testFalse;
        }

        public Monkey() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var monkeys = new List<Monkey>();

            for (int i = 0; i < input.Count; i += 7)
            {
                var tmpMonkey = new Monkey();
                tmpMonkey.SetID(input[i]);
                tmpMonkey.SetItems(input[i + 1]);
                tmpMonkey.SetOperation(input[i + 2]);
                tmpMonkey.SetTest(input[i + 3]);
                tmpMonkey.SetTestTrue(input[i + 4]);
                tmpMonkey.SetTestFalse(input[i + 5]);

                monkeys.Add(tmpMonkey);
            }

            var globalModulo = monkeys.Select(m => m.Test).Aggregate((m, i) => m * i);

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    // Ealuate worry level of items
                    for (int j = 0; j < monkey.Items.Count; j++)
                    {
                        monkey.Items[j] %= globalModulo;
                        if (monkey.Operation == '+')
                        {
                            monkey.Items[j] += (Convert.ToInt32(monkey.OperationValue));
                        }
                        else if (monkey.Operation == '*')
                        {
                            if (monkey.OperationValue == "old")
                            {
                                long square = (monkey.Items[j] * monkey.Items[j]);
                                monkey.Items[j] = square;
                            }
                            else
                            {
                                monkey.Items[j] *= (Convert.ToInt32(monkey.OperationValue));
                            }
                        }

                        monkey.InspectionCount++;
                    }

                    // Throw items
                    for (int j = monkey.Items.Count - 1; j >= 0; j--)
                    {
                        if (monkey.Items[j] % monkey.Test == 0)
                        {
                            monkeys.ElementAt(monkey.TestTrue).Items.Add(monkey.Items[j]);
                        }
                        else
                        {
                            monkeys.ElementAt(monkey.TestFalse).Items.Add(monkey.Items[j]);
                        }
                        monkey.Items.RemoveAt(j);
                    }
                }
            }

            monkeys = monkeys.OrderBy(x => x.InspectionCount).ToList().GetRange(monkeys.Count - 2, 2);

            long monkeyBusiness = 1;

            foreach (var monkey in monkeys)
            {
                monkeyBusiness *= monkey.InspectionCount;
            }

            // Assert for input1
            //Assert.AreEqual(2713310158, monkeyBusiness, "Result is not correct");

            Console.WriteLine("Result: " + monkeyBusiness);
        }
    }
}
