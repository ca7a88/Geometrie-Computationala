namespace TemaPartitionarePoligoaneMonotone
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
            this.btnPartitioneaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(610, 23);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(137, 72);
            this.btnInchide.TabIndex = 0;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // btnPartitioneaza
            // 
            this.btnPartitioneaza.Location = new System.Drawing.Point(610, 128);
            this.btnPartitioneaza.Name = "btnPartitioneaza";
            this.btnPartitioneaza.Size = new System.Drawing.Size(137, 72);
            this.btnPartitioneaza.TabIndex = 1;
            this.btnPartitioneaza.Text = "Partitioneaza";
            this.btnPartitioneaza.UseVisualStyleBackColor = true;
            this.btnPartitioneaza.Click += new System.EventHandler(this.btnPartitioneaza_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPartitioneaza);
            this.Controls.Add(this.btnInchide);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInchide;
        private System.Windows.Forms.Button btnPartitioneaza;
    }
}

