namespace TriangularePoligoaneMonotone
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
            this.btnSavePolygon = new System.Windows.Forms.Button();
            this.btnTrianguleaza = new System.Windows.Forms.Button();
            this.listBoxPoligoane = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(642, 12);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(146, 67);
            this.btnInchide.TabIndex = 0;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // btnPartitioneaza
            // 
            this.btnPartitioneaza.Location = new System.Drawing.Point(642, 85);
            this.btnPartitioneaza.Name = "btnPartitioneaza";
            this.btnPartitioneaza.Size = new System.Drawing.Size(146, 67);
            this.btnPartitioneaza.TabIndex = 1;
            this.btnPartitioneaza.Text = "partitioneaza";
            this.btnPartitioneaza.UseVisualStyleBackColor = true;
            this.btnPartitioneaza.Click += new System.EventHandler(this.btnPartitioneaza_Click);
            // 
            // btnSavePolygon
            // 
            this.btnSavePolygon.Location = new System.Drawing.Point(642, 158);
            this.btnSavePolygon.Name = "btnSavePolygon";
            this.btnSavePolygon.Size = new System.Drawing.Size(146, 67);
            this.btnSavePolygon.TabIndex = 2;
            this.btnSavePolygon.Text = "Salvare";
            this.btnSavePolygon.UseVisualStyleBackColor = true;
            this.btnSavePolygon.Click += new System.EventHandler(this.btnSavePolygon_Click);
            // 
            // btnTrianguleaza
            // 
            this.btnTrianguleaza.Location = new System.Drawing.Point(642, 231);
            this.btnTrianguleaza.Name = "btnTrianguleaza";
            this.btnTrianguleaza.Size = new System.Drawing.Size(146, 67);
            this.btnTrianguleaza.TabIndex = 3;
            this.btnTrianguleaza.Text = "Trianguleaza";
            this.btnTrianguleaza.UseVisualStyleBackColor = true;
            this.btnTrianguleaza.Click += new System.EventHandler(this.btnTrianguleaza_Click);
            // 
            // listBoxPoligoane
            // 
            this.listBoxPoligoane.FormattingEnabled = true;
            this.listBoxPoligoane.ItemHeight = 16;
            this.listBoxPoligoane.Location = new System.Drawing.Point(516, 12);
            this.listBoxPoligoane.Name = "listBoxPoligoane";
            this.listBoxPoligoane.Size = new System.Drawing.Size(120, 84);
            this.listBoxPoligoane.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxPoligoane);
            this.Controls.Add(this.btnTrianguleaza);
            this.Controls.Add(this.btnSavePolygon);
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
        private System.Windows.Forms.Button btnSavePolygon;
        private System.Windows.Forms.Button btnTrianguleaza;
        private System.Windows.Forms.ListBox listBoxPoligoane;
    }
}

