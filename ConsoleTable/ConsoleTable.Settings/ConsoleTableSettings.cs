using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Symbols;

namespace ConsoleTable.Settings
{
    public class ConsoleTableSettings : IConsoleTableSettings
    {
        public ConsoleTableSettings(TableSymbols tableSymbols = null, bool sameRowLength = false)
        {
            if (tableSymbols == null)
            {
                tableSymbols = new TableSymbols();
            }
            
            TableSymbols = tableSymbols;
            SameRowLength = sameRowLength;
        }

        public bool SameRowLength { get; set; }

        private TableSymbols _tableSymbols;
        public TableSymbols TableSymbols
        {
            get { return _tableSymbols; }
            set
            {
                _tableSymbols = value;
            }
        }

        public void ToDefault()
        {
            SameRowLength = false;
            TableSymbols = new TableSymbols();
        }
        
        public char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            return TableSymbols.GetBorderSymbol(horizontalBorder, verticalBorder);
        }
    }
}