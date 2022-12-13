using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);

            return peca == null || peca.cor != this.cor;
        }

        private bool verificaTorreRoque(Posicao pos)
        {
            Peca peca = tabuleiro.peca(pos);

            return peca != null && peca is Torre && peca.cor == cor && peca.qtdMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Suldeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            // JOGADA ESPECIAL 
            if (qtdMovimentos == 0 && !partida.xeque)
            {
                // ROQUE PEQUENO
                Posicao posT1 = new(posicao.linha, posicao.coluna + 3);

                if (verificaTorreRoque(posT1))
                {
                    Posicao pos1 = new(posicao.linha, posicao.coluna + 1);
                    Posicao pos2 = new(posicao.linha, posicao.coluna + 2);

                    if (tabuleiro.peca(pos1) == null && tabuleiro.peca(pos2) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // ROQUE GRANDE
                Posicao posT2 = new(posicao.linha, posicao.coluna - 4);

                if (verificaTorreRoque(posT2))
                {
                    Posicao pos1 = new(posicao.linha, posicao.coluna - 1);
                    Posicao pos2 = new(posicao.linha, posicao.coluna - 2);
                    Posicao pos3 = new(posicao.linha, posicao.coluna - 3);

                    if (tabuleiro.peca(pos1) == null && tabuleiro.peca(pos2) == null && tabuleiro.peca(pos3) == null)
                    {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
