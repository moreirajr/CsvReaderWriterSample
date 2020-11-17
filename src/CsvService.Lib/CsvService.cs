using CsvHelper;
using CsvReaderWriterSample.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace CsvReaderWriterSample.Lib
{
    public class CsvService : ICsvService
    {
        private CsvReader _csvReader;
        private CsvWriter _csvWriter;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _streamReader?.Dispose();
                _streamWriter?.Dispose();
                _csvReader?.Dispose();
            }

            _disposed = true;
        }

        public IEnumerable<T> Read<T>(string file, string delimiter = ",", Encoding encoding = null)
            where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException("Caminho inválido.");

                if (!File.Exists(file))
                    throw new Exception("Arquivo inexistente.");

                _streamReader = new StreamReader(file, encoding ?? Encoding.Default);
                _csvReader = new CsvReader(_streamReader, CultureInfo.InvariantCulture);

                _csvReader.Configuration.Delimiter = delimiter;
                _csvReader.Configuration.PrepareHeaderForMatch = (header, index) => header.Trim().ToLower();

                return _csvReader.GetRecords<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> Read<T, TClassMap>(string file, string delimiter = ",", Encoding encoding = null)
            where T : class
            where TClassMap : CsvMap<T>
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException("Caminho inválido.");

                if (!File.Exists(file))
                    throw new Exception("Arquivo inexistente.");

                _streamReader = new StreamReader(file, encoding ?? Encoding.Default);
                _csvReader = new CsvReader(_streamReader, CultureInfo.InvariantCulture);

                _csvReader.Configuration.RegisterClassMap<TClassMap>();
                _csvReader.Configuration.Delimiter = delimiter;
                _csvReader.Configuration.PrepareHeaderForMatch = (header, index) => header.Trim().ToLower();

                return _csvReader.GetRecords<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task WriteAsync<T>(string file, IEnumerable<T> records, string delimiter = ",", Encoding encoding = null)
            where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException("Caminho inválido.");

                if (!File.Exists(file))
                    throw new Exception("Arquivo inexistente.");

                _streamWriter = new StreamWriter(file);
                _csvWriter = new CsvWriter(_streamWriter, CultureInfo.InvariantCulture);

                _csvWriter.Configuration.Delimiter = delimiter;

                await _csvWriter.WriteRecordsAsync<T>(records);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task WriteAsync<T, TClassMap>(string file, IEnumerable<T> records, string delimiter = ",", Encoding encoding = null)
            where T : class
            where TClassMap : CsvMap<T>
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    throw new ArgumentNullException("Caminho inválido.");

                if (!File.Exists(file))
                    throw new Exception("Arquivo inexistente.");

                _streamWriter = new StreamWriter(file);
                _csvWriter = new CsvWriter(_streamWriter, CultureInfo.InvariantCulture);

                _csvWriter.Configuration.RegisterClassMap<TClassMap>();
                _csvWriter.Configuration.Delimiter = delimiter;

                await _csvWriter.WriteRecordsAsync<T>(records);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}