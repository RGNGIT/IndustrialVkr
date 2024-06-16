using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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

        // Справочники
        public void AddJobTitle(string name, string shortName) 
        {
            string query = $"INSERT INTO job_title (name, shortName) VALUES ('{name}', '{shortName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddPhys(string name, string lastName, string middleName)
        {
            string query = $"INSERT INTO phys (name, lastName, middleName) VALUES ('{name}', '{lastName}', '{middleName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddRejectionReason(string name, string shortName)
        {
            string query = $"INSERT INTO rejection_reason (name, shortName) VALUES ('{name}', '{shortName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddEquipmentType(string name, string shortName)
        {
            string query = $"INSERT INTO equipment_type (name, shortName) VALUES ('{name}', '{shortName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddEquipmentModel(string name, string shortName)
        {
            string query = $"INSERT INTO equipment_model (name, shortName) VALUES ('{name}', '{shortName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddZone(string name, string shortName)
        {
            string query = $"INSERT INTO zone (name, shortName) VALUES ('{name}', '{shortName}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        // Прочие данные
        public void AddEquipmentDictionary(string name, string shortName, int eqTypeId) 
        {
            string query = $"INSERT INTO equipment_dictionary (name, shortName, equipment_type_id) VALUES ('{name}', '{shortName}', '{eqTypeId}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddEmployeeRole(string openDate, string closeDate, int physId, int jobTitleId, int zoneId) 
        {
            string query = $"INSERT INTO employee_role (openDate, closeDate, phys_id, job_title_id, zone_id) VALUES ('{openDate}', '{closeDate}', '{physId}', '{jobTitleId}', '{zoneId}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddEquipment(string number, int dirId, int modelId) 
        {
            string query = $"INSERT INTO equipment (number, equipment_dictionary_id, equipment_model_id) VALUES ('{number}', '{dirId}', '{modelId}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddRejection(string rejectionDate, string resumeDate, int rejectionId, int directoryId, int equipmentId, int attachmentId) 
        {
            string query = $"INSERT INTO equipment_rejection (dateOfRejection, dateOfResume, rejection_reason_id, equipment_dictionary_id, equipment_id, equipment_attach_id) VALUES ('{rejectionDate}', '{resumeDate}', '{rejectionId}', '{directoryId}', '{equipmentId}', '{attachmentId}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void AddAttachment(string dateOfAttachment, string dateOfDettachment, int zoneId, int employeeRoleId, int equipmentId)
        {
            string query = $"INSERT INTO equipment_attach (dateOfAttachment, zone_id, employee_role_id, equipment_id) VALUES ('{dateOfAttachment}', '{zoneId}', '{employeeRoleId}', '{equipmentId}');";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void DetachAttachment(int id, string dateOfDettachment) 
        {
            string query = $"UPDATE equipment_attach SET dateOfDettachment = '{dateOfDettachment}' WHERE id = {id};";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        public void UpdateJobTitle(string name, string shortName, int id) 
        {
            string query = $"UPDATE job_title SET name = '{name}', shortName = '{shortName}' WHERE id = {id};";
            MySqlCommand command = new MySqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }
    }
}
