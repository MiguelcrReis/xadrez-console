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
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tabuleiro);

                Console.WriteLine();
                Console.Write("Posição Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                Console.Write("Posição Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                partida.executaJogada(origem, destino);
            }
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}