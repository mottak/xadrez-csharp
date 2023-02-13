using tabuleiro;

namespace TabuleiroXadrez
{
  class Tela
  {
    public static void imprimirTabuleiro(Tabuleiro tab)
    {
      for (int i = 0; i < tab.linhas; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < tab.colunas; j++)
        {
          Posicao pos = new Posicao(i, j);
          if (tab.peca(pos) == null)
          {
            System.Console.Write("- ");
          }
          else
          {
            imprimirPeca(tab.peca(pos));
            System.Console.Write(" ");
          }
        }
        System.Console.WriteLine();
      }
      System.Console.WriteLine(" a b c d e f g h");
    }

    public static void imprimirPeca(Peca peca)
    {
      if (peca.cor == Cor.Branca)
      {
        Console.Write(peca);
      }
      else
      {
        ConsoleColor corAux = Console.ForegroundColor;  // cor cinza
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(peca);
        Console.ForegroundColor = corAux;
      }
    }
  }
}