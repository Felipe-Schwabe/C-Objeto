using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroClasse
{
    public class Usuario
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Data { get; set; }
        public string CPF { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public int Id { get; set; }

        bool linhaEditando;
    }
}