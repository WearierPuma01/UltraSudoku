﻿using System;
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
    public partial class WinForm : Form
    {
        //int tmp = 0;
        Form game;
        public WinForm(Form gameWindow)
        {
            InitializeComponent();
            game = gameWindow;

        }

        private void win_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainmenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            this.Close();
            
            MainMenu mainmenu = new MainMenu();
            game.Hide();
            game.Dispose();
            game.Close();
           
            
            mainmenu.ShowDialog();
            return;
        }
    }
}