using System.Windows.Forms;
namespace NijnCoach.View.TherapistGUI
{
    partial class PatientOverview
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support   do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button7 = new System.Windows.Forms.Button();
            this.labelH = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            System.Windows.Forms.Label[] labels = { label0,label1,label2, label3, label4, label5, label6, label7, label8, label9, label11, labelH };
            System.Windows.Forms.TextBox[] texts = { textBox0,textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };

            string[] labelText = { "Patient number","Fisrt name","Last name","Age","Street","House number","Postal code","City","Email address","Telephone number"};
            int[] tsize = { 58, 160,160,58,160,58,100,160,160,160 };

            for (int i = 0; i < 10; i++)
            {
                GUIHelper.setElement(ref labels[i], new System.Drawing.Point(371, 150 + 29 * i), "label" + i.ToString(), new System.Drawing.Size(75, 20), i +100, labelText[i]);
                GUIHelper.setElement(ref texts[i], new System.Drawing.Point(513, 150 + 29 * i), "textBox" + i.ToString(), new System.Drawing.Size(tsize[i], 22), i, "");
                labels[i].AutoSize = true;
                texts[i].ReadOnly = true;
            }

            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(6, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Home";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click +=new System.EventHandler(button7_Click);
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelH.Location = new System.Drawing.Point(199, 45);
            this.labelH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(319, 46);
            this.labelH.TabIndex = 40;
            this.labelH.Text = "Patient Overview";
            this.labelH.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 41;
            this.label11.Text = "Patients:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(346, 321);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.CellClick +=new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView1.TabIndex = 42;

            // UserControl1
            // 
            this.Controls.AddRange(texts);
            this.Controls.AddRange(labels);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label0,label1, label2, label3, label4, label5, label6, label7, label8, label9, label11, labelH;
        private DataGridView dataGridView1;
        public TextBox textBox0,textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9;
        
    }
}
