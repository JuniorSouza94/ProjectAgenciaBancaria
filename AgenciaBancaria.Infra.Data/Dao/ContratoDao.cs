
using AgenciaBancaria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Infra.Data.Dao
{
    public class ContratoDao
    {
        private string _novaConexao = @"server=.\SQLEXPRESS; initial Catalog=CONTA_BANCARIA; integrated security=true";
        public void CadastrarContrato(Contrato contrato)
        {
            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO CONTRATOS VALUES (@TIPO,
                                                                    @QUANTIDADE_PARCELAS,
                                                                    @DATA_INICIAL,
                                                                    @DATA_FINAL,
                                                                    @VALOR_TOTAL,                                                                
                                                                    @CPF_CLIENTE)";

                    ConverterObjetoParaParametrosSQL(contrato, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Contrato> BuscarContratoPorCliente(Cliente cliente)
        {
            var listaContratosCliente = new List<Contrato>();

            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT CT.*, CL.NOME, CL.CPF FROM CONTRATOS CT 
                                    INNER JOIN CLIENTE CL ON CL.CPF = CT.CPF_CLIENTE WHERE CT.CPF_CLIENTE = @CPF";

                    comando.Parameters.AddWithValue("@CPF", cliente.Cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Contrato clienteBuscado = ConverterSqlParaObjeto(leitor);
                        listaContratosCliente.Add(clienteBuscado);
                    }
                }
            }
            return listaContratosCliente;
        }
        private Contrato ConverterSqlParaObjeto(SqlDataReader leitor)
        {   
            var numeroContrato = int.Parse(leitor["NUMERO_CONTRATO"].ToString());
            var tipoContrato = int.Parse(leitor["TIPO"].ToString());
            var qtdParcelas = int.Parse(leitor["QUANTIDADE_PARCELAS"].ToString());
            var dataInicial = DateTime.Parse(leitor["DATA_INICIAL"].ToString());
            var dataFinal = DateTime.Parse(leitor["DATA_FINAL"].ToString());
            var valorTotal = decimal.Parse(leitor["VALOR_TOTAL"].ToString());
            Cliente cliente = new Cliente();
            cliente.Cpf = long.Parse(leitor["CPF_CLIENTE"].ToString());
            cliente.Nome = leitor["NOME"].ToString();

            return new Contrato(numeroContrato, tipoContrato, qtdParcelas, dataInicial, dataFinal, valorTotal, cliente);

        }
        private void ConverterObjetoParaParametrosSQL(Contrato contrato, SqlCommand command)
        {
            command.Parameters.AddWithValue("@TIPO", contrato.TipoContrato);
            command.Parameters.AddWithValue("@QUANTIDADE_PARCELAS", contrato.QuantidadeParcelas);
            command.Parameters.AddWithValue("@DATA_INICIAL", contrato.DataInicial);
            command.Parameters.AddWithValue("@DATA_FINAL", contrato.DataFinal);
            command.Parameters.AddWithValue("@VALOR_TOTAL", contrato.ValorTotal);
            command.Parameters.AddWithValue("@CPF_CLIENTE", contrato.Cliente.Cpf);
        }
    }
}
