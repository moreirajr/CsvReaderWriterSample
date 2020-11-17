using CsvHelper.Configuration;

namespace CsvReaderWriterSample.Lib
{
    public class CsvMap<T> : ClassMap<T>
        where T : class
    {
    }
}