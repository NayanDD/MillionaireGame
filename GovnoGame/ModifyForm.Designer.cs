namespace GovnoGame
{
    partial class ModifyForm
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
            this.ArraySpin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Answer4Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Answer3Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Answer2Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CorrectAnswerBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArraySpin)).BeginInit();
            this.SuspendLayout();
            // 
            // ArraySpin
            // 
            this.ArraySpin.Location = new System.Drawing.Point(105, 10);
            this.ArraySpin.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.ArraySpin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ArraySpin.Name = "ArraySpin";
            this.ArraySpin.Size = new System.Drawing.Size(40, 20);
            this.ArraySpin.TabIndex = 3;
            this.ArraySpin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ArraySpin.ValueChanged += new System.EventHandler(this.ArraySpin_Scroll);
            this.ArraySpin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ArraySpin_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер вопроса: ";
            // 
            // Answer4Box
            // 
            this.Answer4Box.Location = new System.Drawing.Point(14, 210);
            this.Answer4Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer4Box.Name = "Answer4Box";
            this.Answer4Box.Size = new System.Drawing.Size(256, 20);
            this.Answer4Box.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Введите четвёртый вариант ответа:";
            // 
            // Answer3Box
            // 
            this.Answer3Box.Location = new System.Drawing.Point(14, 170);
            this.Answer3Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer3Box.Name = "Answer3Box";
            this.Answer3Box.Size = new System.Drawing.Size(256, 20);
            this.Answer3Box.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Введите третий вариант ответа:";
            // 
            // Answer2Box
            // 
            this.Answer2Box.Location = new System.Drawing.Point(14, 130);
            this.Answer2Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer2Box.Name = "Answer2Box";
            this.Answer2Box.Size = new System.Drawing.Size(256, 20);
            this.Answer2Box.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Введите второй вариант ответа:";
            // 
            // CorrectAnswerBox
            // 
            this.CorrectAnswerBox.Location = new System.Drawing.Point(14, 90);
            this.CorrectAnswerBox.Margin = new System.Windows.Forms.Padding(0);
            this.CorrectAnswerBox.Name = "CorrectAnswerBox";
            this.CorrectAnswerBox.Size = new System.Drawing.Size(256, 20);
            this.CorrectAnswerBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Введите первый вариант ответа(правильный):";
            // 
            // QuestionBox
            // 
            this.QuestionBox.Location = new System.Drawing.Point(14, 50);
            this.QuestionBox.Margin = new System.Windows.Forms.Padding(0);
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(256, 20);
            this.QuestionBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Введите вопрос:";
            // 
            // ChangeButton
            // 
            this.ChangeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChangeButton.Location = new System.Drawing.Point(12, 245);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(75, 25);
            this.ChangeButton.TabIndex = 20;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(197, 245);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.Answer4Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Answer3Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Answer2Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CorrectAnswerBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ArraySpin);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.Load += new System.EventHandler(this.ModifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArraySpin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ArraySpin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Answer4Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Answer3Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Answer2Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CorrectAnswerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox QuestionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button CancelButton;
    }
}