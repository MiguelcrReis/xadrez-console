using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);

            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicao = new Posicao(0, 0);

            //Acima
            posicao.definirValores(posicao.linha - 1, posicao.coluna);

            while (tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (tabuleiro.peca(posicao) != null && tabuleiro.peca(posicao).cor != cor)
                {
                    break;
                }
                posicao.linha = posicao.linha - 1;
            }

            //Abaixo
            posicao.definirValores(posicao.linha + 1, posicao.coluna);

            while (tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (tabuleiro.peca(posicao) != null && tabuleiro.peca(posicao).cor != cor)
                {
                    break;
                }
                posicao.linha = posicao.linha + 1;
            }

            //Direita
            posicao.definirValores(posicao.linha, posicao.coluna + 1);

            while (tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (tabuleiro.peca(posicao) != null && tabuleiro.peca(posicao).cor != cor)
                {
                    break;
                }
                posicao.coluna = posicao.coluna + 1;
            }

            //Esquerda
            posicao.definirValores(posicao.linha, posicao.coluna - 1);

            while (tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (tabuleiro.peca(posicao) != null && tabuleiro.peca(posicao).cor != cor)
                {
                    break;
                }
                posicao.coluna = posicao.coluna - 1;
            }

            return matriz;
        }
    }
}
