﻿namespace tabuleiro
{
    class Tabuleiro
    {
        #region Instâncias e variáveis
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;
        #endregion

        #region Construtor Tabuleiro
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        #endregion

        #region Peca
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }
        #endregion

        #region Existe Peca
        public bool existePeca(Posicao posicao)
        {
            validaPosicao(posicao);
            return peca(posicao) != null;
        }
        #endregion

        #region Colocar Peca
        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if (existePeca(posicao))
            {
                throw new TabuleiroException("Posição já oculpada por outra peça!");

            }
            pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }
        #endregion

        #region Retirar Peca
        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
            {
                return null;
            }

            Peca pecaAux = peca(posicao);
            pecaAux.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return pecaAux;
        }
        #endregion

        #region Posicao Valida
        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.linha < 0 || posicao.linha >= linhas || posicao.coluna < 0 || posicao.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Valida Posicao
        public void validaPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
        #endregion
    }
}