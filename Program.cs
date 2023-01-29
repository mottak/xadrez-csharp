using System;
using tabuleiro;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Posicao P;
      P = new Posicao(3, 4);
      System.Console.WriteLine($"Posição: {P}");
      System.Console.WriteLine();

    }
  }
}