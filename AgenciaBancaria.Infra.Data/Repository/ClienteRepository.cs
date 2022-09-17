using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.DAO;
using System.Collections.Generic;


namespace AgenciaBancaria.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private static ClienteDao _clienteDao = new ClienteDao();
        public Cliente BuscarPeloCPF(long? cpf)
        {
            return _clienteDao.BuscarPeloCPF(cpf);
        }
        public List<Cliente> BuscarTodasClientes()
        {
            return _clienteDao.BuscarTodos();
        }
    }
}
