using System;

public class sudokuSolver
{
  public static bool solve(char [,]board)
  {
    for (int row = 0; row < 9; row++)
    {
      for (int col = 0; col < 9; col++)
      {
        if (board[row, col] == '.')
        {
          for (int num = 1; num <= 9; num++)
          {
            char c = (char)(num + '0');
            if (isValid(board, row, col, c))
            {
              board[row, col] = c;
                if (solve(board))
                {

                  return true;
                } else
                {
                  board[row, col] = '.';
                }        
            }
          }
          return false;
        }
      }
    }
    return true;
}
  private static bool isValid(char [,]board, int row, int col, char c)
  {
    for (int i = 0; i < 9; i++)
    {
      bool repeatInCol = board[i, col] == c;
      bool repeatInRow = board[row, i] == c;
      bool repeatInSquare = board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c;
      if (repeatInCol || repeatInRow || repeatInSquare)
      {
        return false;
      }
    }
    return true;
  }
}
class MainClass
{
  public static void Main (string[] args)
  {
    char [,] sudoku = new char [9,9] {
        { '.', '.', '.',   '.', '.', '.',  '.', '.', '.' }, 
        { '5', '.', '.',   '.', '.', '3',  '8', '.', '9' },
        { '.', '.', '.',   '.', '.', '.',  '6', '.', '7' },

        { '.', '6', '.',   '.', '.', '9',  '.', '1', '.' },
        { '.', '.', '8',   '.', '6', '1',  '.', '.', '.' },
        { '1', '.', '.',   '8', '4', '.',  '.', '.', '.' },

        { '.', '5', '.',   '.', '.', '.',  '.', '.', '6' },
        { '.', '4', '6',   '2', '.', '.',  '.', '3', '.' },
        { '3', '9', '.',   '.', '.', '.',  '1', '.', '4' }
    };
    sudokuSolver.solve(sudoku);
    for (int row = 0; row < 9; row++)
    {
      for (int col = 0; col < 9; col++)
      {
        Console.Write(sudoku[row,col] + " ");
      }
    Console.WriteLine();
    }
  }
}
