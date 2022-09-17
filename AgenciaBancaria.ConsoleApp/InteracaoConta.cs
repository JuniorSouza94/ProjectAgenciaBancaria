using AgenciaBancaria.Domain;
using AgenciaBancaria.Infra.Data.Repository;
using System;

namespace AgenciaBancaria.ConsoleApp
{
    public class InteracaoConta
    {
        private static IContaRepository _contaRepository = new ContaRepository();
        private static IClienteRepository _clienteRepository = new ClienteRepository();
        public static void BuscarContaPorCliente()
        {
            Console.Clear();

            Console.WriteLine("Informe o cpf do cliente que deseja buscar:");
            var cpfCliente = long.Parse(Console.ReadLine());

            var contaBuscada = _contaRepository.BuscarContaPorCliente(cpfCliente);

            Console.Clear();
            foreach (var item in contaBuscada)
            {
                Console.WriteLine(item);
                Console.WriteLine("- - - - - - - - - - - - - - - -");
            }

            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");

        }
        public static void MostrarTodasAsContas()
        {
            var contasBuscadas = _contaRepository.BuscarTodasContas();

            Console.Clear();
            foreach (var conta in contasBuscadas)
            {
                Console.WriteLine(conta);
                Console.WriteLine("- - - - - - - - - - - - - - - -");
            }
            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");
        }
        public static void CadastrarNovaConta()
        {

            Console.WriteLine("Informe o CPF do cliente cadastrado:");
            long cpfCliente = long.Parse(Console.ReadLine());

            var clienteBuscado = _clienteRepository.BuscarPeloCPF(cpfCliente);

            if (clienteBuscado != null)
            {
                Console.Write("=> ");
                Console.WriteLine("Informe o número da conta:");
                int numero = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe o dígito:");
                int digito = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a agência:");
                string agencia = Console.ReadLine();

                Console.WriteLine("Informe o saldo:");
                decimal saldo = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Informe o Limite:");
                decimal limite = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Informe o Tipo de conta, escolha uma das opções a baixo:");
                Console.WriteLine("   [0]-> (013 - Poupança)");
                Console.WriteLine("   [1]-> (1288 - Fácil)");
                Console.WriteLine("   [2]-> (001 - Corrente)");
                Console.Write("=> ");
                int tipoConta = int.Parse(Console.ReadLine());

                int cesta = 0;

                switch (tipoConta)
                {
                    case 0:
                        Console.WriteLine("013 - Conta Poupança");
                        cesta = 0;
                        break;
                    case 1:
                        Console.WriteLine("1288 - Conta Fácil");
                        cesta = 0;
                        break;
                    case 2:
                        Console.WriteLine("001 - Conta Corrente");
                        if (limite <= 1000 && limite >= 0)
                            cesta = 1;
                        else if (limite > 1000 && limite <= 5000)
                            cesta = 2;
                        else if (limite > 5000)
                            cesta = 3;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!\n");
                        Console.WriteLine("Aperte qualquer tecla para retornar.");
                        Console.ReadKey();
                        break;
                }
                DateTime abertura = DateTime.Now;

                Conta cadastro = new Conta(numero, digito, agencia, (TipoConta)tipoConta, saldo, limite, abertura, (Cesta)cesta, clienteBuscado);
                cadastro.Numero = numero;
                cadastro.Digito = digito;
                cadastro.Agencia = agencia;
                cadastro.TipoConta = (TipoConta)tipoConta;
                cadastro.Saldo = saldo;
                cadastro.Limite = limite;
                cadastro.DataDeAbertura = abertura;
                cadastro.Cesta = (Cesta)cesta;
                cadastro.Cliente = clienteBuscado;

                _contaRepository.CadastrarConta(cadastro, cpfCliente);

                Console.Clear();

                Console.WriteLine("Cadastro realizado com sucesso!");

            }
            else
            {
                Console.WriteLine("Cliente não foi encontrado!\n");
            }

            Console.WriteLine("Aperte qualquer tecla para retornar ao menu principal");

        }

    }
}
