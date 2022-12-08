using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        #region Imprimir Tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {
            ConsoleColor corAux = Console.ForegroundColor;
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - i + " | ");
                Console.ForegroundColor = corAux;
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (tabuleiro.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ________________");
            Console.WriteLine("    A B C D E F G H");
            Console.ForegroundColor = corAux;
        }
        #endregion

        #region Imprimir Peça
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor corAux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corAux;
            }
        }
        #endregion
    }
}
