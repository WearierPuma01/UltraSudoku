using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    
    static class Solver //решатель
    {
        

        public static bool countOfSolves(int[,] matrix) //проверка наличия решения и его единственность [ok]
        {
            int count_of_solves = 0;
            cOS(matrix, count_of_solves);
            if (count_of_solves == 1)
                return true;
            else
                return false;
        }

        private static bool cOS(int[,] matrix_input, int count_of_solves) //подсчет количества решений [!!! ПРОВЕРИТЬ АЛГОРИТМ !!!] 
        {
            int[,] matrix = matrix_input;
            int row = 0, col = 0;
            if (!findEmptyCords(matrix, row, col))
            {
                count_of_solves++;
                return true;
            }
            for(int num = 1; num <= 9; num++)
            {
                if(isCorrectNum(matrix, row, col, num))
                {
                    matrix[row, col] = num;
                    cOS(matrix, count_of_solves); 
                    matrix[row, col] = 0;
                }
            }
            return false;
        }

        private static bool findEmptyCords (int[,] matrix, int row, int col) //нахождение пустой клетки [ok]
        {
            for (row = 0; row < 9; row++)
                for (col = 0; col < 9; col++)
                    if (matrix[row, col] == 0)
                        return true;
            return false;
        }

        private static bool isCorrectNum (int[,] matrix, int row, int col, int num) //проверка числа на возможнось расположения в выбранной ячейке [ok]
        {

            return !placeInRow(matrix, row, num) && !placeInCol(matrix, col, num) && !placeInBox(matrix, row - row % 3, col - col % 3, num) && matrix[row, col] == 0;
        }
        private static bool placeInRow (int[,] matrix, int row, int num) //проверка на наличие числа в строке [ok]
        {
            for (int col = 0; col < 9; col++)
                if (matrix[row, col] == num)
                    return true;
            return false;
        }

        private static bool placeInCol (int[,] matrix, int col, int num) //проверка на наличие числа в столбце [ok]
        {
            for (int row = 0; row < 9; row++)
                if (matrix[row, col] == num)
                    return true;
            return false;
        }

        private static bool placeInBox (int[,] matrix, int box_start_row, int box_start_col, int num) //проверка на наличие числа в боксе [ok]
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (matrix[row + box_start_row, col + box_start_col] == num)
                        return true;
            return false;
        }
    }
}
