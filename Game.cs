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

        int difficulty;
        int[,] matrix;
        int[,] matrixHelp;
        SudokuCell[,] cells = new SudokuCell[9, 9];
        public Game(int outsideDifficulty)
        {
            difficulty = outsideDifficulty;
            InitializeComponent();
            createCells();
            matrix=Generator.generator(difficulty);
            matrixHelp=Solver.sudokuHelper(matrix);
            loadField();


        }

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

                    // Assign key press event for each cells
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }
        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // Do nothing if the cell is locked
            if (cell.IsLocked)
                return;

            int value;

            // Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // Clear the cell value if pressed key is zero
                if (value == 0)
                    cell.Clear();
                else
                {
                    cell.Text = value.ToString();
                }
                cell.Value = value;
                cell.ForeColor = Color.Black;
            }
            checkComplete();
        }

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
        private void exit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                        return;
                    }
            
        }
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
            WinForm winform = new WinForm();
            winform.ShowDialog();

        }
        //private void checkCorrect
    }
}
