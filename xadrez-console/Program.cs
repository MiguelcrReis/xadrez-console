using tabuleiro;
using xadrez;
using xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(3, 1));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(1, 1));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(3, 2));

            Tela.imprimirTabuleiro(tabuleiro);

            Console.ReadLine();
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}