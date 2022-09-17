using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Domain
{
    public interface IContaRepository
    {
        List<Conta> BuscarTodasContas();
        List<Conta> BuscarContaPorCliente(long cpf);
        void CadastrarConta(Conta conta, long cpf);
        
    }
}
