using System;
using System.Linq;
using System.Text;
using ConsoleTable.Core.Extensions;
using ConsoleTable.Settings.Border;

namespace ConsoleTable.Core.Drawer
{
    public class ConsoleTableDrawer : IConsoleTableDrawer
    {
        private const string NewLine = "\r\n";

        private readonly IConsoleTable _table;
        private int[] _columnLengths;

        public ConsoleTableDrawer(IConsoleTable table)
        {
            _table = table;
        }

        public void Write()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return GetFormatedTable();
        }

        private string GetFormatedTable()
        {
            _columnLengths = _table.Settings.SameRowLength ? CalculateOverallMaxColumnLength(_table.ColumnCount) : CalculateColumnLength(_table.ColumnCount);
            var output = new StringBuilder();

            if (!_table.Title.IsNullOrEmptyOrWhiteSpace())
            {
                output.Append(_table.Title);
                output.Append(NewLine);
            }

            output.Append(GetRowSeparator(VerticalBorder.Top));
            output.Append(NewLine);

            if (_table.Header != null)
            {
                output.Append(GetFormatedHeader());
            }

            output.Append(GetFormatedData());
            return output.ToString();
        }

        private string GetFormatedData()
        {
            var data = new StringBuilder();
            var columnSeperator = _table.Settings.TableSymbols.VerticalTableFieldBorder;

            for (var row = 0; row < _table.RowCount; row++)
            {
                for (var column = 0; column < _table.ColumnCount; column++)
                {
                    var columnLength = _columnLengths[column];
                    data.Append(columnSeperator);
                    data.Append($"{_table[row, column]}".PadRight(columnLength));
                }

                data.Append(columnSeperator);
                data.Append(NewLine);
                var verticalBorder = row == _table.RowCount - 1 ? VerticalBorder.Bottom : VerticalBorder.Between;
                data.Append(GetRowSeparator(verticalBorder));
                data.Append(NewLine);
            }

            return data.ToString();
        }

        private string GetFormatedHeader()
        {
            var formatedHeader = new StringBuilder();
            var columnSeperator = _table.Settings.TableSymbols.VerticalTableFieldBorder;

            for (var i = 0; i < _table.Header.Count(); i++)
            {
                formatedHeader.Append(columnSeperator);
                formatedHeader.Append(_table.Header[i].PadRight(_columnLengths[i]));
            }

            formatedHeader.Append(columnSeperator);
            formatedHeader.Append(NewLine);
            formatedHeader.Append(GetRowSeparator(VerticalBorder.Between));
            formatedHeader.Append(NewLine);
            return formatedHeader.ToString();
        }

        private string GetRowSeparator(VerticalBorder verticalBorder)
        {
            var rowSeparator = new StringBuilder();
            rowSeparator.Append(_table.Settings.GetBorderSymbol(HorizontalBorder.Left, verticalBorder).ToString());
            
            for (var column = 0; column < _columnLengths.Count(); column++)
            {
                rowSeparator.Append(new string(_table.Settings.TableSymbols.HorizontalTableFieldBorder, _columnLengths[column]));
                var horizontalBorder = column == _table.ColumnCount - 1 ? HorizontalBorder.Right : HorizontalBorder.Between;
                rowSeparator.Append(_table.Settings.GetBorderSymbol(horizontalBorder, verticalBorder));
            }
            
            return rowSeparator.ToString();
        }

        private int[] CalculateOverallMaxColumnLength(int columnCount)
        {
            var columnLengths = new int[columnCount];
            var maxLength = GetOverallMaxLength();

            for (var column = 0; column < columnLengths.Length; column++)
            {
                columnLengths[column] = maxLength;
            }

            return columnLengths;
        }

        private int[] CalculateColumnLength(int columnCount)
        {
            var columnLengths = new int[columnCount];

            for (var column = 0; column < columnCount; column++)
            {
                columnLengths[column] = GetColumnMaxLength(column);
            }

            return columnLengths;
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

        private int GetElementLength(int row, int column)
        {
            return $"{_table[row, column]}".Count();
        }
    }
}