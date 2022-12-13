using System;
using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca peca = tabuleiro.peca(pos);
            return peca != null && peca.cor != cor;
        }

        private bool livre(Posicao posicao)
        {
            return tabuleiro.peca(posicao) == null;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);

            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.linha, pos.coluna] = true;
                }
            }

            return matriz;
        }
    }
}
