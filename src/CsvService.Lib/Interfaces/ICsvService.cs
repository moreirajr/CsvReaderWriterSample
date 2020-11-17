using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsvReaderWriterSample.Lib.Interfaces
{
    public interface ICsvService : IDisposable
    {
        IEnumerable<T> Read<T>(string file, string delimiter = ",", Encoding encoding = null)
            where T : class;
        IEnumerable<T> Read<T, TClassMap>(string file, string delimiter = ",", Encoding encoding = null)
            where T : class
            where TClassMap : CsvMap<T>;

        Task WriteAsync<T>(string file, IEnumerable<T> records, string delimiter = ",", Encoding encoding = null)
            where T : class;
        Task WriteAsync<T, TClassMap>(string file, IEnumerable<T> records, string delimiter = ",", Encoding encoding = null)
            where T : class
            where TClassMap : CsvMap<T>;
    }
}