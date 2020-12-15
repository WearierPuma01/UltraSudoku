using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Generator
    {
        int[,] matrix = new int[9, 9];


        public Generator()
        {
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
        }

        private Generator transposing(int number)
        {
            if (number == 0) return this;
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
            return this;
        }
        private Generator swapRowsSmall(int number_one, int number_two)
        {
            return null; // проверка
        }
        private Generator swapColumsSmall(int number_one, int number_two)
        {
            return null;
        }
        private Generator swapRowsArea(int number_one, int number_two)
        {
            return null;
        }
        private Generator swapColumsArea(int number_one, int number_two)
        {
            return null;
        }

        
    }
}
