using System;

namespace tabuleiro
{
    abstract class Peca
    {
        #region Instâncias e variáveis
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }
        #endregion

        #region Construtor Peca
        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.qtdMovimentos = 0;
            this.cor = cor;
        }
        #endregion

        #region Incrementar quantidade de movimentos
        public void incrementarQtdMovimentos()
        {
            qtdMovimentos++;
        }
        #endregion

        #region Existe movimentos possiveis
        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Pode Mover Para
        public bool podeMoverPara(Posicao posicao)
        {
            return movimentosPossiveis()[posicao.linha, posicao.coluna];
        }
        #endregion

        public abstract bool[,] movimentosPossiveis();
    }
}
