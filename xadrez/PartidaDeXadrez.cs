using tabuleiro;

namespace xadrez
{
  class PartidaDeXadez
  {
    public Tabuleiro tab { get; private set; }
    private int turno;
    private Cor jogadorAtual;

    public PartidaDeXadez()
    {
      tab = new Tabuleiro(8, 8);
      turno = 1;
      jogadorAtual = Cor.Branca;
      colocarPecas();
    }

    public void executarMovimento(Posicao origem, Posicao destino)
    {
      Peca p = tab.retiraPeca(origem);
      p.incrementarQtdMovimentos();
      Peca pCapturada = tab.retiraPeca(destino);
      tab.colocarPeca(p, destino);

    }
    private void colocarPecas()
    {
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
      tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
      tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
      tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());

    }
  }
}