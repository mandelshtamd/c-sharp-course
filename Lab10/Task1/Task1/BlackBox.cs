using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class BlackBox
    {
        private int innerValue;
        private BlackBox(int innerValue)
        {
            this.innerValue = 0;
        }
        private BlackBox()
        {
            this.innerValue = default;
        }
        private void Add(int addend)
        {
            this.innerValue += addend;
        }
        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }
        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }
        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }
    }
}
