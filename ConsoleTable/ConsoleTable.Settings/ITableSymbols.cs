namespace ConsoleTable.Settings
{
    public interface ITableSymbols
    {
        char HorizontalLine { get; }
        char VerticalLine { get; }
        char RightTopCorner { get; }
        char RightBottomCorner { get; }
        char LeftBottomCorner { get; }
        char LeftTopCorner { get; }
        char TopBorder { get; }
        char RightBorder { get; }
        char BottomBorder { get; }
        char LeftBorder { get; }
        char BetweenBorder { get; }
    }
}