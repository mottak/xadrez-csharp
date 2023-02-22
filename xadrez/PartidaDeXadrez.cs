using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
  class PartidaDeXadrez
  {
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool terminada { get; private set; }
    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;
    public bool xeque { get; private set; }

    public PartidaDeXadrez()
    {
      tab = new Tabuleiro(8, 8);
      turno = 1;
      jogadorAtual = Cor.Branca;
      terminada = false;
      pecas = new HashSet<Peca>();
      capturadas = new HashSet<Peca>();
      xeque = false;
      colocarPecas();
    }

    public void colocarNovaPeca(char coluna, int linha, Peca peca)
    {
      tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
      pecas.Add(peca);
    }

    public Peca executarMovimento(Posicao origem, Posicao destino)
    {
      Peca p = tab.retiraPeca(origem);
      p.incrementarQtdMovimentos();
      Peca pCapturada = tab.retiraPeca(destino);
      tab.colocarPeca(p, destino);
      if (pCapturada != null)
      {
        capturadas.Add(pCapturada);
      }

      // #jogada especial  roque pequeno
      if (p is Rei && destino.Coluna == origem.Coluna + 2)
      {
        Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
        Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
        Peca T = tab.retiraPeca(origemTorre);
        T.incrementarQtdMovimentos();
        tab.colocarPeca(T, destinoTorre);
      }
      // #jogada especial  roque grande
      if (p is Rei && destino.Coluna == origem.Coluna + 2)
      {
        Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
        Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
        Peca T = tab.retiraPeca(origemTorre);
        T.incrementarQtdMovimentos();
        tab.colocarPeca(T, destinoTorre);
      }

      return pCapturada;
    }

    public void desfazMovimento(Posicao origem, Posicao destino, Peca pCapturada)
    {
      Peca p = tab.retiraPeca(destino);
      p.decrementarQtdMovimentos();

      if (pCapturada != null)
      {
        tab.colocarPeca(pCapturada, destino);
        capturadas.Remove(pCapturada);
      }
      tab.colocarPeca(p, origem);

      // #jogada especial  roque pequeno
      if (p is Rei && destino.Coluna == origem.Coluna + 2)
      {
        Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
        Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
        Peca T = tab.retiraPeca(origemTorre);
        T.decrementarQtdMovimentos();
        tab.colocarPeca(T, origemTorre);
      }
      // #jogada especial  roque grande
      if (p is Rei && destino.Coluna == origem.Coluna + 2)
      {
        Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
        Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
        Peca T = tab.retiraPeca(origemTorre);
        T.decrementarQtdMovimentos();
        tab.colocarPeca(T, origemTorre);
      }
    }

    public HashSet<Peca> pecasCapturadas(Cor cor)
    {
      HashSet<Peca> aux = new HashSet<Peca>();
      foreach (Peca x in capturadas)
      {
        if (x.cor == cor)
        {
          aux.Add(x);

        }
      }
      return aux;
    }

    public HashSet<Peca> pecasEmJogo(Cor cor)
    {
      HashSet<Peca> aux = new HashSet<Peca>();
      foreach (Peca x in pecas)
      {
        if (x.cor == cor)
        {
          aux.Add(x);

        }
      }
      aux.ExceptWith(pecasCapturadas(cor));
      return aux;
    }
    private Cor adversaria(Cor cor)
    {
      if (cor == Cor.Branca)
      {
        return Cor.Branca;
      }
      else
      {
        return Cor.Preta;
      }
    }

    private Peca rei(Cor cor)
    {
      foreach (Peca x in pecasEmJogo(cor))
      {
        if (x is Rei)
        {
          return x;
        }
      }
      return null;
    }

    private bool estaEmXeque(Cor cor)
    {
      Peca Rei = rei(cor);
      if (Rei == null)
      {
        throw new TabuleiroException("Não existe um rei da cor" + cor + "no tabuleiro!");
      }
      foreach (Peca x in pecasEmJogo(adversaria(cor)))
      {
        bool[,] matriz = x.movimentosPosiveis();
        if (matriz[Rei.posicao.Linha, Rei.posicao.Coluna])
        {
          return true;
        }
      }
      return false;
    }

    public bool testeXequemate(Cor cor)
    {
      if (!estaEmXeque(cor)) return false;
      foreach (Peca x in pecasEmJogo(cor))
      {
        bool[,] matriz = x.movimentosPosiveis();
        for (int i = 0; i < tab.linhas; i++)
        {
          for (int j = 0; j < tab.colunas; j++)
          {
            if (matriz[i, j])
            {
              Posicao origem = x.posicao;
              Posicao destino = new Posicao(i, j);
              Peca pecaCapturada = executarMovimento(origem, destino);
              bool testeXeque = estaEmXeque(cor);
              desfazMovimento(origem, destino, pecaCapturada);
              if (!testeXeque)
              {
                return false;
              }
            }
          }
        }
      }
      return true;
    }
    public void realizaJogada(Posicao origem, Posicao destino)
    {
      Peca pecaCapturada = executarMovimento(origem, destino);
      if (estaEmXeque(jogadorAtual))
      {
        desfazMovimento(origem, destino, pecaCapturada);
        throw new Exception("Você nã pode se colocar em xeque");
      }
      if (estaEmXeque(adversaria(jogadorAtual)))
      {
        xeque = true;
      }
      else
      {
        xeque = false;
      }
      if (testeXequemate(adversaria(jogadorAtual)))
      {
        terminada = true;
      }
      else
      {
        turno++;
        mudaJogador();
      }
    }

    public void validarPosicaoOrigem(Posicao pos)
    {
      if (tab.peca(pos) == null)
      {
        throw new TabuleiroException("Não existe peça na posição de origem escolhida");
      }
      if (jogadorAtual != tab.peca(pos).cor)
      {
        throw new TabuleiroException("A peça de origem escolhida não é sua!");
      }
      if (!tab.peca(pos).existeMovimentosPossiveis())
      {
        throw new TabuleiroException("Não existe movimentos possiveis para a peça escolhida");
      }
    }

    public void validarPosicaoDestino(Posicao origem, Posicao destino)
    {
      if (!tab.peca(origem).movimentoPossivel(destino))
      {
        throw new TabuleiroException("Posição invalida");
      }

    }

    private void mudaJogador()
    {
      if (jogadorAtual == Cor.Branca)
      {
        jogadorAtual = Cor.Preta;
      }
      else
      {
        jogadorAtual = Cor.Branca;
      }
    }
    private void colocarPecas()
    {
      colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
      colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
      colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
      colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
      colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
      colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
      colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
      colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
      colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca));
      colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca));

      colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
      colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
      colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
      colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
      colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
      colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
      colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
      colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
      colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta));
      colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta));
    }
  }
}