using Cad_Clientes.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Cadastro
{
    public class Cadastro
    {
        public static void CadastrarClientes()
        {
            // Cria a tabela de clientes se ela não existir

            // Solicita os dados do cliente
            Console.WriteLine("\nCadastro de Cliente");
            Console.WriteLine("-------------------");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            string dataNascimentoStr = Console.ReadLine();

            DateTime nascimento;
            bool dataValida = DateTime.TryParseExact(dataNascimentoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nascimento);

            if (!dataValida)
            {
                Console.WriteLine("Data de nascimento inválida. Por favor, use o formato dd/MM/yyyy.");
                return;
            }

            Console.Write("CPF: ");
            string CPF = Console.ReadLine();

            Console.Write("Estado: ");
            string Estado = Console.ReadLine();

            // Insere o cliente no banco de dados
            InsertClients.InsertCliente(nome, email, telefone, nascimento, CPF, Estado);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }
    }
}
