using AgenciaBancaria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ContaDao
    {
        private string _novaConexao = @"server=.\SQLEXPRESS; initial Catalog=CONTA_BANCARIA; integrated security=true";
        public List<Conta> BuscarTodos()
        {
            var listaContas = new List<Conta>();

            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT C.*, CL.NOME FROM CONTA C 
                                    INNER JOIN CLIENTE CL ON C.CPF_CLIENTE = CL.CPF";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Conta contaBuscada = ConverterSqlParaObjeto(leitor);
                        listaContas.Add(contaBuscada);
                    }
                }

                return listaContas;
            }
        }
        public void CadastrarConta(Conta conta)
        {
            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO CONTA VALUES (@NUMERO,
                                                                    @DIGITO,
                                                                    @AGENCIA,
                                                                    @TIPO_CONTA,
                                                                    @SALDO,
                                                                    @LIMITE,
                                                                    @DATA_ABERTURA,
                                                                    @CESTA,
                                                                    @CPF_CLIENTE)";

                    ConverterObjetoParaParametrosSQL(conta, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Conta> BuscarContaPorCliente(Cliente cliente)
        {
            var listaContasCliente = new List<Conta>();

            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT C.*, CL.NOME FROM CONTA C 
                                    INNER JOIN CLIENTE CL ON C.CPF_CLIENTE = CL.CPF WHERE CPF_CLIENTE = @CPF";

                    comando.Parameters.AddWithValue("@CPF", cliente.Cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Conta clienteBuscado = ConverterSqlParaObjeto(leitor);
                        listaContasCliente.Add(clienteBuscado);
                    }
                }
            }
            return listaContasCliente;
        }
        public Conta ValidarContaPorNumero(int numeroConta)
        {
            Conta conta = new Conta();

            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT C.*, CL.NOME FROM CONTA C 
                                    INNER JOIN CLIENTE CL ON C.CPF_CLIENTE = CL.CPF WHERE NUMERO = @NUMERO";

                    comando.Parameters.AddWithValue("@NUMERO", numeroConta);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        conta = ConverterSqlParaObjeto(leitor);
                        return conta;
                    }
                }
            }
            return null;
        }
        private Conta ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var numero = int.Parse(leitor["NUMERO"].ToString());
            var digito = int.Parse(leitor["DIGITO"].ToString());
            var agencia = leitor["AGENCIA"].ToString();
            var tipoConta = int.Parse(leitor["TIPO_CONTA"].ToString());
            var Saldo = decimal.Parse(leitor["SALDO"].ToString());
            var Limite = decimal.Parse(leitor["LIMITE"].ToString());
            var dataDeAbertura = Convert.ToDateTime(leitor["DATA_ABERTURA"].ToString());
            var cesta = int.Parse(leitor["CESTA"].ToString());
            Cliente cliente = new Cliente();
            cliente.Cpf = long.Parse(leitor["CPF_CLIENTE"].ToString());
            cliente.Nome = leitor["NOME"].ToString();

            return new Conta(numero, digito, agencia, (TipoConta)tipoConta, Saldo, Limite, dataDeAbertura, (Cesta)cesta, cliente);
        }
        private void ConverterObjetoParaParametrosSQL(Conta conta, SqlCommand command)
        {
            command.Parameters.AddWithValue("@NUMERO", conta.Numero);
            command.Parameters.AddWithValue("@DIGITO", conta.Digito);
            command.Parameters.AddWithValue("@AGENCIA", conta.Agencia);
            command.Parameters.AddWithValue("@TIPO_CONTA", conta.TipoConta);
            command.Parameters.AddWithValue("@SALDO", conta.Saldo);
            command.Parameters.AddWithValue("@LIMITE", conta.Limite);
            command.Parameters.AddWithValue("@DATA_ABERTURA", conta.DataDeAbertura);
            command.Parameters.AddWithValue("@CESTA", conta.Cesta);
            command.Parameters.AddWithValue("@CPF_CLIENTE", conta.Cliente.Cpf);
        }
    }
}
