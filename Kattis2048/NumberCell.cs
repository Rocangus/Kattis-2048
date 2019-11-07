using System;
using System.Collections.Generic;
using System.Text;

namespace Kattis2048
{
    class NumberCell
    {
        public bool Merged { get; private set; } = false;
        public Tuple<int, int> Position { get; private set; }
        public int Value { get; private set; }

        public NumberCell(int value, Tuple<int, int> position)
        {
            Value = value;
            Position = position;
        }

        public NumberCell Merge(NumberCell merger, NumberCell mergee)
        {
            merger.Value += mergee.Value;
            merger.Merged = true;
            return merger;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
