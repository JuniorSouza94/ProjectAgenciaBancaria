using AgenciaBancaria.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Infra.Data.DAO
{
    public class ClienteDao
    {
        private string _novaConexao = @"server=.\SQLEXPRESS; initial Catalog=GESTAO_SALAS; integrated security=true";
        public List<Cliente> BuscarTodos()
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = ConverterSqlParaObjeto(leitor);
                        listaClientes.Add(clienteBuscado);
                    }
                }

                return listaClientes;
            }
        }
        public Cliente BuscarPeloCPF(long? cpf)
        {
            
            using (var conexao = new SqlConnection(_novaConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM CLIENTE WHERE CPF = @CPF";

                    comando.Parameters.AddWithValue("@CPF", cpf);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = ConverterSqlParaObjeto(leitor); 
                        return clienteBuscado;
                    }
                }
            }
            return null;
        }
        private Cliente ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var cpf = long.Parse(leitor["CPF"].ToString());
            var nome = leitor["NOME"].ToString();
            var dataNascimento = DateTime.Parse(leitor["DATA_NASCIMENTO"].ToString());

            return new Cliente(cpf, nome, dataNascimento);
        }
    }
}
