using System;
using tabuleiro;
using xadrez;

namespace TabuleiroXadrez
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Tabuleiro tab;
        tab = new Tabuleiro(8, 8);

        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(2, 5));
        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 0));
        tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 5));
        tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(1, 5));

        Tela.imprimirTabuleiro(tab);
        System.Console.WriteLine();

      }
      catch (TabuleiroException e)
      {

      }

      PosicaoXadrez posicao = new PosicaoXadrez('c', 7);

      Console.WriteLine(posicao.ToPosicao());



    }
  }
}