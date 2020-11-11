using System;
using ImportInterface;
using ImportInterface.Parseo;

namespace JsonImporter
{
    public class JsonImporter : IImport
    {
        public JsonImporter() { }
        
        public string GetName()
        {
            return "JSON";
        }

        public MovieParseo Import(string path)
        {
            //CODIGO PARA PARSEAR
            return null;
        }
    }
}
