using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialVkr
{
    public static class Config
    {
        public static string server = "178.45.197.17";
        public static string database = "vkr_industrial";
        public static string uid = "osu";
        public static string password = "12345678";

        public static string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
    }
}
