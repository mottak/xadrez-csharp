using tabuleiro;

namespace xadrez
{
  class Torre : Peca
  {
    public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
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
      pos.definirValores(posicao.Linha - 1, posicao.Coluna);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.Linha = pos.Linha - 1;
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
        pos.Linha = pos.Coluna + 1;
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
        pos.Linha = pos.Linha + 1;
      }


      // posição esqueda
      pos.definirValores(posicao.Linha, posicao.Coluna - 1);
      while (tab.posicaoValida(pos) && podeMover(pos))
      {
        matriz[pos.Linha, pos.Coluna] = true;
        if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
        {
          break;
        }
        pos.Linha = pos.Coluna - 1;
      }

      return matriz;
    }

    public override string ToString()
    {
      return "T";
    }
  }
}