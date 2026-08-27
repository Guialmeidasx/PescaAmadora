const double LimiteAguasContinentais = 10;
const double LimiteAguasMarinhas = 15;

const decimal MultaBase = 1000;
const decimal MultaExcesso = 20;

Console.Clear();

Console.WriteLine("================================");
Console.WriteLine("       🎣 PESCA AMADORA");
Console.WriteLine("================================\n");

double pesoPescado;

while (true)
{
    Console.Write("Peso do pescado (kg): ");

    if (double.TryParse(Console.ReadLine(), out pesoPescado) &&
        pesoPescado > 0)
    {
        break;
    }

    Console.WriteLine("Digite um peso válido.\n");
}

string localPesca;

while (true)
{
    Console.Write("Águas [C]ontinentais ou [M]arinhas? ");
    localPesca = Console.ReadLine()!.Trim().ToUpper();

    if (localPesca == "C" || localPesca == "M")
        break;

    Console.WriteLine("Opção inválida. Digite C ou M.\n");
}

double limite = localPesca == "C"
    ? LimiteAguasContinentais
    : LimiteAguasMarinhas;

Console.WriteLine();

if (pesoPescado <= limite)
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("✓ Pescaria dentro dos limites legais.");

    Console.ResetColor();
}
else
{
    double excesso = pesoPescado - limite;

    decimal multa =
        MultaBase + (MultaExcesso * (decimal)excesso);

    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(
        $"✗ Limite excedido em {excesso:N2} kg."
    );

    Console.WriteLine(
        $"Multa estimada: {multa:C}"
    );

    Console.ResetColor();
}

Console.WriteLine("\nObrigado por utilizar o programa!");