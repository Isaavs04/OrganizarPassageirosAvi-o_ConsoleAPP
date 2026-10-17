using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        int fileira, numCol, num = 0, vagos = 0;
        string opcao, coluna, continuar = "SIM", passageiro;
        string[,] fileiras = new string[19, 4];
        bool preenchido = true;

        //Declara todas as variáveis do vetor como "vazio"
        for (int f = 0; f < fileiras.GetLength(0); f++)
        {
            for (int c = 0; c < fileiras.GetLength(1); c++)
            {
                fileiras[f, c] = "Vazio";
            }
        }

        //Laço de repetição do menu
        do
        {
            Console.Write("\nOpções\n1 - Escolher assento\n2 - Procurar passageiro\n3 - Listagem de ocupação\n4 - Verificar se lotada\nDigite a opção:  ");
            opcao = Console.ReadLine();
            switch (opcao)
            {
                //O usuário escolhe sua cadeira do avião
                case "1":
                    //Fileira digitada pelo usuário
                    do
                    {
                        Console.Write("Dgite a fileira de 1 a 19:  ");
                        fileira = int.Parse(Console.ReadLine());
                        //Ele corrige o usuário caso ele digite uma fileira inválida com números negativos ou maiores do que o avião possui
                        if (fileira < 1 || fileira > 19)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("A Fileira digitada é inválida, tente novamente\n");
                            Console.ResetColor();
                        }
                    } while (fileira < 1 || fileira > 19);
                    //Coluna digitada pelo usuário
                    do
                    {
                        Console.Write("Digite a coluna de A a D:  ");
                        coluna = Console.ReadLine().ToUpper();
                        //Ele corrige o usuário caso ele digite fileiras diferentes de A,B,C ou D
                        if (coluna != "A" && coluna != "B" && coluna != "C" && coluna != "D")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("A coluna digitada é inválida, tente novamente\n");
                            Console.ResetColor();
                        }
                    } while (coluna != "A" && coluna != "B" && coluna != "C" && coluna != "D");

                    //Convertendo as letras em números para usar na Matriz
                    if (coluna == "A")
                    {
                        numCol = 0;
                    }
                    else if (coluna == "B")
                    {
                        numCol = 1;
                    }
                    else if (coluna == "C")
                    {
                        numCol = 2;
                    }
                    else
                    {
                        numCol = 3;
                    }
                    //Verificando se o lugar está vago
                    if (fileiras[(fileira - 1), (numCol)] == "Vazio")
                    {
                        Console.Write("Lugar vago, digite seu nome:  ");
                        fileiras[(fileira - 1), (numCol)] = Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nO lugar já foi ocupado");
                        Console.ResetColor();
                        Console.Write("\nVoltando para o menu de opções\n");
                        Thread.Sleep(1000);
                    }

                    break;
                //Procurar o passageiro
                case "2":
                    Console.Write("Digite o nome do passageiro que deseja procurar:  ");
                    passageiro = Console.ReadLine();
                    for (int i = 0; i < fileiras.GetLength(0); i++)
                    {
                        for (int j = 0; j < fileiras.GetLength(1); j++)
                        {
                            if (passageiro == fileiras[i, j])
                            {
                                if (j == 0)
                                {
                                    Console.WriteLine("Passageiro(a) " + passageiro + " encontrado na posição: " + (i + 1) + " A");
                                }
                                else if (j == 1)
                                {
                                    Console.WriteLine("Passageiro(a) " + passageiro + " encontrado na posição: " + (i + 1) + " B");
                                }
                                else if (j == 2)
                                {
                                    Console.WriteLine("Passageiro(a) " + passageiro + " encontrado na posição: " + (i + 1) + " C");
                                }
                                else if (j == 3)
                                {
                                    Console.WriteLine("Passageir(a) " + passageiro + " encontrado na posição: " + (i + 1) + " D");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Passageiro não cadastrado");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }

                    break;
                //Lista todos os ligares, ocupados ou não
                case "3":
                    for (int i = 0; i < fileiras.GetLength(0); i++)
                    {
                        num++;
                        for (int j = 0; j < fileiras.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                Console.WriteLine("\nFileira nª{0}", num);
                            }
                            if (j == 0)
                            {
                                Console.WriteLine("Posição A: " + fileiras[i, j]);
                            }
                            else if (j == 1)
                            {
                                Console.WriteLine("Posição B: " + fileiras[i, j]);
                            }
                            else if (j == 2)
                            {
                                Console.WriteLine("Posição C: " + fileiras[i, j]);
                            }
                            else
                            {
                                Console.WriteLine("Posição D: " + fileiras[i, j]);
                            }
                        }
                    }
                    //Zera a variável contadora para que caso o usuário queira ver a lista mais de uma vez a contagem não continue de 20+
                    num = 0;

                    break;
                case "4":
                    for (int i = 0; i < fileiras.GetLength(0); i++)
                    {
                        num++;
                        for (int j = 0; j < fileiras.GetLength(1); j++)
                        {
                            if (fileiras[i, j] == "Vazio")
                            {
                                preenchido = false;
                                vagos++;
                            }
                        }
                    }
                    if (preenchido == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Todos os lugares foram preenchidos\n");
                        continuar = "NAO";
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Ainda tem {0} lugares vagos\n", vagos);
                    }
                    vagos = 0;

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("A opção digitada é inválida, tente novamente");
                    Console.ResetColor();
                    break;

            }
        } while (continuar == "SIM");

        Console.ReadKey();
    }
}