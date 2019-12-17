namespace DynamicsTools.Form_2
{
    partial class Daten_Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daten_Transfer));
            this.comboBox_InDatabase = new System.Windows.Forms.ComboBox();
            this.comboBox_FromDatabase = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_FromCompany = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_InCompany = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_TableName = new System.Windows.Forms.ComboBox();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.button_DataTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_InDatabase
            // 
            this.comboBox_InDatabase.Enabled = false;
            this.comboBox_InDatabase.FormattingEnabled = true;
            this.comboBox_InDatabase.Location = new System.Drawing.Point(222, 54);
            this.comboBox_InDatabase.Name = "comboBox_InDatabase";
            this.comboBox_InDatabase.Size = new System.Drawing.Size(197, 21);
            this.comboBox_InDatabase.TabIndex = 13;
            this.comboBox_InDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox_FromDatabase
            // 
            this.comboBox_FromDatabase.FormattingEnabled = true;
            this.comboBox_FromDatabase.Location = new System.Drawing.Point(12, 54);
            this.comboBox_FromDatabase.Name = "comboBox_FromDatabase";
            this.comboBox_FromDatabase.Size = new System.Drawing.Size(197, 21);
            this.comboBox_FromDatabase.TabIndex = 12;
            this.comboBox_FromDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 9);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "OTE-NET\\DGutierrez";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Server Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "From the Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Into Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "From Company:";
            // 
            // comboBox_FromCompany
            // 
            this.comboBox_FromCompany.Enabled = false;
            this.comboBox_FromCompany.FormattingEnabled = true;
            this.comboBox_FromCompany.Location = new System.Drawing.Point(12, 94);
            this.comboBox_FromCompany.Name = "comboBox_FromCompany";
            this.comboBox_FromCompany.Size = new System.Drawing.Size(197, 21);
            this.comboBox_FromCompany.TabIndex = 18;
            this.comboBox_FromCompany.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Into Company:";
            // 
            // comboBox_InCompany
            // 
            this.comboBox_InCompany.Enabled = false;
            this.comboBox_InCompany.FormattingEnabled = true;
            this.comboBox_InCompany.Location = new System.Drawing.Point(222, 94);
            this.comboBox_InCompany.Name = "comboBox_InCompany";
            this.comboBox_InCompany.Size = new System.Drawing.Size(197, 21);
            this.comboBox_InCompany.TabIndex = 20;
            this.comboBox_InCompany.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Table Name:";
            // 
            // comboBox_TableName
            // 
            this.comboBox_TableName.Enabled = false;
            this.comboBox_TableName.FormattingEnabled = true;
            this.comboBox_TableName.Location = new System.Drawing.Point(86, 131);
            this.comboBox_TableName.Name = "comboBox_TableName";
            this.comboBox_TableName.Size = new System.Drawing.Size(333, 21);
            this.comboBox_TableName.TabIndex = 23;
            this.comboBox_TableName.SelectedIndexChanged += new System.EventHandler(this.comboBox_TableName_SelectedIndexChanged);
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 16;
            this.lineShape1.X2 = 415;
            this.lineShape1.Y1 = 170;
            this.lineShape1.Y2 = 170;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(428, 219);
            this.shapeContainer1.TabIndex = 24;
            this.shapeContainer1.TabStop = false;
            // 
            // button_DataTransfer
            // 
            this.button_DataTransfer.Location = new System.Drawing.Point(288, 184);
            this.button_DataTransfer.Name = "button_DataTransfer";
            this.button_DataTransfer.Size = new System.Drawing.Size(131, 25);
            this.button_DataTransfer.TabIndex = 25;
            this.button_DataTransfer.Text = "Data Transfer";
            this.button_DataTransfer.UseVisualStyleBackColor = true;
            this.button_DataTransfer.Click += new System.EventHandler(this.button_DataTransfer_Click);
            // 
            // Daten_Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 219);
            this.Controls.Add(this.button_DataTransfer);
            this.Controls.Add(this.comboBox_TableName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_InCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_FromCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_InDatabase);
            this.Controls.Add(this.comboBox_FromDatabase);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Daten_Transfer";
            this.Text = "Daten Transfer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_InDatabase;
        private System.Windows.Forms.ComboBox comboBox_FromDatabase;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_FromCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_InCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_TableName;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button button_DataTransfer;

    }
}