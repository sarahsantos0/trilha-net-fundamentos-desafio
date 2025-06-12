using DesafioFundamentos.models;

Console.WriteLine("================================================");
Console.WriteLine("|    Bem-vindo ao sistema de estacionamento!   |");
Console.WriteLine("================================================\n");

int numeroDeVagas = 0;
decimal precoInicial = 0;
decimal precoPorHora = 0;
bool configurado = false;

// Configuração do estacionamento
while (!configurado)
{
    Console.WriteLine("Digite a quantidade de vagas do estacionamento:");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out numeroDeVagas) || numeroDeVagas <= 0)
    {
        Console.WriteLine("Entrada inválida. Por favor, insira um número válido de vagas.\n");
        continue;
    }

    Console.WriteLine("Digite o preço inicial do estacionamento (R$):");
    string? valor = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(valor) || !decimal.TryParse(valor, out precoInicial) || precoInicial < 0)
    {
        Console.WriteLine("Entrada inválida. Por favor, insira um preço válido.\n");
        continue;
    }

    Console.WriteLine("Digite o valor por hora (R$):");
    string? valorPorHora = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(valorPorHora) || !decimal.TryParse(valorPorHora, out precoPorHora) || precoPorHora < 0)
    {
        Console.WriteLine("Entrada inválida. Por favor, insira um valor por hora válido.\n");
        continue;
    }

    configurado = true;
    Console.Clear();
}

Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora, numeroDeVagas);

// Menu principal
bool exibirMenu = true;
while (exibirMenu)
{
    Console.WriteLine("================================================");
    Console.WriteLine("|  Sistema de Estacionamento - Menu Principal  |");
    Console.WriteLine("================================================\n");
    Console.WriteLine("                Selecione uma opção:              \n");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.WriteLine("================================================\n");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Digite a placa do veículo para cadastrar: ");
            string? placaCadastrar = Console.ReadLine();
            estacionamento.AdicionarVeiculo(placaCadastrar);
            break;

        case "2":
            Console.Write("Digite a placa do veículo para remover: ");
            string? placaRemover = Console.ReadLine();
            estacionamento.RemoverVeiculo(placaRemover);
            break;

        case "3":
            estacionamento.ListarVeiculos();
            break;

        case "4":
            Console.WriteLine("Obrigado por utilizar nosso sistema de estacionamento!");
            Console.WriteLine("Encerrando o sistema...");
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.\n");
            break;
    }

    if (exibirMenu)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}