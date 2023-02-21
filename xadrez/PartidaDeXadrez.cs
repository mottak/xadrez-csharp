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
      xeque = false;

      turno++;
      mudaJogador();
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
      if (!tab.peca(origem).podeMoverPara(destino))
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
      colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
      colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
      colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
      colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
      colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
      colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

      colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
      colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
      colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
      colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
      colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
      colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));

    }
  }
}