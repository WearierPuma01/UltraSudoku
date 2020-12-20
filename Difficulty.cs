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
    public partial class Difficulty : Form
    {
        public Difficulty()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Элемент интерфейса по выбору сложности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }
        /// <summary>
        /// Обработчик события клика на кнопку, после выбора сложности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count == 0) return;
            int difficulty = -1;
            switch(checkedListBox1.CheckedIndices[0])
            {
                case 0:
                    difficulty = 1;
                    break;
                case 1:
                    difficulty = 2;
                    break;
                case 2:
                    difficulty = 3;
                    break;
                case 3:
                    difficulty = 4;
                    break;
                case 4:
                    difficulty = 5;
                    break;
            }
            int[,] matrix = Generator.generator(difficulty);
            this.Hide();
            this.Close();

            Game game = new Game(matrix);
            game.ShowDialog();
        }
        /// <summary>
        /// Обработчик события клика на кнопку для после выбора пользовательского поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            UserField uf = new UserField();
            uf.ShowDialog();
        }
        /// <summary>
        /// Обработчик события клика на кнопку выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
