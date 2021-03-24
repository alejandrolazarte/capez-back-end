using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

namespace CG.Application.Common.Helpers
{
    public static class ExcelFile
    {
        public static IEnumerable<T> ReadExcelFile<T>(string filepath, Func<IExcelDataReader, T> mapperExcelDataToClass,
            int skipRowsNumber = 0) where T : class, new()
        {
            var list = new List<T>();
            using var stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var count = 0;
            while (reader.Read())
            {
                if (count >= skipRowsNumber)
                {
                    list.Add(mapperExcelDataToClass(reader));
                }
                count++;
            }
            return list;
        }
    }
}
