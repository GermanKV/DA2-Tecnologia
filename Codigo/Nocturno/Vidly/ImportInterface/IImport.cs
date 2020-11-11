using System;
using ImportInterface.Parseo;

namespace ImportInterface
{
    public interface IImport
    {
        string GetName();
        MovieParseo Import(string path);
    }
}
