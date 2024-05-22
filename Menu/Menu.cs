using Cad_Clientes.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cad_Clientes.Cadastro;

namespace Cad_Clientes.Menu
{
    public class Menu
    {
        public Menu() 
        {      
            {
                bool continuar = true;

                while (continuar)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("1 - Cadastrar Cliente");
                    Console.WriteLine("2 - Listar Clientes");
                    Console.WriteLine("3 - Editar Cliente");
                    Console.WriteLine("4 - Excluir Cliente");
                    Console.WriteLine("5 - Sair");
                    Console.WriteLine("----------------------");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Cadastro.Cadastro.CadastrarClientes();
                            break;
                        case "2":
                            Listar.ListarClientes();
                            break;
                        case "3":
                            EditClient.Editar();
                            break;
                        case "4":
                            DeleteClient.Delete();
                            break;
                        case "5":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            break;
                    }
                }
            }
        }   
    }
}
