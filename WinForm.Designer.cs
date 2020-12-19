
namespace WindowsFormsApp1
{
    partial class WinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.win = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.mainmenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // win
            // 
            this.win.AutoSize = true;
            this.win.BackColor = System.Drawing.Color.White;
            this.win.Font = new System.Drawing.Font("Segoe Print", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.win.Location = new System.Drawing.Point(51, 9);
            this.win.Name = "win";
            this.win.Size = new System.Drawing.Size(295, 35);
            this.win.TabIndex = 0;
            this.win.Text = "Вы выиграли этот раунд,";
            this.win.Click += new System.EventHandler(this.win_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(111, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "но не войну!";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(218, 129);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(130, 50);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // mainmenu
            // 
            this.mainmenu.Location = new System.Drawing.Point(57, 129);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(130, 50);
            this.mainmenu.TabIndex = 3;
            this.mainmenu.Text = "MAIN MENU";
            this.mainmenu.UseVisualStyleBackColor = true;
            this.mainmenu.Click += new System.EventHandler(this.mainmenu_Click);
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.WIN;
            this.ClientSize = new System.Drawing.Size(604, 268);
            this.Controls.Add(this.mainmenu);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.win);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinForm";
            this.Text = "Победа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label win;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button mainmenu;
    }
}