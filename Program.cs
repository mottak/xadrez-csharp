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
        PartidaDeXadrez partida = new PartidaDeXadrez();

        while (!partida.terminada)
        {
          try
          {
            Console.Clear();
            Tela.imprimirPartida(partida);
            Console.WriteLine();

            Console.Write("Origem: ");
            Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

            partida.validarPosicaoOrigem(origem);

            bool[,] posicoesPosiveis = partida.tab.peca(origem).movimentosPosiveis();

            // a partir da peça que está na origem, vão ser impressas as casas onde essa peça pode-se mover
            Console.Clear();
            Tela.imprimirTabuleiro(partida.tab, posicoesPosiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
            partida.validarPosicaoDestino(origem, destino);

            partida.realizaJogada(origem, destino);
          }
          catch (TabuleiroException e)
          {
            System.Console.WriteLine("deu ruim na jogada");
            System.Console.WriteLine(e.Message);
            Console.ReadLine();
          }

        }


        System.Console.WriteLine();

      }
      catch (TabuleiroException e)
      {
        System.Console.WriteLine("deu ruim");
        System.Console.WriteLine(e.Message);
      }


    }
  }
}
