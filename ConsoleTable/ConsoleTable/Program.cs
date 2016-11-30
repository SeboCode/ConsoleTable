using System;
using ConsoleTable.Core;

namespace ConsoleTable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintTableWithNumbers();
            PrintTableWithIds();
            PrintMatrix();

            Console.ReadKey();
        }

        private static void PrintMatrix()
        {
            var matrix = new[,]
            {
                {1.25, 214.5},
                {26.4, 241.5}
            };

            var table = new ConsoleTableData<double>(matrix)
            {
                Settings = {TableSymbols = new MatrixTableSymbols()}
            };
            Console.WriteLine(new ConsoleTable<double>(table));
        }

        private static void PrintTableWithIds()
        {
            var data = new[,]
            {
                { "1", "Semper Tellus Limited", "Lorem ipsum dolor sit" },
                { "2", "Quisque Company", "Lorem ipsum dolor sit" },
                { "3", "Et Ultrices Posuere Associates", "Lorem ipsum dolor sit" },
                { "4", "Lectus Cum Sociis Limited", "Lorem ipsum dolor" }
            };

            var table = new ConsoleTableData<string>(data);
            Console.WriteLine(new ConsoleTable<string>(table));
        }

        private static void PrintTableWithNumbers()
        {
            var random = new Random();

            const int rowCount = 3;
            const int columnCount = 3;

            var table = new double[rowCount, columnCount];

            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    table[row, column] = random.NextDouble();
                }
            }

            var matrix = new ConsoleTableData<double>(table, "Maaatrix", new[] {"Column 1", "Mike", "Sandro"});
            Console.WriteLine(new ConsoleTable<double>(matrix));
        }
    }
}
