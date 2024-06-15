using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace IndustrialVkr
{
    internal class DatabaseConnection: IDisposable
    {
        private readonly MySqlConnection _connection;

        public DatabaseConnection()
        {
            _connection = new MySqlConnection(Config.connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }

        public DataTable SelectScript(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
