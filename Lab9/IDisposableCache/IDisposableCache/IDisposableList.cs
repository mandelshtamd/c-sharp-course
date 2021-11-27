using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposableCache
{
    class IDisposableList : IDisposable
    {
        List<int> list = null;

        public IDisposableList(int sample, int size)
        {
            list = Enumerable.Repeat(sample, size).ToList();
        }

        public void Dispose() {
            list.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
