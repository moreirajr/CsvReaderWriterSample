using CsvReaderWriterSample.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvReaderWriterSample.Tests
{
    public class UserMap : CsvMap<User>
    {
        public UserMap()
        {
            Map(m => m.Username).Name("Username");
            Map(m => m.Identifier).Name("Identifier");
            Map(m => m.FirstName).Name("First name");
            Map(m => m.LastName).Name("Last name");
        }
    }
}
