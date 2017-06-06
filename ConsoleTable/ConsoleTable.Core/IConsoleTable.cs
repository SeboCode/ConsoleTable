namespace ConsoleTable.Core
{
    public interface IConsoleTable<T>
    {
        T this[int row, int column] { get; set; }

        string Title { get; set; }

        string[] Header { get; set; }

        int RowCount { get; }

        int ColumnCount { get; }
    }

    public interface IConsoleTable
    {
        object this[int row, int column] { get; set; }

        string Title { get; set; }

        string[] Header { get; set; }

        int RowCount { get; }

        int ColumnCount { get; }
    }
}