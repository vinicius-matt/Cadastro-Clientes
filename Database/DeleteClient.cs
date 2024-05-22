using Cad_Clientes.Cadastro;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Database
{
    public class DeleteClient
    {
        public static void Delete()
        {

            Console.WriteLine("\nDigite o CPF do cliente que deseja editar:");
            string cpf = Console.ReadLine();

            var cliente = RetrieveClients.GetClientByCPF(cpf);

            if (cliente != null)
            {
                RetrieveClients.DeleteClientByCPF(cpf);
                Console.WriteLine("Usuario deletado");
            }
            else
            {
                Console.WriteLine("usuario não encontrado");
            }
        }
    }
}

