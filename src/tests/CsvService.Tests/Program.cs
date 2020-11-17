using CsvReaderWriterSample.Lib;
using System;
using System.Linq;

namespace CsvReaderWriterSample.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string teste1 = @"C:\Users\neph\source\repos\CsvReaderWriterSample\src\tests\username.csv";
                string teste2 = @"C:\Users\neph\source\repos\CsvReaderWriterSample\src\tests\username2.csv";

                var csvService = new CsvService();

                var objs = csvService.Read<User>(teste1, ";").ToList();

                var ob2 = csvService.Read<User, UserMap>(teste2, ";").ToList();


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}