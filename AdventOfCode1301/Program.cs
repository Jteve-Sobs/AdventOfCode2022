using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1301
{
    public static class StringExtension
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }
    }

    public class Element
    {
        public List<int> Elements { get; set; }

        public List<Element> Subelements { get; set; }

        public Element(string input)
        {
            Elements = new List<int>();

            Subelements = new List<Element>();

            var tmpElements = new List<int>();
            var tmpSubelements = new List<Element>();

            var starts = input.AllIndexesOf("[").ToList();
            var ends = input.AllIndexesOf("]").ToList();

            foreach (var start in starts)
            {

            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            //var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            input = input.Where(x => x != "").ToList();

            for (int i = 0; i < input.Count; i += 2)
            {
                var firstElement = input[i];
                var secondElement = input[i + 1];

                var test = Newtonsoft.Json.JsonConvert.DeserializeObject(firstElement);
                var test4 = Newtonsoft.Json.JsonConvert.DeserializeObject(secondElement);


                var test2 = new Element(firstElement);
                var test3 = new Element(secondElement);
                
                ;

            }



            var indeizesSum = 0;

            // Assert for input1
            Assert.AreEqual(13, indeizesSum, "Result is not correct");

            Console.WriteLine("Result: " + indeizesSum);
        }
    }
}
