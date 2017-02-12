using System;
using System.Linq;
using ConsoleTable.Core.Extensions;
using ConsoleTable.Settings;

namespace ConsoleTable.Core
{
    public class ConsoleTable<T> : IConsoleTable<T>, IConsoleTable
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

        object IConsoleTable.this[int row, int column]
        {
            get { return this[row, column]; }
            set { this[row, column] = (T) value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">The title of the table.</param>
        /// <param name="header">The title of the columns of the table.</param>
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
            Settings = new ConsoleTableSettings();
        }

        //overwork in c# 7
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table">The data of the table.</param>
        /// <param name="title">The title of the table.</param>
        /// <param name="header">The title of the columns of the table.</param>
        public ConsoleTable(T[,] table, string title = null, string[] header = null) : this(title, header)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            _table = table;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row">The amount of rows, which the table should have.</param>
        /// <param name="column">The amount of columns, which the table should have.</param>
        /// <param name="title">The title of the table.</param>
        /// <param name="header">The title of the columns of the table.</param>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rows">The data of the table.</param>
        /// <param name="title">The title of the table.</param>
        /// <param name="header">The title of the columns of the table.</param>
        /// <param name="fillerElement">Value used to bring all rows to the same length.</param>
        public ConsoleTable(T[][] rows, string title = null, string[] header = null, T fillerElement = default(T)) : this(title, header)
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

        //todo maybe move to drawer
        /// <summary>
        /// The Settings property gives information about how to draw the table.
        /// </summary>
        /// <value>The Settings property gets/sets the value of the settings object.</value>
        public IConsoleTableSettings Settings { get; set; }

        /// <summary>
        /// The Title property represents the title of the table.
        /// </summary>
        /// <value>The Title property gets/sets the value of the title.</value>
        public string Title { get; set; }
        
        //todo maybe remove setter
        /// <summary>
        /// The Header property represents the titles of the columns.
        /// </summary>
        /// <value>The Title property gets/sets the value of the titles of the columns.</value>
        public string[] Header { get; set; }

        /// <summary>
        /// The RowCount property represents the amount of rows of the table.
        /// </summary>
        /// <value>The Rowcount property gets the amount of rows of the table.</value>
        public int RowCount => _table.GetLength(0);

        /// <summary>
        /// The ColumnCount property represents the amount of rows of the table.
        /// </summary>
        /// <value>The ColumnCount property gets the amount of rows of the table.</value>
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