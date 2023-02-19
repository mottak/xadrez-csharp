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
        PartidaDeXadez partida = new PartidaDeXadez();


        Tela.imprimirTabuleiro(partida.tab);
        System.Console.WriteLine();

      }
      catch (TabuleiroException e)
      {

      }


    }
  }
}
