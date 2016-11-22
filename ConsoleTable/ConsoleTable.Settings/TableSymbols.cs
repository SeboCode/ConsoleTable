namespace ConsoleTable.Settings
{
    public class TableSymbols : ITableSymbols
    {
        public char HorizontalLine => '─';
        public char VerticalLine => '│';
        public char RightTopCorner => '┐';
        public char RightBottomCorner => '┘';
        public char LeftBottomCorner => '└';
        public char LeftTopCorner => '┌';
        public char TopBorder => '┬';
        public char RightBorder => '┤';
        public char BottomBorder => '┴';
        public char LeftBorder => '├';
        public char BetweenBorder => '┼';
    }
}