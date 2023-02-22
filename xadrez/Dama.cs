using tabuleiro;

namespace xadrez
{
  class Dama : Peca
  {
    public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
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

      // posição esqueda
      pos.definirValores(posicao.Linha, posicao.Coluna - 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha, pos.Coluna - 1);
      }
      // posição a direita
      pos.definirValores(posicao.Linha, posicao.Coluna + 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha, pos.Coluna + 1);
      }
      // posição acima
      pos.definirValores(posicao.Linha - 1, posicao.Coluna);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha - 1, pos.Coluna);
      }

      // posição abaixo
      pos.definirValores(posicao.Linha + 1, posicao.Coluna);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha + 1, pos.Coluna);
      }


      // posição noroeste
      pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha - 1, pos.Coluna - 1);
      }

      // posição nordeste
      pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha - 1, pos.Coluna + 1);
      }

      // posição sudeste
      pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha + 1, pos.Coluna + 1);
      }

      // posição sudoeste
      pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.definirValores(pos.Linha + 1, pos.Coluna - 1);
      }


      return matriz;
    }

    public override string ToString()
    {
      return "D";
    }
  }
}