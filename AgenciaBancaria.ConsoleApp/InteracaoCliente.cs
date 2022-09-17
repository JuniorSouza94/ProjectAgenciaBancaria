using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.Repository;
using System;

namespace AgenciaBancaria.ConsoleApp
{
    public class InteracaoCliente
    {
        private static IClienteRepository _clienteRepository = new ClienteRepository();
        public static void BuscarClientesPorCpf()
        {
            Console.Clear();

            Console.WriteLine("Informe o cpf do cliente que deseja buscar:");
            var cpfCliente = long.Parse(Console.ReadLine());

            var buscaCPF = _clienteRepository.BuscarPeloCPF(cpfCliente);

            if (buscaCPF != null)
            {
                Console.WriteLine(buscaCPF);
                Console.WriteLine("- - - - - - - - - - - - - - - -");
            }
            else
            {
                Console.WriteLine("Cliente não foi encontrado");
            }
            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");
        }

        public static void ListarTodosClientes()
        {
            var clientes = _clienteRepository.BuscarTodasClientes();

            Console.Clear();
            foreach (var item in clientes)
            {
                Console.WriteLine(item);
                Console.WriteLine("- - - - - - - - - - - - - - - -");
            }
            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");
        }

    }
}
