namespace proiect_lav
{
    partial class Form5
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSubstanta = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbDoza = new System.Windows.Forms.TextBox();
            this.tbCod = new System.Windows.Forms.TextBox();
            this.tbNume = new System.Windows.Forms.TextBox();
            this.tbCategorie = new System.Windows.Forms.TextBox();
            this.userControl11 = new proiect_lav.UserControl1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "cod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "nume:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "categorie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "substanta activa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "doza zilnica:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "pret:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(531, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 67);
            this.button1.TabIndex = 6;
            this.button1.Text = "insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSubstanta
            // 
            this.tbSubstanta.Location = new System.Drawing.Point(209, 182);
            this.tbSubstanta.Name = "tbSubstanta";
            this.tbSubstanta.Size = new System.Drawing.Size(100, 22);
            this.tbSubstanta.TabIndex = 7;
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(209, 299);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(100, 22);
            this.tbPret.TabIndex = 8;
            // 
            // tbDoza
            // 
            this.tbDoza.Location = new System.Drawing.Point(209, 242);
            this.tbDoza.Name = "tbDoza";
            this.tbDoza.Size = new System.Drawing.Size(100, 22);
            this.tbDoza.TabIndex = 9;
            // 
            // tbCod
            // 
            this.tbCod.Location = new System.Drawing.Point(209, 36);
            this.tbCod.Name = "tbCod";
            this.tbCod.Size = new System.Drawing.Size(100, 22);
            this.tbCod.TabIndex = 10;
            // 
            // tbNume
            // 
            this.tbNume.Location = new System.Drawing.Point(209, 84);
            this.tbNume.Name = "tbNume";
            this.tbNume.Size = new System.Drawing.Size(100, 22);
            this.tbNume.TabIndex = 11;
            // 
            // tbCategorie
            // 
            this.tbCategorie.Location = new System.Drawing.Point(209, 129);
            this.tbCategorie.Name = "tbCategorie";
            this.tbCategorie.Size = new System.Drawing.Size(100, 22);
            this.tbCategorie.TabIndex = 12;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(380, 37);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(316, 137);
            this.userControl11.TabIndex = 13;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.tbCategorie);
            this.Controls.Add(this.tbNume);
            this.Controls.Add(this.tbCod);
            this.Controls.Add(this.tbDoza);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbSubstanta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSubstanta;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.TextBox tbDoza;
        private System.Windows.Forms.TextBox tbCod;
        private System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.TextBox tbCategorie;
        private UserControl1 userControl11;
    }
}