using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposableCache
{
    // IDisposableList - это класс, с буквы I называются только интерфейсы
    class IDisposableList : IDisposable
    {
        List<int> list = null;

        public IDisposableList(int sample, int size)
        {
            list = Enumerable.Repeat(sample, size).ToList();
        }

        public void Dispose() {
            list.Clear();
            // нет смысла в вызове GC.SuppressFinalize, т.к. в классе отсутствует финализатор (~IDisposableList())
            GC.SuppressFinalize(this);
        }
    }
}
