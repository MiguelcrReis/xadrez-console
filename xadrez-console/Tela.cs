using System;
using tabuleiro;
using xadrez;

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
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ________________");
            Console.WriteLine("    A B C D E F G H");
            Console.ForegroundColor = corAux;
        }
        #endregion

        #region Imprimir Tabuleiro com Posicoes Possiveis
        public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGreen;

            ConsoleColor corAux = Console.ForegroundColor;
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - i + " | ");
                Console.ForegroundColor = corAux;
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
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
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
        #endregion

        #region Imprimir Peças Capturadas
        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor corAux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corAux;
            Console.WriteLine();
        }
        #endregion

        #region Imprimir Partida
        public static void imprimirPartida(PartidaXadrez partida)
        {
            imprimirTabuleiro(partida.tabuleiro);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Jogador Atual: " + partida.jogadorAtual);
        }
        #endregion

        #region Imprimir Conjunto
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        #endregion

        #region Ler Posicao Xadrez 
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string entrada = Console.ReadLine();
            char coluna = entrada[0];
            int linha = int.Parse(entrada[1].ToString());

            return new PosicaoXadrez(coluna, linha);
        }
        #endregion
    }
}
