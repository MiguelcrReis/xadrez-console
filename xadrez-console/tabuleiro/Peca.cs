using System;

namespace tabuleiro
{
    class Peca
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
    }
}
