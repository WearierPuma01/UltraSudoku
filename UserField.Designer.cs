
namespace WindowsFormsApp1
{
    partial class UserField
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ifCorrect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 360);
            this.panel1.TabIndex = 0;
            // 
            // ifCorrect
            // 
            this.ifCorrect.Location = new System.Drawing.Point(131, 389);
            this.ifCorrect.Name = "ifCorrect";
            this.ifCorrect.Size = new System.Drawing.Size(120, 50);
            this.ifCorrect.TabIndex = 0;
            this.ifCorrect.Text = "Задать";
            this.ifCorrect.UseVisualStyleBackColor = true;
            this.ifCorrect.Click += new System.EventHandler(this.ifCorrect_Click);
            // 
            // UserField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.ifCorrect);
            this.Controls.Add(this.panel1);
            this.Name = "UserField";
            this.Text = "UserField";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ifCorrect;
    }
}