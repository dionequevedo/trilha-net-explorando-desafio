using System.Text;
using System.Globalization;
using DesafioProjetoHospedagem.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite();
Reserva reserva = new Reserva();

bool exibirMenu = true;
string op = "";

do
{
    Console.Clear();
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Cadastrar Hospedes");
    Console.WriteLine("2 - Cadastrar Suites");
    Console.WriteLine("3 - Calcular Diárias");
    Console.WriteLine("4 - Sair");
    Console.Write("Opção: ");
    op = Console.ReadLine();

    switch (op)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("\t* * * CADASTRO DE HOSPEDE * * *\n");
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o sobrenome: ");
            string sobrenome = Console.ReadLine();
            hospedes.Add(new Pessoa(nome, sobrenome));
            Console.WriteLine("\n\tHOSPEDE CADASTRADO COM SUCESSO!");
            Console.ReadKey();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("\t* * * CADASTRO DE SUÍTE * * *\n");
            Console.Write("Informe o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();
            Console.Write("Informe a quantidade de hospedes: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o valor da diária: R$ ");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());
            suite.TipoSuite     = tipoSuite;
            suite.Capacidade    = capacidade;
            suite.ValorDiaria   = valorDiaria;
            Console.WriteLine("\n\tSUÍTE CADASTRADA COM SUCESSO!");
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("\t* * * CALCULAR DIÁRIAS * * *\n");
            Console.Write("Informe a quantidade de diárias: ");
            int diasReservados = Convert.ToInt32(Console.ReadLine());
            // Cria uma nova reserva, passando a suíte e os hóspedes
            reserva.DiasReservados = diasReservados;
            reserva.CadastrarSuite(suite);
            try
            {
                reserva.CadastrarHospedes(hospedes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                break;
            }
            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            Console.ReadKey();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("\t* * * SISTEMA ENCERRADO COM SUCESSO! * * *\n");
            Console.ReadKey();
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("\n\tOpção inválida");
            Console.ReadKey();
            break;
    }
} while(exibirMenu);
