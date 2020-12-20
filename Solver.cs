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
            cOS(matrix, ref count_of_solves);
            if (count_of_solves == 1)
                return true;
            else
                return false;
        }

        public static int[,] sudokuHelper (int[,] matrix_input) //решение поля судоку (возвращает решенную матрицу судоку, не изменяет изначальной) [ok]
        {
            //int[,] matrix = matrix_input;
            int[,] matrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    matrix[i, j] = matrix_input[i, j];
            sHelper(matrix);
            return matrix;
        }
       
        private static bool cOS(int[,] matrix_input, ref int count_of_solves) //подсчет количества решений [ok] 
        {
            
            int[,] matrix = matrix_input;
            int row = 0, col = 0;
            if (count_of_solves > 1)
                return false;
            if (!findEmptyCords(matrix, out row, out col))
            {
                count_of_solves++;
                return true;
            }
            for(int num = 1; num <= 9; num++)
            {
                if(isCorrectNum(matrix, row, col, num))
                {
                    matrix[row, col] = num;
                    cOS(matrix, ref count_of_solves); 
                    matrix[row, col] = 0;
                }
            }
            return false;
        }

        private static bool sHelper(int[,] matrix) //решатель поля судоку (правильная работа, только при условии что поле верно) [!!! ПРОВЕРИТЬ АЛГОРИТМ !!!]
        {
            int row = 0, col = 0;
            if (!findEmptyCords(matrix, out row, out col))
            {
                return true;
            }
            for (int num = 1; num <= 9; num++)
            {
                if (isCorrectNum(matrix, row, col, num))
                {
                    matrix[row, col] = num;
                    if (sHelper(matrix))
                        return true;
                    matrix[row, col] = 0;
                }
            }
            return false;
        }

        private static bool findEmptyCords (int[,] matrix, out int row, out int col) //нахождение пустой клетки [ok]
        {
            col = 0;
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
