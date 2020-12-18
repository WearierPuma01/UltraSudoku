using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class Generator
    {
        //Генерация базового поля
        public static int[,] generator()
        {
            int[,] matrix = new int[9, 9];
            int i = 0;
            List<int> listNumeral = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            while (i != 8)
            {
                i %= 8;
                for (int j = 0; j < 9; j++)
                {
                    matrix[i,j] = listNumeral[j];
                }
                listNumeral.Add(listNumeral[0]);
                listNumeral.RemoveAt(0);
                i += 3;
            }
            for (int j = 0; j < 9; j++)
            {
                matrix[i, j] = listNumeral[j];
            }
            return matrix;
        }

        //Алгоритмы шафла базовой матрицы
        private static void transposing(int[,] matrix, int number) //транспонирование матрицы
        {
            if (number == 0) return ;
            int temp;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
            
        }

        private static void swapRowsSmall(int[,] matrix, int number_one, int number_two) //перестановка строк
        {
            int temp;
            for (int i = 0; i < 9; i++)
            {
                temp = matrix[number_one, i];
                matrix[number_one, i] = matrix[number_two, i];
                matrix[number_two, i] = temp;
            }
            
        }

        private static void swapColumsSmall(int[,] matrix, int number_one, int number_two) //перестановка столбцов
        {
            int temp;
            for (int i = 0; i < 9; i++)
            {
                temp = matrix[i, number_one];
                matrix[i, number_one] = matrix[i, number_two];
                matrix[i, number_two] = temp;
            }
        }

        private static void swapRowsArea(int[,] matrix, int number_one, int number_two) //перестановкак зон(строк)
        {
            int temp1, temp2, temp3;
            for (int i = 0; i < 9; i++)
            {
                temp1 = matrix[number_one * 3, i];
                temp2 = matrix[number_one * 3 + 1, i];
                temp3 = matrix[number_one * 3 + 2, i];
                matrix[number_one * 3, i] = matrix[number_two*3, i];
                matrix[number_one * 3 + 1, i] = matrix[number_two * 3 + 1, i];
                matrix[number_one * 3 + 2, i] = matrix[number_two * 3 + 2, i];
                matrix[number_two * 3, i] = temp1;
                matrix[number_two * 3 + 1, i] = temp2;
                matrix[number_two * 3 + 2, i] = temp3;
            }
        }

        private static void swapColumsArea(int[,] matrix, int number_one, int number_two) //перестановка зон(строк)
        {
            int temp1, temp2, temp3;
            for (int i = 0; i < 9; i++)
            {
                temp1 = matrix[i, number_one * 3];
                temp2 = matrix[i, number_one * 3 + 1];
                temp3 = matrix[i, number_one * 3 + 2];
                matrix[i, number_one * 3] = matrix[i, number_two * 3];
                matrix[i, number_one * 3 + 1] = matrix[i, number_two * 3 + 1];
                matrix[i, number_one * 3 + 2] = matrix[i, number_two * 3 + 2];
                matrix[i, number_two * 3] = temp1;
                matrix[i, number_two * 3 + 1] = temp2;
                matrix[i, number_two * 3 + 2] = temp3;
            }
        }
        
        private static void deleteCell(int[,] matrix, int difficulty)
        {
            Random delRan = new Random();
            int deli;
            int delj;
            int temp;
            for (int count = 0; count < difficulty; count++)
            {
                while (true)
                {
                    deli = delRan.Next(0, 9);
                    delj = delRan.Next(0, 9);
                    if (matrix[deli, delj] == 0)
                        continue;
                    temp = matrix[deli, delj];
                    matrix[deli, delj] = 0;

                }
 


            }
        }

        
    }
}
