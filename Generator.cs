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
        public static int[,] generator(int difficultyGrade) //генерация базового поля [ok]
        {
           int[,] matrix = new int[9, 9];
            int i = 0;
            List<int> listNumeral = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            while (i != 8)
            {
                i %= 8;
                for (int j = 0; j < 9; j++)
                {
                    matrix[j,i] = listNumeral[j];
                }
                listNumeral.Add(listNumeral[0]);
                listNumeral.RemoveAt(0);
                i += 3;
            }
            for (int j = 0; j < 9; j++)
            {
                matrix[j, i] = listNumeral[j];
            }
            genField(matrix, difficultyGrade);
            return matrix;
        }
        private static void genField(int[,] matrix, int difficultyGrade)
        {
            //matrixShafle(matrix);
            deleteCell(matrix, difficultyGrade);

        }
        private static void matrixShafle(int[,] matrix) //Шафл всей матрицы
        {
            DateTime start = new DateTime();
            
            for (int i = 0; i <= start.Second; i++)
            {
                transposing(matrix, (start.Day % 2));
                swapRowsSmall(matrix, (start.Hour % 3), (start.Minute % 3));
                transposing(matrix, (start.Hour % 2));
                swapColumsSmall(matrix, (start.Year % 3), (start.Minute % 3));
                transposing(matrix, (start.Second % 2));
                swapRowsArea(matrix, (start.Minute % 3), (start.Second % 3));
                transposing(matrix, (start.Minute % 2));
                swapColumsArea(matrix, (start.Year % 3), (start.Second % 3));
            } 
        }
        //Алгоритмы шафла базовой матрицы [ok]
        private static void transposing(int[,] matrix, int number) //транспонирование матрицы [ok]
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

        private static void swapRowsSmall(int[,] matrix, int number_one, int number_two) //перестановка строк [ok]
        {
            int temp;
            for (int i = 0; i < 9; i++)
            {
                temp = matrix[number_one, i];
                matrix[number_one, i] = matrix[number_two, i];
                matrix[number_two, i] = temp;
            }
            
        }

        private static void swapColumsSmall(int[,] matrix, int number_one, int number_two) //перестановка столбцов [ok]
        {
            int temp;
            for (int i = 0; i < 9; i++)
            {
                temp = matrix[i, number_one];
                matrix[i, number_one] = matrix[i, number_two];
                matrix[i, number_two] = temp;
            }
        }

        private static void swapRowsArea(int[,] matrix, int number_one, int number_two) //перестановкак зон(строк) [ok]
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

        private static void swapColumsArea(int[,] matrix, int number_one, int number_two) //перестановка зон(строк) [ok]
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
        
        private static void deleteCell(int[,] matrix, int difficultyGrade) //удаление элементов в зависимости от выбранной сложности [!!! ok НО МОЖНО И ПРОВЕРИТЬ !!!]
        {
            int temp, cordsToDel, difficulty=0;
            List<int> listCords = new List<int> { };
            switch(difficultyGrade)
            {
                case 1:
                    difficulty = 41;
                    break;
                case 2:
                    difficulty = 46;
                    break;
                case 3:
                    difficulty = 53;
                    break;
                case 4:
                    difficulty = 39;
                    break;
                case 5:
                    difficulty = 61;
                    break;
            }
            for (int i=11;i<100;i++)
            {
                if (i % 10 == 0)
                    continue;
                listCords.Add(i);
            }
            Random delRan = new Random();
            for (int count = 0; count < difficulty; count++)
            {
                while (true)
                {
                    cordsToDel = listCords[delRan.Next(0, listCords.Count())];
                    temp = matrix[cordsToDel / 10-1, cordsToDel % 10-1];
                    matrix[cordsToDel / 10-1, cordsToDel % 10-1] = 0;
                    listCords.Remove(cordsToDel);
                    if (Solver.countOfSolves(matrix))
                        break;
                    matrix[cordsToDel / 10-1, cordsToDel % 10-1] = temp;
                }
            }
        }
        
    }
}
