using tabuleiro;
using xadrez;

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

          imprimirPeca(tab.peca(pos));
          System.Console.Write(" ");

        }
        System.Console.WriteLine();
      }
      System.Console.WriteLine("  a  b  c  d  e  f  g  h");
    }

    // sobrecarga no método imprimirTabuleiro para imprimir as possiveis casas que a peça pode se mover
    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {
      ConsoleColor fundoOriginal = Console.BackgroundColor;
      ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

      for (int i = 0; i < tab.linhas; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < tab.colunas; j++)
        {
          if (posicoesPossiveis[i, j])
          {
            Console.BackgroundColor = fundoAlterado;
          }
          else
          {
            Console.BackgroundColor = fundoOriginal;
          }

          Posicao pos = new Posicao(i, j);
          imprimirPeca(tab.peca(pos));
          System.Console.Write(" ");
          Console.BackgroundColor = fundoOriginal;
        }
        System.Console.WriteLine();
      }
      System.Console.WriteLine("  a  b  c  d  e  f  g  h");
      Console.BackgroundColor = fundoOriginal;
    }
    public static void imprimirPeca(Peca peca)
    {
      if (peca == null)
      {
        System.Console.Write("- ");
      }
      else
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
        System.Console.Write(" ");
      }
    }
    public static PosicaoXadrez lerPoscaoXadrez()
    {
      string s = Console.ReadLine();
      char coluna = s[0];
      int linha = int.Parse(s[1] + "");
      return new PosicaoXadrez(coluna, linha);
    }
  }
}