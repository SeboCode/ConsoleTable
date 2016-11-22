using ConsoleTable.Settings;

namespace ConsoleTable
{
    public class MatrixTableSymbols : TableSymbols
    {
        public override char HorizontalLine => ' ';
        public override char TopBorder => ' ';
        public override char RightBorder => '│';
        public override char BottomBorder => ' ';
        public override char LeftBorder =>  '│';
        public override char BetweenBorder => ' ';
    }
}
