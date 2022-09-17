using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.DAO;
using AgenciaBancaria.Infra.Data.Exceptions;
using System;
using System.Collections.Generic;

namespace AgenciaBancaria.Infra.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private static ContaDao _contaDao = new ContaDao();
        private static ClienteDao _clienteDao = new ClienteDao();
        public List<Conta> BuscarContaPorCliente(long cpf)
        {
            var clienteBuscado = _clienteDao.BuscarPeloCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteNotFoundException();

            var contasVinsuladas = _contaDao.BuscarContaPorCliente(clienteBuscado);

            return contasVinsuladas;

        }
        public List<Conta> BuscarTodasContas()
        {   
            return _contaDao.BuscarTodos();
        }
        public void CadastrarConta(Conta conta, long cpf)
        {
            var clienteBuscado = _clienteDao.BuscarPeloCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteNotFoundException();

            Conta contaCadastrada = new Conta(conta, clienteBuscado);

            var contaNova = _contaDao.ValidarContaPorNumero(conta.Numero);

            if (contaNova != null)
                throw new ContaJaExisteException();
            

            _contaDao.CadastrarConta(contaCadastrada);

        }

    }
}
