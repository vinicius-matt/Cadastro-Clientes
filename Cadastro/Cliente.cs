using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cad_Clientes.Database;

namespace Cad_Clientes.Cadastro
{
    public class Cliente
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string CPF { get; set; }
        public required string Estado { get; set; }
    }
}