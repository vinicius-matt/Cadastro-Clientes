using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cad_Clientes.Database
{
    public class EditClient
    {
        public static void Editar()
        {
            Console.WriteLine("\nDigite o CPF do cliente que deseja editar:");
            string cpf = Console.ReadLine();

            var cliente = RetrieveClients.GetClientByCPF(cpf);

            if (cliente != null)
            {
                Console.WriteLine("\nEditando Cliente");
                Console.WriteLine($"\nNome atual: {cliente.Nome}");
                Console.WriteLine("\nDigite o novo nome (ou pressione Enter para manter o atual):");
                string nome = Console.ReadLine();
                if (!string.IsNullOrEmpty(nome)) cliente.Nome = nome;

                Console.WriteLine($"\nEmail atual: {cliente.Email}");
                Console.WriteLine("\nDigite o novo email (ou pressione Enter para manter o atual):");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) cliente.Email = email;

                Console.WriteLine($"\n Telefone atual: {cliente.Telefone}");
                Console.WriteLine("\nDigite o novo telefone (ou pressione Enter para manter o atual):");
                string telefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefone)) cliente.Telefone = telefone;

                Console.WriteLine($"\nData de Nascimento atual: {cliente.DataNascimento.ToShortDateString()}");
                Console.WriteLine("\nDigite a nova data de nascimento (ou pressione Enter para manter a atual):");
                string dataNascimentoInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataNascimentoInput))
                {
                    if (DateTime.TryParse(dataNascimentoInput, out DateTime dataNascimento))
                    {
                        cliente.DataNascimento = dataNascimento;
                    }
                    else
                    {
                        Console.WriteLine("\nData de nascimento inválida. Mantendo a atual.");
                    }
                }

                Console.WriteLine($"\nEstado atual: {cliente.Estado}");
                Console.WriteLine("\nDigite o novo estado (ou pressione Enter para manter o atual):");
                string estado = Console.ReadLine();
                if (!string.IsNullOrEmpty(estado)) cliente.Estado = estado;

                RetrieveClients.UpdateClient(cliente);
                Console.WriteLine("\nCliente atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\n Cliente não encontrado.");
            }
        }
    }
}
