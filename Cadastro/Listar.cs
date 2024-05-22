using Cad_Clientes.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Cadastro
{
    public class Listar
    {
       public static void ListarClientes()
       {
                Console.WriteLine("\nLista de Clientes Cadastrados");
                Console.WriteLine("-----------------------------");

                var clientes = RetrieveClients.GetAllClients();
                
                if (clientes.Count != 0)
                {
                    foreach (var cliente in clientes)
                    {
                        Console.WriteLine($"Nome: {cliente.Nome}");
                        Console.WriteLine($"Email: {cliente.Email}");
                        Console.WriteLine($"Telefone: {cliente.Telefone}");
                        Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToShortDateString()}");
                        Console.WriteLine($"CPF: {cliente.CPF}");
                        Console.WriteLine($"Estado: {cliente.Estado}");
                        Console.WriteLine("-----------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                }
       }
    }
}

