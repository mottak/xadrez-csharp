using tabuleiro;

namespace xadrez
{
  class Rei : Peca
  {
    private PartidaDeXadrez partida;
    public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
      this.partida = partida;

    }
    private bool podeMover(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p == null || p.cor != this.cor;
    }

    private bool testeTorreParaRoque(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p != null && p is Torre && p.cor == this.cor && p.qtdMovimentos == 0;
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

      // #jogada especial roque
      if (qtdMovimentos == 0 && !partida.xeque)
      {
        // #jogada especial roque pequeno
        Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
        if (testeTorreParaRoque(posT1))
        {
          Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
          Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
          if (tab.peca(p1) == null && tab.peca(p2) == null)
          {
            matriz[posicao.Linha, posicao.Coluna + 2] = true;
          }
        }
        // #jogada especial roque grande
        Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
        if (testeTorreParaRoque(posT2))
        {
          Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
          Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
          Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);
          if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
          {
            matriz[posicao.Linha, posicao.Coluna - 2] = true;
          }
        }
      }

      return matriz;
    }

    public override string ToString()
    {
      return "R";
    }
  }
}