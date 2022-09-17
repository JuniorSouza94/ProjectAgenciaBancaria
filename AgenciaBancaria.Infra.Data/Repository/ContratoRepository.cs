using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.Dao;
using AgenciaBancaria.Infra.Data.DAO;
using AgenciaBancaria.Infra.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Infra.Data.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        private static ClienteDao _clienteDao = new ClienteDao();
        private static ContratoDao _contratoDao = new ContratoDao();
        public List<Contrato> BuscarContratoPorCliente(long cpf)
        {
            var clienteBuscado = _clienteDao.BuscarPeloCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteNotFoundException();

            var contasVinsuladas = _contratoDao.BuscarContratoPorCliente(clienteBuscado);

            return contasVinsuladas;
        }
        public void CadastrarContrato(Contrato contrato, long cpf)
        {
            var clienteBuscado = _clienteDao.BuscarPeloCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteNotFoundException();

            Contrato contratoCadastrada = new Contrato(contrato, clienteBuscado);

            _contratoDao.CadastrarContrato(contratoCadastrada);
        }
    }
}
