using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Кнопка начла игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Difficulty difficulty = new Difficulty();
            difficulty.ShowDialog();

        }
        /// <summary>
        /// Кнопка статистики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке", "Статистика", MessageBoxButtons.OK);
        }
    }
}
