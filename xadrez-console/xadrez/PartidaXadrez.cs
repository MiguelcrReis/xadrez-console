using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        #region Instâncias e variáveis
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        #endregion

        #region Construtor Partida Xadrez
        public PartidaXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        #endregion

        #region RealizaJogada
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            alterajogador();
        }
        #endregion

        #region Executa Movimento
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }
        #endregion

        #region Valida Posição de Origem
        public void validarPosicaoOrigem(Posicao posicao)
        {
            if (tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tabuleiro.peca(posicao).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tabuleiro.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        #endregion

        #region Valida Posição de Destino
        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino Inválida");
            }
        }
        #endregion

        #region Altera Jogador
        private void alterajogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        #endregion

        #region Peças Capturadas
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasAux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    pecasAux.Add(x);
                }
            }
            return pecasAux;
        }
        #endregion

        #region Peças em Jogo
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecasAux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    pecasAux.Add(x);
                }
            }
            pecasAux.ExceptWith(pecasCapturadas(cor));
            return pecasAux;
        }
        #endregion

        #region Colocar Nova Peça
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        #endregion

        #region Colocar Pecas
        public void colocarPecas()
        {
            #region Peças Brancas
            colocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Dama(tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branca));

            colocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branca));
            #endregion

            #region Peças Pretas
            colocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Dama(tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preta));

            colocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preta));
            #endregion
        }
        #endregion
    }
}
