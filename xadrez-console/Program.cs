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

            Tela.imprimirTabuleiro(partida.tabuleiro);

            Console.ReadLine();
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}