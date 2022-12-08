using System;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        #region Instâncias e variáveis
        public char coluna { get; set; }
        public int linha { get; set; }
        #endregion

        #region Construtor Xadrez
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        #endregion

        #region To Posicao
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "" + coluna + linha;
        }
        #endregion
    }
}
