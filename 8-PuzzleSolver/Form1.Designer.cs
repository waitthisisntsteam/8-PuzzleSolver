namespace _8_PuzzleSolver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(200, 200);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += puzzleClick;
            // 
            // button2
            // 
            button2.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(200, 0);
            button2.Name = "button2";
            button2.Size = new Size(200, 200);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += puzzleClick;
            // 
            // button3
            // 
            button3.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(400, 0);
            button3.Name = "button3";
            button3.Size = new Size(200, 200);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += puzzleClick;
            // 
            // button4
            // 
            button4.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(400, 200);
            button4.Name = "button4";
            button4.Size = new Size(200, 200);
            button4.TabIndex = 5;
            button4.Text = "6";
            button4.UseVisualStyleBackColor = true;
            button4.Click += puzzleClick;
            // 
            // button5
            // 
            button5.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(200, 200);
            button5.Name = "button5";
            button5.Size = new Size(200, 200);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += puzzleClick;
            // 
            // button6
            // 
            button6.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(0, 200);
            button6.Name = "button6";
            button6.Size = new Size(200, 200);
            button6.TabIndex = 3;
            button6.Text = "4";
            button6.UseVisualStyleBackColor = true;
            button6.Click += puzzleClick;
            // 
            // button7
            // 
            button7.Location = new Point(400, 400);
            button7.Name = "button7";
            button7.Size = new Size(200, 200);
            button7.TabIndex = 8;
            button7.Text = " ";
            button7.UseVisualStyleBackColor = true;
            button7.Click += puzzleClick;
            // 
            // button8
            // 
            button8.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(200, 400);
            button8.Name = "button8";
            button8.Size = new Size(200, 200);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += puzzleClick;
            // 
            // button9
            // 
            button9.Font = new Font("Malgun Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(0, 400);
            button9.Name = "button9";
            button9.Size = new Size(200, 200);
            button9.TabIndex = 6;
            button9.Text = "7";
            button9.UseVisualStyleBackColor = true;
            button9.Click += puzzleClick;
            // 
            // button10
            // 
            button10.Font = new Font("Malgun Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(238, 614);
            button10.Name = "button10";
            button10.Size = new Size(121, 63);
            button10.TabIndex = 9;
            button10.Text = "Solve";
            button10.UseVisualStyleBackColor = true;
            button10.Click += solveClick;
            // 
            // button11
            // 
            button11.Font = new Font("Malgun Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.Location = new Point(38, 614);
            button11.Name = "button11";
            button11.Size = new Size(121, 63);
            button11.TabIndex = 10;
            button11.Text = "Scramble";
            button11.UseVisualStyleBackColor = true;
            button11.Click += scrambleClick;
            // 
            // button12
            // 
            button12.Location = new Point(431, 613);
            button12.Name = "button12";
            button12.Size = new Size(121, 62);
            button12.TabIndex = 11;
            button12.Text = "Reset";
            button12.UseVisualStyleBackColor = true;
            button12.Click += resetButton;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 707);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
    }
}
