using AgenciaBancaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Domain
{
    public class Conta 
    {
        public int Numero { get; set; }
        public int Digito { get; set; }
        public string Agencia { get; set; }
        public TipoConta TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public DateTime DataDeAbertura { get; set; }
        public Cesta? Cesta { get; set; }
        public Cliente Cliente { get; set; }
        public Conta(int numero, int digito, string agencia, TipoConta tipoConta, decimal saldo, decimal limite, DateTime dataDeAbertura, Cesta? cesta, Cliente cliente)
        {
            Numero = numero;
            Digito = digito;
            Agencia = agencia;
            TipoConta = tipoConta;
            Saldo = saldo;
            Limite = limite;
            DataDeAbertura = dataDeAbertura;
            Cesta = cesta;
            Cliente = cliente;
        }
        public Conta(Conta conta, Cliente cliente)
        {
            this.DataDeAbertura = DateTime.Now;
            this.Numero = conta.Numero; 
            this.Digito = conta.Digito; 
            this.Agencia = conta.Agencia;
            this.Saldo = conta.Saldo;
            this.Limite = conta.Limite;
            this.Cliente = cliente;
            this.Cesta = conta.Cesta;
            this.TipoConta = conta.TipoConta;           

        }   
        public Conta()
        {
            
        }
        public override string ToString()
        {
            return $"\t[CONTA]\n Cliente: {this.Cliente.Nome}\n Conta: {Numero}-{Digito}\n Agencia: {Agencia}\n TipoConta: {TipoConta}\n" +
                $" Saldo: {Saldo}\n Limite: {Limite}\n Data De Abertura: {DataDeAbertura.ToShortDateString()}\n Cesta: {Cesta}";
        }

    }
}
