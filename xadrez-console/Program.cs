using tabuleiro;
using xadrez;
using xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        Tabuleiro tabuleiro = new Tabuleiro(8, 8);

        tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 0));
        tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(2, 2));
        tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(4, 4));

        Tela.imprimirTabuleiro(tabuleiro);
        Console.ReadLine();
    }
}