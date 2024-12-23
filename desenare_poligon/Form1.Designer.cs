namespace desenare_poligon
{
    partial class Form1
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
            this.btnInchide = new System.Windows.Forms.Button();
            this.btnTrianguleaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(669, 12);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(119, 53);
            this.btnInchide.TabIndex = 1;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // btnTrianguleaza
            // 
            this.btnTrianguleaza.Location = new System.Drawing.Point(669, 80);
            this.btnTrianguleaza.Name = "btnTrianguleaza";
            this.btnTrianguleaza.Size = new System.Drawing.Size(119, 53);
            this.btnTrianguleaza.TabIndex = 2;
            this.btnTrianguleaza.Text = "Trianguleaza";
            this.btnTrianguleaza.UseVisualStyleBackColor = true;
            this.btnTrianguleaza.Click += new System.EventHandler(this.btnTrianguleaza_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(853, 531);
            this.Controls.Add(this.btnTrianguleaza);
            this.Controls.Add(this.btnInchide);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInchide;
        private System.Windows.Forms.Button btnTrianguleaza;
    }
}

