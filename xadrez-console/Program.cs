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

            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(2, 2));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tabuleiro);
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}