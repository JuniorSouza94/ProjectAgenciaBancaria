using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Domain
{
    public interface IContratoRepository
    {
        List<Contrato> BuscarContratoPorCliente(long cpf);
        void CadastrarContrato(Contrato contrato, long cpf);
    }
}
