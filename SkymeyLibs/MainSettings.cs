using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkymeyLibs
{
    public class MainSettings
    {
        public MongoDatabase MongoDatabase { get; set; }
    }
    public class MongoDatabase
    {
        public string DBName { get; set; }
        public string DBServer { get; set; }
    }
}
