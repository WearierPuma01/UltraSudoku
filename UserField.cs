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
    public partial class UserField : Form
    {
        SudokuCell[,] cells = new SudokuCell[9, 9];
        int[,] matrix = new int[9, 9];
        public UserField()
        {
            InitializeComponent();
            createCells();
          
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
                matrix[cell.X, cell.Y] = value;
                cell.ForeColor = Color.Black;
            }
           

        }
        /// <summary>
        /// Проверка наличия единственного решения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ifCorrect_Click(object sender, EventArgs e)
        {
            if(Solver.countOfSolves(matrix))
            {
                this.Hide();
                this.Close();
                Game game = new Game(matrix);
                game.ShowDialog();
            }
            else
                MessageBox.Show("Из данной расстановки собрать судоку невозможно!", "Ошибка задания поля", MessageBoxButtons.OK);
        }
    }
}
