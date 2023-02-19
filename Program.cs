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

        while (!partida.terminada)
        {
          Console.Clear();
          Tela.imprimirTabuleiro(partida.tab);

          Console.WriteLine("Origem:");
          Posicao origem = Tela.lerPoscaoXadrez().ToPosicao();

          Console.WriteLine("Destino:");
          Posicao destino = Tela.lerPoscaoXadrez().ToPosicao();

          partida.executarMovimento(origem, destino);

        }


        System.Console.WriteLine();

      }
      catch (TabuleiroException e)
      {
        System.Console.WriteLine("deu ruim");
      }


    }
  }
}
