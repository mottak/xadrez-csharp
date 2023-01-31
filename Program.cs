using System;
using tabuleiro;

namespace TabuleiroXadrez
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Tabuleiro tab;
      tab = new Tabuleiro(8, 8);
      Tela.imprimirTabuleiro(tab);
      System.Console.WriteLine();

    }
  }
}