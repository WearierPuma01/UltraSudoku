using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    /// <summary>
    /// Статический класс, решающий судоку 
    /// </summary>
    static class Solver 
    {
        /// <summary>
        /// Проверка наличия решения и его единственность
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool countOfSolves(int[,] matrix) 
        {
            int count_of_solves = 0;
            cOS(matrix, ref count_of_solves);
            if (count_of_solves == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Решение поля судоку (возвращает решенную матрицу судоку, не изменяет изначальной)
        /// </summary>
        /// <param name="matrix_input"></param>
        /// <returns></returns>
        public static int[,] sudokuHelper (int[,] matrix_input) 
        {
            //int[,] matrix = matrix_input;
            int[,] matrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    matrix[i, j] = matrix_input[i, j];
            sHelper(matrix);
            return matrix;
        }
        /// <summary>
        /// Подсчет количества решений
        /// </summary>
        /// <param name="matrix_input"></param>
        /// <param name="count_of_solves"></param>
        /// <returns></returns>
        private static bool cOS(int[,] matrix_input, ref int count_of_solves) 
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
        /// <summary>
        /// Решатель поля судоку (правильная работа, только при условии что поле верно)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static bool sHelper(int[,] matrix)
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
        /// <summary>
        /// Нахождение пустой клетки
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static bool findEmptyCords (int[,] matrix, out int row, out int col)
        {
            col = 0;
            for (row = 0; row < 9; row++)
                for (col = 0; col < 9; col++)
                    if (matrix[row, col] == 0)
                        return true;
            return false;
        }
        /// <summary>
        /// Проверка числа на возможнось расположения в выбранной ячейке
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool isCorrectNum (int[,] matrix, int row, int col, int num)
        {

            return !placeInRow(matrix, row, num) && !placeInCol(matrix, col, num) && !placeInBox(matrix, row - row % 3, col - col % 3, num) && matrix[row, col] == 0;
        }
        /// <summary>
        /// Проверка на наличие числа в строке
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool placeInRow (int[,] matrix, int row, int num) 
        {
            for (int col = 0; col < 9; col++)
                if (matrix[row, col] == num)
                    return true;
            return false;
        }
        /// <summary>
        /// Проверка на наличие числа в столбце
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="col"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool placeInCol (int[,] matrix, int col, int num)
        {
            for (int row = 0; row < 9; row++)
                if (matrix[row, col] == num)
                    return true;
            return false;
        }
        /// <summary>
        /// Проверка на наличие числа в боксе
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="box_start_row"></param>
        /// <param name="box_start_col"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool placeInBox (int[,] matrix, int box_start_row, int box_start_col, int num)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (matrix[row + box_start_row, col + box_start_col] == num)
                        return true;
            return false;
        }
    }
}
