using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IDisposableCache
{
    class IDisposableFileHandler
    {
        FileStream _handledFile;

        IDisposableFileHandler(string filePath)
        {
            _handledFile = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.None);
        }

        public void Dispose()
        {
            _handledFile.Close();
            GC.SuppressFinalize(this);
        }
    }
}
