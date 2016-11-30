using ConsoleTable.Settings;

namespace ConsoleTable
{
    public class MatrixTableSymbols : TableSymbols
    {
        public override char HorizontalTableFieldBorder => ' ';
        public override char TopColumnSeperator => ' ';
        public override char RightRowSeperator => base.VerticalTableFieldBorder;
        public override char BottomColumnSeperator => ' ';
        public override char LeftRowSeperator =>  base.VerticalTableFieldBorder;
        public override char TableFieldCorner => ' ';
    }
}
