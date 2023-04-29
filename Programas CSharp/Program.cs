using System;
using System.Globalization;
using System.Runtime.CompilerServices;

class Investimentos
{
    static void Main()
    {
        CultureInfo cultura = new CultureInfo("pt-BR");
        double investimento;
        double capital = 0;
        double valor_desejado;
        double tempo;
        double rent;

        Console.Write("Digite o valor que deseja investir mensalmente: R$");
        string input0 = Console.ReadLine();
        while (!double.TryParse(input0, out investimento))
        {
            Console.WriteLine("\nDigite um valor válido. Ex: (200, 500.50)");
            Console.Write("Digite o valor que deseja investir mensalmente: R$");
            input0 = Console.ReadLine();
        };

        Console.Write("Digite o valor que deseja alcançar: R$");
        string input1 = Console.ReadLine();
        while(!double.TryParse(input1, out valor_desejado))
        {
            Console.WriteLine("\nDigite um valor válido. Ex: (200, 500.50)");
            Console.Write("Digite o valor que deseja alcançar: R$");
            input1 = Console.ReadLine();
        };

        Console.Write("Digite o tempo que vai investir (anos): ");
        string input2 = Console.ReadLine();
        while (!double.TryParse(input2, out tempo))
        {
            Console.WriteLine("\nDigite um tempo válido. Ex: (2, 2,7)");
            Console.Write("Digite o tempo que vai investir (anos): ");
            input2 = Console.ReadLine();
        };

        Console.Write("Digite a rentabilidade anual: ");
        string input3 = Console.ReadLine().Replace("%", "");
        while (!double.TryParse(input3, out rent))
        {
            Console.WriteLine("\nDigite uma rentabilidade válida. Ex: (12%, 15.4%)");
            Console.Write("Digite a rentabilidade anual: ");
            input3 = Console.ReadLine().Replace("%", "");
        };

        int tempo_m = (int)Math.Round(tempo * 12);
        double rent_m = rent / 12;

        List<double> capital_list = new List<double>();
        {
            bool meta_realizada = false;
            for (int i = 1; i <= tempo_m; i++)
            {

                capital += capital * (rent_m / 100) + investimento;
                capital_list.Add(capital);

                int ano = i / 12;
                if (i % 12 == 0)
                {
                    if (capital >= valor_desejado && !meta_realizada)
                    {
                        Console.WriteLine(ano + "º ano, capital total: " + capital.ToString("C", cultura) + " - Meta Alcançada");
                        meta_realizada = true;
                    }
                    else
                        Console.WriteLine(ano + "º ano, capital total: " + capital.ToString("C", cultura));
                }
                if (i == tempo_m)
                {

                    Console.WriteLine("\nCapital final em " + tempo + " ano(s): " + capital.ToString("C", cultura));
                    Console.WriteLine("Dinheiro investido: " + (investimento * tempo_m).ToString("C", cultura) + " Dinheiro sobre juros: " + (capital - investimento * tempo_m).ToString("C", cultura));
                    double capital_meta = capital;
                    if (!meta_realizada)
                    {
                        double ind = 0;
                        while (valor_desejado > capital_meta)
                        {
                            capital_meta += capital_meta * (rent_m / 100) + investimento;
                            ind++;
                        }
                        Console.WriteLine("Falta " + (valor_desejado - capital).ToString("C", cultura) + " para atingir sua meta!");
                        Console.WriteLine("Invista por mais " + Math.Round(ind / 12, 1) + " anos (" + ind + " meses) para alcaçar sua meta com um capital de: " + capital_meta.ToString("C", cultura));

                    }
                }
            }
        }

        Console.Write("\nDeseja ver o detalhamento mensal? ");
        string input4 = Console.ReadLine().ToLower();
        while (input4 != "sim" && input4 != "nao" && input4 != "não")
        {
            Console.WriteLine("\nDigite \"sim\" ou \"nao\"");
            Console.Write("Deseja ver o detalhamento mensal? ");
            input4 = Console.ReadLine();
        };

        if(input4 == "sim")
        {
            bool meta_realizada = false;
            for (int i = 1;i <= tempo_m;i++)
            {
                if (capital_list[i-1] >= valor_desejado && !meta_realizada)
                {
                    Console.WriteLine(i + "º mês, capital total: " + capital_list[i - 1].ToString("C", cultura) + " - Meta Alcançada");
                    meta_realizada = true;
                }
                else
                    Console.WriteLine(i + "º mês, capital total: " + capital_list[i-1].ToString("C", cultura));
            }
        }

        Console.ReadLine();
    }
}

    