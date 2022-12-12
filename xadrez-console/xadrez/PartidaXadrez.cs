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
        public bool xeque { get; private set; }
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
            xeque = false;
        }
        #endregion

        #region Executa Movimento
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();

            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }
        #endregion

        #region Desfaz o Movimento
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = tabuleiro.retirarPeca(destino);
            peca.decrementarQtdMovimentos();

            if (pecaCapturada != null)
            {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(peca, origem);
        }

        #endregion

        #region Realiza Jogada
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            var pecaCapturada = executaMovimento(origem, destino);

            if (verificaXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            if (verificaXeque(adversaria(jogadorAtual)))
            { xeque = true; }
            else { xeque = false; }

            if (verificaXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                alterajogador();
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
            if (!tabuleiro.peca(origem).movimentoPossível(destino))
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
            foreach (Peca x in pecas)
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

        #region Peça Adversária 
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            { return Cor.Preta; }
            else
            { return Cor.Branca; }
        }
        #endregion

        #region Consulta Rei
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        #endregion

        #region Verifica se o Rei está em Xeque
        public bool verificaXeque(Cor cor)
        {
            Peca pecaRei = rei(cor);

            if (pecaRei == null) { throw new TabuleiroException("Não foi possível encontrar a peça Rei de cor " + cor); }

            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = x.movimentosPossiveis();
                if (matriz[pecaRei.posicao.linha, pecaRei.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Verifica Xeque Mate
        public bool verificaXequeMate(Cor cor)
        {
            if (!verificaXeque(cor)) { return false; }

            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] matriz = x.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++)
                {
                    for (int j = 0; j < tabuleiro.colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = verificaXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque) { return false; }
                        }
                    }
                }
            }
            return true;
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
            //colocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            //colocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            //colocarNovaPeca('e', 1, new Dama(tabuleiro, Cor.Branca));
            //colocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            //colocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            //colocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branca));

            //colocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 7, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branca));
            //colocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branca));
            #endregion

            #region Peças Pretas
            //colocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preta));
            //colocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preta));
            //colocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('a', 8, new Rei(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 8, new Dama(tabuleiro, Cor.Preta));
            //colocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preta));
            //colocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preta));
            //colocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preta));

            //colocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preta));
            //colocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preta));
            #endregion
        }
        #endregion
    }
}
