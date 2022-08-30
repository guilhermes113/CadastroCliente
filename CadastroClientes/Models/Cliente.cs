using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Models
{
    public class Cliente
    {
        public Cliente(string nome, DateTime nascimento, string email)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }

        public int Id { get; private set; }
        [Required(ErrorMessage ="NOME É OBRIGATÓRIO!!!")]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "NASCIMENTO É OBRIGATÓRIO!!!")]
        [Display(Name ="Data de Nascimento")]
        public DateTime Nascimento { get; private set; }
        [Required(ErrorMessage = "E-MAIL É OBRIGATÓRIO!!!")]
        public string Email { get; private set;  }

        public int Idade()
        {
            int idade = DateTime.Now.Year;
            if (DateTime.Now.DayOfYear < Nascimento.DayOfYear)
                idade--;
            return idade;
        }
        public void AtualizarDados (string nome, DateTime nascimento, string email)
        {
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }
    }
}
