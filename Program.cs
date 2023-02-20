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

          bool[,] posicoesPosiveis = partida.tab.peca(origem).movimentosPosiveis();

          // a partir da peça que está na origem, vão ser impressas as casas onde essa peça pode-se mover
          Console.Clear();
          Tela.imprimirTabuleiro(partida.tab, posicoesPosiveis);


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
