using ConsoleTable.Settings;

namespace ConsoleTable
{
    public class MatrixTableSymbols : TableSymbols
    {
        public override char HorizontalLine => ' ';
        public override char TopBorder => ' ';
        public override char RightBorder => base.VerticalLine;
        public override char BottomBorder => ' ';
        public override char LeftBorder =>  base.VerticalLine;
        public override char BetweenBorder => ' ';
    }
}
