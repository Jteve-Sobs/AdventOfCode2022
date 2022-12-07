using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0701
{
    internal class Directory
    {
        public string Name { get; set; }
        public List<string> SubDirectories { get; set; }
        public int Size { get; set; }

        public Directory(string name)
        {
            Name = name;
            SubDirectories = new List<string>();
        }

        public override string ToString()
        {
            var value = $"{Name} Size: {Size} Subdirectories: {SubDirectories.Count}";
            return value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\input1.txt").ToList();
            var input = File.ReadAllLines("..\\..\\input2.txt").ToList();

            var sumOfTotalSizes = 0;
            var directories = new List<Directory>();
            var directoryHistory = new List<string>();

            foreach (var line in input)
            {
                if (line.StartsWith("$ cd .."))
                {
                    directoryHistory.RemoveAt(directoryHistory.Count - 1);
                }
                else if (line.StartsWith("$ cd "))
                {
                    var nameDirectory = line.Substring("$ cd ".Length);
                    directoryHistory.Add(nameDirectory);

                    directories.Add(new Directory(String.Join(";", directoryHistory.ToArray())));
                }
                else if (line == "$ ls")
                {

                }
                else if (line.StartsWith("dir "))
                {
                    // Not needed because of use of directoryHistory
                    // Add subdirectory to each directory in history
                    for (int i = 0; i < directoryHistory.Count; i++)
                    {
                        var dir = String.Join(";", directoryHistory.GetRange(0, i + 1).ToArray());

                        var subdirectoryAlreadyLogged = directories
                            .Where(x => x.Name == dir).First()
                            .SubDirectories
                            .Contains(dir);

                        if (subdirectoryAlreadyLogged)
                        {
                            continue;
                        }

                        directories
                            .Where(x => x.Name == dir).First()
                            .SubDirectories
                            .Add(line.Substring("dir ".Length));
                    }
                }
                else
                {
                    var size = Convert.ToInt32(line.Split(' ').First());

                    for (int i = 0; i < directoryHistory.Count; i++)
                    {
                        var dir = String.Join(";", directoryHistory.GetRange(0, i + 1).ToArray());
                        directories
                            .Where(x => x.Name == dir).First()
                            .Size += size;
                    }
                }
            }

            // Remove top most directory
            //directories.Remove(directories.Where(x => x.Name == "/").First());
            // Filter directories by asked size
            var result = directories.Where(x => x.Size <= 100000).ToList();

            sumOfTotalSizes = result.Sum(x => x.Size);

            // Assert for input1
            //Assert.AreEqual(95437, sumOfTotalSizes, "Result is not correct");

            Console.WriteLine("Result: " + sumOfTotalSizes);
        }
    }
}
