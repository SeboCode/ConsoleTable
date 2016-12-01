using System;
using System.Linq;
using ConsoleTable.Core.Data;
using ConsoleTable.Core.Extensions;
using ConsoleTable.Settings.Border;

namespace ConsoleTable.Core
{
    public class ConsoleTable<T> : IConsoleTable
    {
        private const string NewLine = "\r\n";

        private readonly IConsoleTableData<T> _table;

        public ConsoleTable(IConsoleTableData<T> table)
        {
            _table = table;
        }

        public void Write()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var output = string.Empty;

            if (!_table.Title.IsNullOrEmptyOrWhiteSpace())
            {
                output += _table.Title;
                output += NewLine;
            }

            output += GetRowSeparator(VerticalBorder.Top);

            if (_table.Header != null)
            {
                output += GetFormatedHeader();
            }

            output += GetFormatedData();
            return output;
        }

        private string GetFormatedData()
        {
            var data = string.Empty;
            var columnSeperator = _table.Settings.TableSymbols.VerticalTableFieldBorder;

            for (var row = 0; row < _table.RowCount; row++)
            {
                for (var column = 0; column < _table.ColumnCount; column++)
                {
                    var columnLength = GetColumnLength(column);
                    data += columnSeperator;
                    data += $"{_table[row, column]}".PadRight(columnLength);
                }

                data += columnSeperator;
                data += NewLine;
                var verticalBorder = row == _table.RowCount - 1 ? VerticalBorder.Bottom : VerticalBorder.Between;
                data += GetRowSeparator(verticalBorder);
            }

            return data;
        }

        private string GetFormatedHeader()
        {
            var formatedHeader = string.Empty;
            var columnSeperator = _table.Settings.TableSymbols.VerticalTableFieldBorder;

            for (var i = 0; i < _table.Header.Count(); i++)
            {
                formatedHeader += columnSeperator;
                formatedHeader += _table.Header[i].PadRight(GetColumnLength(i));
            }

            formatedHeader += columnSeperator;
            formatedHeader += NewLine;
            formatedHeader += GetRowSeparator(VerticalBorder.Between);
            return formatedHeader;
        }

        private string GetRowSeparator(VerticalBorder verticalBorder)
        {
            var rowSeparator = _table.Settings.GetBorderSymbol(HorizontalBorder.Left, verticalBorder).ToString();

            for (var column = 0; column < _table.ColumnCount; column++)
            {
                var columnLength = GetColumnLength(column);
                rowSeparator += new string(_table.Settings.TableSymbols.HorizontalTableFieldBorder, columnLength);
                var horizontalBorder = column == _table.ColumnCount - 1 ? HorizontalBorder.Right : HorizontalBorder.Between;
                rowSeparator += _table.Settings.GetBorderSymbol(horizontalBorder, verticalBorder);
            }

            rowSeparator += NewLine;
            return rowSeparator;
        }

        private int GetElementLength(int row, int column)
        {
            return $"{_table[row, column]}".Count();
        }

        private int GetColumnLength(int column)
        {
            return _table.Settings.SameRowLength ? GetOverallMaxLength() : GetColumnMaxLength(column);
        }

        private int GetOverallMaxLength()
        {
            var maxLength = _table.Header?.Select(header => header.Count()).Max() ?? 0;

            for (var row = 0; row < _table.RowCount; row++)
            {
                for (var column = 0; column < _table.ColumnCount; column++)
                {
                    var elementLength = GetElementLength(row, column);
                    maxLength = maxLength > elementLength ? maxLength : elementLength;
                }
            }

            return maxLength;
        }

        private int GetColumnMaxLength(int columnNumber)
        {
            var maxLength = _table.Header?[columnNumber]?.Count() ?? 0;

            for (var row = 0; row < _table.RowCount; row++)
            {
                var elementLength = GetElementLength(row, columnNumber);
                maxLength = maxLength > elementLength ? maxLength : elementLength;
            }

            return maxLength;
        }
    }
}