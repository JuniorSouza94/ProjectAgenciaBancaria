using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.Repository;
using System;

namespace AgenciaBancaria.ConsoleApp
{
    public static class InteracaoContratos
    {
        private static IContratoRepository _contratoRepository = new ContratoRepository();
        private static IClienteRepository _clienteRepository = new ClienteRepository();
        private static Contrato _contratos = new Contrato();
        
        public static void ListarContratosPorCliente()
        {
            Console.Clear();

            Console.WriteLine("Informe o cpf do cliente que deseja buscar:");
            var cpfCliente = long.Parse(Console.ReadLine());

            var contratoBuscada = _contratoRepository.BuscarContratoPorCliente(cpfCliente);

            Console.Clear();
            foreach (var item in contratoBuscada)
            {
                Console.WriteLine(item);
                Console.WriteLine("- - - - - - - - - - - - - - - -");
            }

            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");
        }
        public static void CadastrarNovoContrato()
        {
            Console.WriteLine("Informe o CPF do cliente cadastrado:");
            long cpfCliente = long.Parse(Console.ReadLine());

            var clienteBuscado = _clienteRepository.BuscarPeloCPF(cpfCliente);

            if (clienteBuscado != null)
            {
                Console.WriteLine("Informe o Tipo do Contrato, escolha uma das opções a baixo:");
                Console.WriteLine("   [1]-> (Empréstimo Habitacional)");
                Console.WriteLine("   [2]-> (Empréstimo Consignado)");
                Console.WriteLine("   [3]-> (CDC)");

                Console.Write("=> ");
                int tipoContrato = int.Parse(Console.ReadLine());

                switch (tipoContrato)
                {
                    case 1:
                        Console.WriteLine("Empréstimo Habitacional");
                        break;
                    case 2:
                        Console.WriteLine("Empréstimo Consignado");
                        break;
                    case 3:
                        Console.WriteLine("CDC");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!\n");
                        Console.WriteLine("Aperte qualquer tecla para retornar.");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine("\nInforme o valor total do empréstimo:");
                decimal.TryParse(Console.ReadLine(), out decimal valorTotal);

                Console.WriteLine("Informe o número de parcelas:");
                int.TryParse(Console.ReadLine(), out int qtdParcelas);

                var valorParcela = valorTotal / qtdParcelas;

                Console.WriteLine($"O valor da parcela é de: R$ {Math.Round(valorParcela)}");

                var dataInicial = DateTime.Now;

                var dataFinal = DateTime.Now.AddMonths(qtdParcelas);

                _contratos = new Contrato((TipoContrato)tipoContrato, qtdParcelas, dataInicial, dataFinal, valorTotal, clienteBuscado);
                _contratos.TipoContrato = (TipoContrato)tipoContrato;
                _contratos.QuantidadeParcelas = qtdParcelas;
                _contratos.DataInicial = dataInicial;
                _contratos.DataFinal = dataFinal;
                _contratos.ValorTotal = valorTotal;
                _contratos.Cliente = clienteBuscado;

                _contratoRepository.CadastrarContrato(_contratos, cpfCliente);

                Console.WriteLine("\nEmprestimo realizado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Cliente não foi encontrado!\n");
            }

            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");
        }


    }
}
