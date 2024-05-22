using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Database
{
    public class CreateDatabase
    {
        static readonly string connectionString = "Server=localhost;Database=cadastros;User ID=root;Password=root;";
        public static void CreateTable()
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Clientes (
            Id INT AUTO_INCREMENT PRIMARY KEY,
            Nome VARCHAR(100) NOT NULL,
            Email VARCHAR(100) NOT NULL,
            Telefone VARCHAR(20) NOT NULL, 
            Nascimento DATE NOT NULL,  
            CPF CHAR(15) NOT NULL,
            Estado VARCHAR(20) NOT NULL
                 );";

            using var command = new MySqlCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }
    }
}