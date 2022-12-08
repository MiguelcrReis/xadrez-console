
namespace tabuleiro
{
    internal class Posicao
    {
        #region Variáveis
        public int linha { get; set; }
        public int coluna { get; set; }
        #endregion

        #region Construtor Posicao
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return linha + ", " + coluna;
        }
        #endregion
    }
}
