using tabuleiro;
using xadrez;
using xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaXadrez partida = new PartidaXadrez();
            Console.Write("Nova Partida Iniciada: ");

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Jogador Atual: " + partida.jogadorAtual);

                    Console.WriteLine();
                    Console.Write("Posição Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Posição Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                }
                catch (TabuleiroException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}