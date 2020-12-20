using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Game : Form
    {

        //int difficulty;
        int[,] matrix;
        int[,] matrixHelp;
        SudokuCell[,] cells = new SudokuCell[9, 9];
        
        public Game(/*int outsideDifficulty*/int [,] matrixInput)
        {
            matrix = matrixInput;
           // difficulty = outsideDifficulty;
            InitializeComponent();
            createCells();
            //matrix=Generator.generator(difficulty);
            matrixHelp=Solver.sudokuHelper(matrix);
            loadField();


        }
        /// <summary>
        /// Создает поле
        /// </summary>
        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }
        /// <summary>
        /// Позволяет заполнять поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            
            if (cell.IsLocked)
                return;

            int value;

          
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                
                if (value == 0)
                    cell.Clear();
                else
                {
                    cell.Text = value.ToString();
                }
                cell.Value = value;
                //cell.ForeColor = Color.Black;
            }
            checkComplete();
            checkCorrect(cell.X, cell.Y);
            
        }
        /// <summary>
        /// Заполняет поле
        /// </summary>
        private void loadField()
        {
            for (int i=0;i<9;i++)
                for(int j=0; j<9; j++)
                {
                    cells[i, j].Clear();
                    cells[i, j].Value = matrix[i,j];
                    if (cells[i, j].Value!=0)
                        cells[i, j].Text = cells[i, j].Value.ToString();
                    if (matrix[i, j] != 0)
                        cells[i, j].IsLocked = true;
                }
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Кнопка помощи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void help_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (cells[i, j].Value == 0)
                    {
                        cells[i, j].Value = matrixHelp[i, j];
                        cells[i, j].Text = cells[i, j].Value.ToString();
                        cells[i, j].ForeColor = Color.Black;
                        checkComplete();
                        checkCorrect(i, j);
                        
                        return;
                    }
            
        }
        /// <summary>
        /// Проверка решено ли судоку
        /// </summary>
        private void checkComplete()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (matrixHelp[i, j] != cells[i, j].Value)
                        return;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j].IsLocked = true;
                    cells[i, j].ForeColor = Color.Green;
                }
            WinForm winform = new WinForm(Form.ActiveForm);
            winform.ShowDialog();

        }
        /// <summary>
        /// Проверка правильности введённого значения
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void checkCorrect(int i, int j)
        {
            bool checkCurrent = false;
        

                
        
            for (int col = 0; col < 9; col++)
            {
                if (col == j)
                    continue;
                if (cells[i, j].Value == cells[i, col].Value)
                {
                    if (cells[i, j].IsLocked)
                        cells[i, j].ForeColor = Color.DarkRed;
                    else
                        cells[i, j].ForeColor = Color.Red;
                    if (cells[i, col].IsLocked)
                        cells[i, col].ForeColor = Color.DarkRed;
                    else
                        cells[i, col].ForeColor = Color.Red;
                    checkCurrent = true;
                }
                else
                {
                    if (cells[i, col].IsLocked)
                        cells[i, col].ForeColor = SystemColors.ControlDarkDark;
                    else
                        cells[i, col].ForeColor = Color.Black;
                }
            }

            for (int row = 0; row < 9; row++)
            {
                if (row == i)
                    continue;
                if (cells[i, j].Value == cells[row, j].Value)
                {
                    if (cells[i, j].IsLocked)
                        cells[i, j].ForeColor = Color.DarkRed;
                    else
                        cells[i, j].ForeColor = Color.Red;
                    if (cells[row, j].IsLocked)
                        cells[row, j].ForeColor = Color.DarkRed;
                    else
                        cells[row, j].ForeColor = Color.Red;
                    checkCurrent = true;
                }
                else
                {
                    if (cells[row, j].IsLocked)
                        cells[row, j].ForeColor = SystemColors.ControlDarkDark;
                    else
                        cells[row, j].ForeColor = Color.Black;
                }
            }

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                {
                    if (i == row + i - (i % 3) && j == col + j - (j % 3))
                        continue;
                    if (cells[i, j].Value == cells[row + i - (i % 3), col + j - (j % 3)].Value)
                    {
                        if (cells[i, j].IsLocked)
                            cells[i, j].ForeColor = Color.DarkRed;
                        else
                            cells[i, j].ForeColor = Color.Red;
                        if (cells[row + i - (i % 3), col + j - (j % 3)].IsLocked)
                            cells[row + i - (i % 3), col + j - (j % 3)].ForeColor = Color.DarkRed;
                        else
                            cells[row + i - (i % 3), col + j - (j % 3)].ForeColor = Color.Red;
                        checkCurrent = true;
                    }
                    else
                    {
                        if (cells[row + i - (i % 3), col + j - (j % 3)].IsLocked)
                            cells[row + i - (i % 3), col + j - (j % 3)].ForeColor = SystemColors.ControlDarkDark;
                        else
                            cells[row + i - (i % 3), col + j - (j % 3)].ForeColor = Color.Black;
                    }
                }
            if (checkCurrent)
                cells[i, j].ForeColor = Color.Red;
            else
                cells[i, j].ForeColor = Color.Black;
            
        }
        /// <summary>
        /// Кнопка проверки возможности сборки судоку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkerCorret_Click(object sender, EventArgs e)
        {
            for(int i=0; i<9; i++)
                for(int j=0;j<9;j++)
                {
                    if (cells[i, j].Value == 0)
                        continue;
                    if (cells[i, j].Value!=matrixHelp[i,j])
                    {
                        MessageBox.Show("Собрать судоку невозможно!", "Проверка", MessageBoxButtons.OK);
                        return;
                    }
                }
            MessageBox.Show("Собрать судоку возможно!", "Проверка", MessageBoxButtons.OK);
            return;
        }
    }
}
