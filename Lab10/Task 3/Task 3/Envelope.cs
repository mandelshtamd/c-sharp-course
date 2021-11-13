using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_3
{
    public class Envelope
    {
        public int Width 
        { 
            get; 
            protected set; 
        }
        public int Height 
        { 
            get; 
            protected set; 
        }

        public Envelope(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class EnvelopeComparer : Comparer<Envelope>
    {
        public override int Compare(Envelope x, Envelope y)
        {
            return x.Height < y.Height ? -1 : 1;
        }
    }
}
