using tabuleiro;

namespace xadrez
{
  class Cavalo : Peca
  {
    public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
    {

    }

    private bool podeMover(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p == null || p.cor != this.cor;
    }

    public override bool[,] movimentosPosiveis()
    {
      bool[,] matriz = new bool[tab.linhas, tab.colunas];
      Posicao pos = new Posicao(0, 0);

      // posição acima
      pos.definirValores(posicao.Linha - 1, posicao.Coluna - 2);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição nordeste
      pos.definirValores(posicao.Linha - 2, posicao.Coluna - 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição a direita
      pos.definirValores(posicao.Linha - 2, posicao.Coluna + 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição sudeste
      pos.definirValores(posicao.Linha - 1, posicao.Coluna + 2);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição abaixo
      pos.definirValores(posicao.Linha + 1, posicao.Coluna + 2);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição sudoeste
      pos.definirValores(posicao.Linha + 2, posicao.Coluna + 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição esqueda
      pos.definirValores(posicao.Linha + 2, posicao.Coluna - 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição noroeste
      pos.definirValores(posicao.Linha + 1, posicao.Coluna - 2);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      return matriz;
    }

    public override string ToString()
    {
      return "C";
    }
  }
}