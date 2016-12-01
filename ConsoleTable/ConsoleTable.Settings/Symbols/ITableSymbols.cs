namespace ConsoleTable.Settings.Symbols
{
    public interface ITableSymbols
    {
        char TopRightCorner { get; }
        char TopLeftCorner { get; }
        char BottomRightCorner { get; }
        char BottomLeftCorner { get; }
        char RightRowSeperator { get; }
        char LeftRowSeperator { get; }
        char TopColumnSeperator { get; }
        char BottomColumnSeperator { get; }
        char TableFieldCorner { get; }
        char HorizontalTableFieldBorder { get; }
        char VerticalTableFieldBorder { get; }
    }
}