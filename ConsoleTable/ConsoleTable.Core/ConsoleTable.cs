﻿using System;
using System.Linq;
using ConsoleTable.Core.Extensions;
using ConsoleTable.Settings;

namespace ConsoleTable.Core
{
    public class ConsoleTable<T> : IConsoleTable<T>
    {
        private readonly T[,] _table;

        public T this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
                {
                    throw new IndexOutOfRangeException(nameof(_table));
                }

                return _table[row, column];
            }
            set
            {
                if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount)
                {
                    throw new IndexOutOfRangeException(nameof(_table));
                }

                _table[row, column] = value;
            }
        }

        private ConsoleTable(string title = null, string[] header = null)
        {
            if (title.IsEmptyOrWhiteSpace())
            {
                title = null;
            }


            if (header != null)
            {
                for (var i = 0; i < header.Count(); i++)
                {
                    if (header[i].IsEmptyOrWhiteSpace())
                    {
                        header[i] = null;
                    }
                }
            }

            Title = title;
            Header = header;
            Settings = new Settings.Settings();
        }

        //overwork in c# 7
        public ConsoleTable(T[,] table, string title = null, string[] header = null) : this(title, header)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            _table = table;
        }

        public ConsoleTable(int row, int column, string title = null, string[] header = null) : this(title, header)
        {
            if (row < 1)
            {
                throw new ArgumentException(nameof(row));
            }

            if (column < 1)
            {
                throw new ArgumentException(nameof(column));
            }

            _table = new T[row, column];
        }

        //todo use 2d array instead of params => move fillerelement to end
        public ConsoleTable(T fillerElement = default(T), string title = null, string[] header = null, params T[][] rows) : this(title, header)
        {
            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            if (!rows.Any())
            {
                throw new ArgumentException(nameof(rows));
            }

            var hasAny = false;

            foreach (var row in rows)
            {
                if (row.Any())
                {
                    hasAny = true;
                }
            }

            if (!hasAny)
            {
                throw new ArgumentException(nameof(rows));
            }

            var biggestColumn = rows.Select(row => row.Count()).Max();
            _table = new T[rows.Count(), biggestColumn];
            FillTable(rows, fillerElement, biggestColumn);
        }

        public ISettings Settings { get; set; }

        public string Title { get; set; }

        public string[] Header { get; set; }

        public int RowCount => _table.GetLength(0);

        public int ColumnCount => _table.GetLength(1);

        private void FillTable(T[][] table, T fillerElement, int biggestColumn)
        {
            for (var x = 0; x < table.Count(); x++)
            {
                for (var y = 0; y < biggestColumn; y++)
                {
                    if (table[x].Count() > y)
                    {
                        _table[x, y] = table[x][y];
                    }
                    else
                    {
                        _table[x, y] = fillerElement;
                    }
                }
            }
        }
    }
}