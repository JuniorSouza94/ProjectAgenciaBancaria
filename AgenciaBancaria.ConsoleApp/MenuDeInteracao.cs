using System;

namespace AgenciaBancaria.ConsoleApp
{
    public class MenuDeInteracao
    {
        private static string _opcao;
        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("============= MENU =============");
                Console.WriteLine("[1] -> Listar todos clientes"); //ok
                Console.WriteLine("[2] -> Buscar cliente por cpf"); //ok
                Console.WriteLine("[3] -> Cadastrar nova conta"); //ok
                Console.WriteLine("[4] -> Mostrar todas as contas"); //ok
                Console.WriteLine("[5] -> Buscar conta por cliente"); //ok
                Console.WriteLine("[6] -> Cadastrar novo contrato de empréstimo");
                Console.WriteLine("[7] -> Buscar contratos por cliente");
                Console.WriteLine("[0] -> Sair");
                Console.Write("=> ");
                _opcao = Console.ReadLine();

                switch (_opcao)
                {
                    case "1":
                        Console.Clear();
                        InteracaoCliente.ListarTodosClientes();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        InteracaoCliente.BuscarClientesPorCpf();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        InteracaoConta.CadastrarNovaConta();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        InteracaoConta.MostrarTodasAsContas();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        InteracaoConta.BuscarContaPorCliente();
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        InteracaoContratos.CadastrarNovoContrato();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        InteracaoContratos.ListarContratosPorCliente();
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.WriteLine("Até mais...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!\n");
                        Console.WriteLine("Aperte qualquer tecla para retornar.");
                        Console.ReadKey();
                        break;
                }
            } while (_opcao != "0");
        }

    }
}
