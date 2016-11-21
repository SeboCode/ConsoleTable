using System;
using ConsoleTable.Core;

namespace ConsoleTable
{
    public class Program
    {
        public static void Main(string[] args)
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

            var headers = new string[] { "Column 1", "Mike", "Sandro" };

            var matrix = new ConsoleTable<double>(table, "Maaatrix", headers);
            Console.WriteLine(matrix.ToString());
            Console.ReadKey();
        }
    }
}
