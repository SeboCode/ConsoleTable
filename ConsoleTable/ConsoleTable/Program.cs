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

            Console.ReadKey();
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

            var table = new ConsoleTable<string>(data);
            Console.WriteLine(table.ToString());
        }

        private static void PrintTableWithNumbers()
        {
            var random = new Random();

            var rowCount = 3;
            var columnCount = 3;

            var table = new double[rowCount, columnCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    table[row, column] = random.NextDouble();
                }
            }

            var matrix = new ConsoleTable<double>(
                table,
                title: "Maaatrix",
                header: new[] { "Column 1", "Mike", "Sandro" },
                sameRowLength: true
            );

            Console.WriteLine(matrix.ToString());
        }
    }
}
