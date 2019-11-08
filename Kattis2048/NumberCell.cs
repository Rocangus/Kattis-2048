using System;
using System.Collections.Generic;
using System.Text;

namespace Kattis2048
{
    class NumberCell
    {
        private static NumberCell empty;
        public bool Merged { get; private set; } = false;
        public Tuple<int, int> Position { get; private set; }
        public int Value { get; private set; }

        public static NumberCell EmptyCell 
        { 
            get {
                if (empty == null)
                {
                    empty = new NumberCell(0, Tuple.Create(0, 0));
                }
                return empty;
            } 
        }

        public NumberCell(int value, Tuple<int, int> position)
        {
            Value = value;
            Position = position;
        }

        public void SetPosition(Tuple<int, int> newPos)
        {
            Position = newPos;
        }

        public static NumberCell Merge(NumberCell merger, NumberCell mergee)
        {
            merger.Value += mergee.Value;
            merger.Merged = true;
            merger.Position = mergee.Position;
            return merger;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
