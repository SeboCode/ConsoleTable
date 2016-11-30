using System;
using System.Linq;
using ConsoleTable.Core.Extensions;
using ConsoleTable.Settings;

namespace ConsoleTable.Core
{
    public class ConsoleTable<T>
    {
        private const string NewLine = "\r\n";

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
            Settings = ConsoleTable.Settings.Settings.Default;
        }

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

        public Settings.Settings Settings { get; set; }

        public string Title { get; set; }

        public string[] Header { get; set; }

        public int RowCount => _table.GetLength(0);

        public int ColumnCount => _table.GetLength(1);

        public void Write()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var output = string.Empty;

            if (!Title.IsNullOrEmptyOrWhiteSpace())
            {
                output += Title;
                output += NewLine;
            }

            output += GetRowSeparator(VerticalBorder.Top);

            if (Header != null)
            {
                output += GetFormatedHeader();
            }

            output += GetFormatedData();
            return output;
        }

        private string GetFormatedData()
        {
            var data = string.Empty;
            var columnSeperator = Settings.TableSymbols.VerticalTableFieldBorder;

            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    var columnLength = GetColumnLength(column);
                    data += columnSeperator;
                    data += $"{_table[row, column]}".PadRight(columnLength);
                }

                data += columnSeperator;
                data += NewLine;
                var verticalBorder = row == RowCount - 1 ? VerticalBorder.Bottom : VerticalBorder.Between;
                data += GetRowSeparator(verticalBorder);
            }

            return data;
        }

        private string GetFormatedHeader()
        {
            var formatedHeader = string.Empty;
            var columnSeperator = Settings.TableSymbols.VerticalTableFieldBorder;

            for (var header = 0; header < Header.Length; header++)
            {
                formatedHeader += columnSeperator;
                formatedHeader += Header[header].PadRight(GetColumnLength(header));
            }

            formatedHeader += columnSeperator;
            formatedHeader += NewLine;
            formatedHeader += GetRowSeparator(VerticalBorder.Between);
            return formatedHeader;
        }

        private string GetRowSeparator(VerticalBorder verticalBorder)
        {
            var rowSeparator = Settings.GetBorderSymbol(HorizontalBorder.Left, verticalBorder).ToString();

            for (var column = 0; column < ColumnCount; column++)
            {
                var columnLength = GetColumnLength(column);
                rowSeparator += new string(Settings.TableSymbols.HorizontalTableFieldBorder, columnLength);
                var horizontalBorder = column == ColumnCount - 1 ? HorizontalBorder.Right : HorizontalBorder.Between;
                rowSeparator += Settings.GetBorderSymbol(horizontalBorder, verticalBorder);
            }

            rowSeparator += NewLine;
            return rowSeparator;
        }

        private int GetElementLength(int row, int column)
        {
            return $"{_table[row, column]}".Count();
        }

        private int GetOverallMaxLength()
        {
            var maxLength = Header?.Select(header => header.Count()).Max() ?? 0;

            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    var elementLength = GetElementLength(row, column);
                    maxLength = maxLength > elementLength ? maxLength : elementLength;
                }
            }

            return maxLength;
        }

        private int GetColumnMaxLength(int columnNumber)
        {
            var maxLength = Header?[columnNumber]?.Count() ?? 0;

            for (var row = 0; row < RowCount; row++)
            {
                var elementLength = GetElementLength(row, columnNumber);
                maxLength = maxLength > elementLength ? maxLength : elementLength;
            }

            return maxLength;
        }

        private int GetColumnLength(int column)
        {
            return Settings.SameRowLength ? GetOverallMaxLength() : GetColumnMaxLength(column);
        }

        private void FillTable(T[][] table, T fillerElement, int biggestColumn)
        {
            for (var x = 0; x < table.Count(); x++)
            {
                for (var y = 0; y < biggestColumn; y++)
                {
                    try
                    {
                        _table[x, y] = table[x][y];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        _table[x, y] = fillerElement;
                    }
                }
            }
        }
    }
}