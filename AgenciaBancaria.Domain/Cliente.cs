using System;

namespace AgenciaBancaria.Domain
{
    public class Cliente
    {
        public long? Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade{ get {return CalcularIdade(); } }

        private int CalcularIdade()
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }

        public Cliente(long? cpf, string nome, DateTime dataNascimento)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }
        public Cliente()
        {

        }
        public override string ToString()
        {
            return $"\t[CLIENTE]\n Nome: {Nome}\n CPF: {Cpf}\n Idade: {Idade}";
        }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                return false;
            }
            if (this.Cpf <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
