using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Options
{
    public class ApplicationOptions
    {
        public string ConnectionString { get; set; }

        public ApplicationOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
