namespace ConsoleTable.Settings.Symbols
{
    public interface ITableSymbols
    {
        char TopRightCorner { get; set; }
        char TopLeftCorner { get; set; }
        char BottomRightCorner { get; set; }
        char BottomLeftCorner { get; set; }
        char RightRowSeperator { get; set; }
        char LeftRowSeperator { get; set; }
        char TopColumnSeperator { get; set; }
        char BottomColumnSeperator { get; set; }
        char TableFieldCorner { get; set; }
        char HorizontalTableFieldBorder { get; set; }
        char VerticalTableFieldBorder { get; set; }
    }
}