using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        #region Instâncias e variáveis
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }
        #endregion

        #region Construtor Partida Xadrez
        public PartidaXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }
        #endregion

        #region Executa Jogada
        public void executaJogada(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }
        #endregion

        #region Colocar Pecas
        public void colocarPecas()
        {
            #region Peças Brancas
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Branca), new PosicaoXadrez('b', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
            tabuleiro.colocarPeca(new Dama(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());

            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('a', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('b', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('f', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('g', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Branca), new PosicaoXadrez('h', 2).toPosicao());
            #endregion

            #region Peças Pretas
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Preta), new PosicaoXadrez('b', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
            tabuleiro.colocarPeca(new Dama(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.Preta), new PosicaoXadrez('f', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.Preta), new PosicaoXadrez('g', 8).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());

            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('a', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('b', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('f', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('g', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.Preta), new PosicaoXadrez('h', 7).toPosicao());
            #endregion
        }
        #endregion
    }
}
