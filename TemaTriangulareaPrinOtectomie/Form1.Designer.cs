namespace TemaTriangulareaPrinOtectomie
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnArie = new System.Windows.Forms.Button();
            this.labelArie = new System.Windows.Forms.Label();
            this.buttonThreeColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(616, 27);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(138, 65);
            this.btnInchide.TabIndex = 0;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // btnTrianguleaza
            // 
            this.btnTrianguleaza.Location = new System.Drawing.Point(616, 130);
            this.btnTrianguleaza.Name = "btnTrianguleaza";
            this.btnTrianguleaza.Size = new System.Drawing.Size(138, 65);
            this.btnTrianguleaza.TabIndex = 1;
            this.btnTrianguleaza.Text = "Trianguleaza";
            this.btnTrianguleaza.UseVisualStyleBackColor = true;
            this.btnTrianguleaza.Click += new System.EventHandler(this.btnTrianguleaza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnArie
            // 
            this.btnArie.Location = new System.Drawing.Point(616, 345);
            this.btnArie.Name = "btnArie";
            this.btnArie.Size = new System.Drawing.Size(138, 65);
            this.btnArie.TabIndex = 3;
            this.btnArie.Text = "Aria";
            this.btnArie.UseVisualStyleBackColor = true;
            this.btnArie.Click += new System.EventHandler(this.btnArie_Click);
            // 
            // labelArie
            // 
            this.labelArie.AutoSize = true;
            this.labelArie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArie.Location = new System.Drawing.Point(543, 27);
            this.labelArie.Name = "labelArie";
            this.labelArie.Size = new System.Drawing.Size(2, 18);
            this.labelArie.TabIndex = 4;
            // 
            // buttonThreeColor
            // 
            this.buttonThreeColor.Location = new System.Drawing.Point(616, 239);
            this.buttonThreeColor.Name = "buttonThreeColor";
            this.buttonThreeColor.Size = new System.Drawing.Size(138, 65);
            this.buttonThreeColor.TabIndex = 5;
            this.buttonThreeColor.Text = "TriColorare";
            this.buttonThreeColor.UseVisualStyleBackColor = true;
            this.buttonThreeColor.Click += new System.EventHandler(this.buttonThreeColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonThreeColor);
            this.Controls.Add(this.labelArie);
            this.Controls.Add(this.btnArie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrianguleaza);
            this.Controls.Add(this.btnInchide);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInchide;
        private System.Windows.Forms.Button btnTrianguleaza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArie;
        private System.Windows.Forms.Label labelArie;
        private System.Windows.Forms.Button buttonThreeColor;
    }
}

