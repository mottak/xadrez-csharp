using tabuleiro;

namespace xadrez
{
  class Peao : Peca
  {
    private PartidaDeXadrez partida;
    public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
      this.partida = partida;
    }

    private bool podeMover(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p == null || p.cor != this.cor;
    }

    private bool existeInimigo(Posicao pos)
    {
      Peca p = tab.peca(pos);
      return p != null && p.cor != this.cor;
    }

    private bool livre(Posicao pos)
    {
      return tab.peca(pos) == null;
    }

    public override bool[,] movimentosPosiveis()
    {
      bool[,] matriz = new bool[tab.linhas, tab.colunas];
      Posicao pos = new Posicao(0, 0);

      if (cor == Cor.Branca)
      {
        pos.definirValores(posicao.Linha - 1, posicao.Coluna);
        if (tab.posicaoValida(pos) && livre(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha - 2, posicao.Coluna);
        // Posicao p2 = new Posicao(posicao.Linha - 1, posicao.Coluna);
        // if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
        // {
        //   matriz[pos.Linha, pos.Coluna] = true;
        // }
        if (tab.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
        if (tab.posicaoValida(pos) && existeInimigo(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
        if (tab.posicaoValida(pos) && existeInimigo(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }

        // # jogadaespecial en passant
        if (posicao.Linha == 3)
        {
          Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
          if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.pecaVulneravelEnPassant)
          {
            matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
          }
          Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);
          if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.pecaVulneravelEnPassant)
          {
            matriz[direita.Linha - 1, direita.Coluna] = true;
          }
        }
      }
      else
      {
        pos.definirValores(posicao.Linha + 1, posicao.Coluna);
        if (tab.posicaoValida(pos) && livre(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha + 2, posicao.Coluna);
        Posicao p2 = new Posicao(posicao.Linha + 1, posicao.Coluna);
        if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qtdMovimentos == 0)
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
        if (tab.posicaoValida(pos) && existeInimigo(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }
        pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
        if (tab.posicaoValida(pos) && existeInimigo(pos))
        {
          matriz[pos.Linha, pos.Coluna] = true;
        }

        // #jogada especial en passant
        if (posicao.Linha == 4)
        {
          Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
          if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.pecaVulneravelEnPassant)
          {
            matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
          }
          Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);
          if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.pecaVulneravelEnPassant)
          {
            matriz[direita.Linha + 1, direita.Coluna] = true;
          }
        }
      }


      return matriz;
    }

    public override string ToString()
    {
      return "P";
    }
  }
}