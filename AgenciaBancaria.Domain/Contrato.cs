using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Domain
{
    public class Contrato
    {
        public int NumeroContrato { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataInicial { get; set;}
        public DateTime DataFinal { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }

        public Contrato()
        {
            
        }
        public Contrato(TipoContrato tipoContrato, int quantidadeParcelas, DateTime dataInicial, DateTime dataFinal, decimal valorTotal, Cliente cliente)
        {       
            TipoContrato = tipoContrato;
            QuantidadeParcelas = quantidadeParcelas;
            dataInicial = DateTime.Now;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            ValorTotal = valorTotal;
            Cliente = cliente;
        }
        public Contrato(int numeroContrato, int tipoContrato, int qtdParcelas, DateTime dataInicial, DateTime dataFinal, decimal valorTotal, Cliente cliente)
        {
            NumeroContrato = numeroContrato;
            TipoContrato = (TipoContrato)tipoContrato;
            QuantidadeParcelas = qtdParcelas;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            ValorTotal = valorTotal;
            Cliente = cliente;
        }

        public Contrato(Contrato contrato, Cliente clienteBuscado)
        {
            this.NumeroContrato = contrato.NumeroContrato;
            this.TipoContrato = contrato.TipoContrato;
            this.QuantidadeParcelas = contrato.QuantidadeParcelas;
            this.DataInicial = contrato.DataInicial;
            this.DataFinal = contrato.DataFinal;
            this.ValorTotal = contrato.ValorTotal;
            this.Cliente = clienteBuscado;

        }

        public override string ToString()
        {
            return $"\t[CONTRATO]\n NºContrato: {NumeroContrato}\n Tipo Do Contrato: {TipoContrato}\n Valor Total: {ValorTotal}\n"
                    +$" Quantidade de Parcelas {QuantidadeParcelas}\n Valor da parcela: {Math.Round(ValorTotal/QuantidadeParcelas)}\n Data inicial: {DataInicial.ToShortDateString()}\n"
                    +$" Data final: {DataFinal.ToShortDateString()}\n Nome: {Cliente.Nome}\n CPF: {Cliente.Cpf}";
        }


    }
}
