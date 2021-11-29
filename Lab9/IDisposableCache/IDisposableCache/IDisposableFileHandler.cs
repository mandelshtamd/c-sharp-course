using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IDisposableCache
{
    // почему этот класс не наследует интерфейс IDisposable? и название классов не должно начинаться с I
    class IDisposableFileHandler
    {
        FileStream _handledFile;

        IDisposableFileHandler(string filePath)
        {
            _handledFile = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.None);
        }

        public void Dispose()
        {
            // в этом классе должен быть финализатор. инае вызов метода GC.SuppressFinalize не имеет смысла
            _handledFile.Close();
            GC.SuppressFinalize(this);
        }
    }
}
