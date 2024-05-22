using Cad_Clientes.Cadastro;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Database
{
    public class InsertClients
    {
        static readonly string connectionString = "Server=localhost;Database=cadastros;User ID=root;Password=root;";
        public static void InsertCliente(string nome, string email, string telefone, DateTime Nascimento, string CPF, string Estado)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO Clientes (Nome, Email, Telefone,Nascimento,CPF,Estado) VALUES (@Nome, @Email, @Telefone,@Nascimento, @CPF, @Estado);";

            using var command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Telefone", telefone);
            command.Parameters.AddWithValue("@Nascimento", Nascimento);
            command.Parameters.AddWithValue("@CPF", CPF);
            command.Parameters.AddWithValue("@Estado", Estado);
            command.ExecuteNonQuery();
        }
    }

    public static class RetrieveClients
    {
        static readonly string connectionString = "Server=localhost;Database=cadastros;User ID=root;Password=root;";

        public static List<Cliente> GetAllClients()
        {
            List<Cliente> clientes = [];

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Nome, Email, Telefone, Nascimento, CPF, Estado FROM Clientes;";

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new()
                    {
                        Nome = reader.GetString("Nome"),
                        Email = reader.GetString("Email"),
                        Telefone = reader.GetString("Telefone"),
                        DataNascimento = reader.GetDateTime("Nascimento"),
                        CPF = reader.GetString("CPF"),
                        Estado = reader.GetString("Estado")
                    };

                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

    public static Cliente GetClientByCPF(string cpf)
         {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Nome, Email, Telefone, Nascimento, CPF, Estado FROM Clientes WHERE CPF = @CPF;";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@CPF", cpf);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                Cliente cliente = new()
                {
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email"),
                    Telefone = reader.GetString("Telefone"),
                    DataNascimento = reader.GetDateTime("Nascimento"),
                    CPF = reader.GetString("CPF"),
                    Estado = reader.GetString("Estado")
                };

                return cliente;
            }
            else
            {
                return null;   
            }
        }

        public static void UpdateClient(Cliente cliente)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string updateQuery = "UPDATE Clientes " +
                "SET Nome = @Nome, " +
                "Email = @Email, " +
                "Telefone = @Telefone, " +
                "Nascimento = @Nascimento, " +
                "Estado = @Estado " +
                "WHERE CPF = @CPF;";

            using var command = new MySqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            command.Parameters.AddWithValue("@Nascimento", cliente.DataNascimento);
            command.Parameters.AddWithValue("@Estado", cliente.Estado);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);

            command.ExecuteNonQuery();
        }
        public static void DeleteClientByCPF(string cpf)
        {
         using var connection = new MySqlConnection(connectionString);
         connection.Open();

         string deleteQuery = "DELETE FROM Clientes WHERE CPF = @CPF;";

         using var command = new MySqlCommand(deleteQuery, connection);
         command.Parameters.AddWithValue("@CPF", cpf);

         command.ExecuteNonQuery();
        }
    }
}