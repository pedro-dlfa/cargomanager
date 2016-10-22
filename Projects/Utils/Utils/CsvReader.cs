using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace CargoManager.Shared.Utils
{
    public static class CsvReader
    {
        public static IEnumerable<T> ReadString<T>(string content, Func<string[], T> reader, bool skipHeader = true) where T : class
        {
            List<T> list = new List<T>();

            using (TextReader textReader = new StringReader(content))
            using (TextFieldParser parser = new TextFieldParser(textReader))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                if (skipHeader && !parser.EndOfData)
                    parser.ReadFields();
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    list.Add(reader(fields));
                }
            }

            return list;
        }
    }
}
