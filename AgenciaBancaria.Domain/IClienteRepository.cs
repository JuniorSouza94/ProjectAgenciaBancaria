using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Domain
{
    public interface IClienteRepository
    {
        List<Cliente> BuscarTodasClientes();
        Cliente BuscarPeloCPF(long? cpf);
    }
}
