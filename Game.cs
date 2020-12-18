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
        public Game()
        {
            InitializeComponent();
        }

        public Game(int outsideDifficulty)
        {
            difficulty = outsideDifficulty;
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
