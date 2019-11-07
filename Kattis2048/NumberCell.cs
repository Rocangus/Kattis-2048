using System;
using System.Collections.Generic;
using System.Text;

namespace Kattis2048
{
    class NumberCell
    {
        public bool Merged { get; private set; } = false;
        public int Value { get; private set; }

        public NumberCell(int value)
        {
            Value = value;
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
