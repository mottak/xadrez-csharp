using tabuleiro;

namespace xadrez
{
  class Rei : Peca
  {
    public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
    {

    }
    private bool podeMover(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p == null || p.cor != this.cor;
    }


    // faz-se a marcação de todos os possiveis movimentos que o Rei pode mover
    public override bool[,] movimentosPosiveis()
    {
      bool[,] matriz = new bool[tab.linhas, tab.colunas];
      Posicao pos = new Posicao(0, 0);

      // posição acima
      pos.definirValores(posicao.Linha - 1, posicao.Coluna);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição nordeste
      pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição a direita
      pos.definirValores(posicao.Linha, posicao.Coluna + 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição sudeste
      pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição abaixo
      pos.definirValores(posicao.Linha + 1, posicao.Coluna);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      // posição sudoeste
      pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição esqueda
      pos.definirValores(posicao.Linha, posicao.Coluna - 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }
      // posição noroeste
      pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
      if (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
      }

      return matriz;
    }

    public override string ToString()
    {
      return "R";
    }
  }
}