﻿using System;
using ConsoleTable.Core;
using ConsoleTable.Core.Drawer;

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

            var data = new ConsoleTable<double>(matrix)
            {
                Title = "Matrix"
            };

            var table = new ConsoleTableDrawer(data)
            {
                Settings = {TableSymbols = new MatrixTableSymbols()}
            };

            table.Write();
        }

        private static void PrintTableWithIds()
        {
            var values = new[,]
            {
                { "1", "Semper Tellus Limited", "Lorem ipsum dolor sit" },
                { "2", "Quisque Company", "Lorem ipsum dolor sit" },
                { "3", "Et Ultrices Posuere Associates", "Lorem ipsum dolor sit" },
                { "4", "Lectus Cum Sociis Limited", "Lorem ipsum dolor" }
            };

            var data = new ConsoleTable<string>(values);
            var table = new ConsoleTableDrawer(data);
            table.Write();
        }

        private static void PrintTableWithNumbers()
        {
            var random = new Random();

            const int rowCount = 3;
            const int columnCount = 3;

            var values = new double[rowCount, columnCount];

            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    values[row, column] = random.NextDouble();
                }
            }

            var data = new ConsoleTable<double>(values, "Table Title", new[] {"Column 1", "Column 2", "Column 3"});
            var table = new ConsoleTableDrawer(data);
            table.Write();
        }
    }
}
