namespace NijnCoach.View.PatientFiles
{
    partial class UserCreate
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmPassBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            System.Windows.Forms.Label[] labels = { label1, label2, label3, label4, label5};
            System.Windows.Forms.TextBox[] textBoxes = { textBox1, textBox2,confirmPassBox };
            System.Windows.Forms.Button[] buttons = {button1,button2};
            System.Windows.Forms.RadioButton[] rButtons = { radioButton1,radioButton2};

            string[] labelText = {"New User","Type","Username","Password", "Confirm password"};
            int[] labelLoc = {229,168,235,275,315};

            string[] rButtonText = { "Patient", "Therapist" };
            System.EventHandler[] eventHandlers = { button1_Click, button2_Click};
            for (int i = 0; i < 5; i++)
            {
                GUIHelper.setElement(ref labels[i], new System.Drawing.Point(101, labelLoc[i]), "label" + (1 + i).ToString(), new System.Drawing.Size(69, 17), i, labelText[i]);
                labels[i].AutoSize = true;
            }

            for (int i = 0; i < 3; i++)
            {
                GUIHelper.setElement(ref textBoxes[i], new System.Drawing.Point(236, 233 + 40 * i), "textBox" + (1 + i).ToString(),new System.Drawing.Size(189, 22),i+7,"");
            }
            for (int i = 0;i<2;i++){
                rButtons[i].AutoSize = true;
                rButtons[i].UseVisualStyleBackColor = true;
                GUIHelper.setElement(ref rButtons[i],new System.Drawing.Point(236, 163 + 27*i),"radioButton" + (1 + i).ToString(),new System.Drawing.Size(89, 21),i+5,rButtonText[i]);
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click +=new System.EventHandler(eventHandlers[i]);
            }
            // 
            // textBox2
            // 
            this.textBox2.PasswordChar = '*';
          
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 62);
            this.label1.Size = new System.Drawing.Size(162, 38);
            this.label1.Text = "New User";
                
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(447, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 57);
            this.button1.TabIndex = 17;
            this.button1.Text = "Create User";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Home";
            // 
            // confirmPassBox
            // 
            this.confirmPassBox.Name = "confirmPassBox";
            this.confirmPassBox.PasswordChar = '*';

            this.Controls.AddRange(labels);
            this.Controls.AddRange(buttons);
            this.Controls.AddRange(textBoxes);
            this.Controls.AddRange(rButtons);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1, textBox2, confirmPassBox;
        private System.Windows.Forms.Label label1,label2,label3,label4,label5;
        private System.Windows.Forms.RadioButton radioButton1, radioButton2;
        private System.Windows.Forms.Button button1, button2;
    }
}
