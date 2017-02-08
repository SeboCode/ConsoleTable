using System.Collections.Generic;
using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Util;

namespace ConsoleTable.Settings.Symbols
{
    public class TableSymbols
    {
        private readonly Dictionary<Borders, char> _borderAssignment;

        public TableSymbols()
        {
            _borderAssignment = new Dictionary<Borders, char>(EnumUtil.Size<HorizontalBorder>() * EnumUtil.Size<VerticalBorder>());
            AssignBorders();
        }

        private char _topRightCorner = '┐';
        public virtual char TopRightCorner
        {
            get { return _topRightCorner; }
            set
            {
                _topRightCorner = value; 
                AssignBorders();
            }
        }

        private char _topLeftCorner = '┌';
        public virtual char TopLeftCorner
        {
            get { return _topLeftCorner; }
            set
            {
                _topLeftCorner = value;
                AssignBorders();
            }
        }

        private char _bottomRightCorner = '┘';
        public virtual char BottomRightCorner
        {
            get { return _bottomRightCorner; }
            set
            {
                _bottomRightCorner = value; 
                AssignBorders();
            }
        }

        private char _bottomLeftCorner = '└';
        public virtual char BottomLeftCorner
        {
            get { return _bottomLeftCorner; }
            set
            {
                _bottomLeftCorner = value; 
                AssignBorders();
            }
        }

        private char _rightRowSeperator = '┤';
        public virtual char RightRowSeperator
        {
            get { return _rightRowSeperator; }
            set
            {
                _rightRowSeperator = value; 
                AssignBorders();
            }
        }

        private char _leftRowSeperator = '├';
        public virtual char LeftRowSeperator
        {
            get { return _leftRowSeperator; }
            set
            {
                _leftRowSeperator = value; 
                AssignBorders();
            }
        }

        private char _topColumnSeperator = '┬';
        public virtual char TopColumnSeperator
        {
            get { return _topColumnSeperator; }
            set
            {
                _topColumnSeperator = value; 
                AssignBorders();
            }
        }

        private char _bottomColumnSeperator = '┴';
        public virtual char BottomColumnSeperator
        {
            get { return _bottomColumnSeperator; }
            set
            {
                _bottomColumnSeperator = value; 
                AssignBorders();
            }
        }

        private char _tableFieldCorner = '┼';
        public virtual char TableFieldCorner
        {
            get { return _tableFieldCorner; }
            set
            {
                _tableFieldCorner = value; 
                AssignBorders();
            }
        }

        private char _horizontalTableFieldBorder = '─';
        public virtual char HorizontalTableFieldBorder
        {
            get { return _horizontalTableFieldBorder; }
            set
            {
                _horizontalTableFieldBorder = value; 
                AssignBorders();
            }
        }

        private char _verticalTableFieldBorder = '│';
        public virtual char VerticalTableFieldBorder
        {
            get { return _verticalTableFieldBorder; }
            set
            {
                _verticalTableFieldBorder = value; 
                AssignBorders();
            }
        }

        public char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Top)
            {
                return TopLeftCorner;
            }

            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Center)
            {
                return LeftRowSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Bottom)
            {
                return BottomLeftCorner;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Top)
            {
                return TopColumnSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Center)
            {
                return TableFieldCorner;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Bottom)
            {
                return BottomColumnSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Right && verticalBorder == VerticalBorder.Top)
            {
                return TopRightCorner;
            }

            if (horizontalBorder == HorizontalBorder.Right && verticalBorder == VerticalBorder.Center)
            {
                return RightRowSeperator;
            }

            return BottomRightCorner;
        }
        
        private void AssignBorders()
        {
            //todo redundant => remove
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Bottom)] = BottomLeftCorner;
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Center)] = LeftRowSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Top)] = TopLeftCorner;
            _borderAssignment[new Borders(HorizontalBorder.Center, VerticalBorder.Bottom)] = BottomColumnSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Center, VerticalBorder.Center)] = TableFieldCorner;
            _borderAssignment[new Borders(HorizontalBorder.Center, VerticalBorder.Top)] = TopColumnSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Bottom)] = BottomRightCorner;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Center)] = RightRowSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Top)] = TopRightCorner;
        }

        private struct Borders
        {
            public Borders(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
            {
                HorizontalBorder = horizontalBorder;
                VerticalBorder = verticalBorder;
            }

            private HorizontalBorder HorizontalBorder { get; }
            private VerticalBorder VerticalBorder { get; }
        }
    }
}