namespace GovnoGame
{
    partial class AddForm
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
            this.QuestionBox = new System.Windows.Forms.TextBox();
            this.CorrectAnswerBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Answer2Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Answer3Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Answer4Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите вопрос:";
            // 
            // QuestionBox
            // 
            this.QuestionBox.Location = new System.Drawing.Point(12, 30);
            this.QuestionBox.Margin = new System.Windows.Forms.Padding(0);
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(256, 20);
            this.QuestionBox.TabIndex = 1;
            // 
            // CorrectAnswerBox
            // 
            this.CorrectAnswerBox.Location = new System.Drawing.Point(12, 70);
            this.CorrectAnswerBox.Margin = new System.Windows.Forms.Padding(0);
            this.CorrectAnswerBox.Name = "CorrectAnswerBox";
            this.CorrectAnswerBox.Size = new System.Drawing.Size(256, 20);
            this.CorrectAnswerBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите первый вариант ответа(правильный):";
            // 
            // Answer2Box
            // 
            this.Answer2Box.Location = new System.Drawing.Point(12, 110);
            this.Answer2Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer2Box.Name = "Answer2Box";
            this.Answer2Box.Size = new System.Drawing.Size(256, 20);
            this.Answer2Box.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Введите второй вариант ответа:";
            // 
            // Answer3Box
            // 
            this.Answer3Box.Location = new System.Drawing.Point(12, 150);
            this.Answer3Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer3Box.Name = "Answer3Box";
            this.Answer3Box.Size = new System.Drawing.Size(256, 20);
            this.Answer3Box.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Введите третий вариант ответа:";
            // 
            // Answer4Box
            // 
            this.Answer4Box.Location = new System.Drawing.Point(12, 190);
            this.Answer4Box.Margin = new System.Windows.Forms.Padding(0);
            this.Answer4Box.Name = "Answer4Box";
            this.Answer4Box.Size = new System.Drawing.Size(256, 20);
            this.Answer4Box.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Введите четвёртый вариант ответа:";
            // 
            // AddButton
            // 
            this.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddButton.Location = new System.Drawing.Point(12, 225);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 25);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(192, 225);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Answer4Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Answer3Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Answer2Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CorrectAnswerBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.Text = "Добавление вопроса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QuestionBox;
        private System.Windows.Forms.TextBox CorrectAnswerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Answer2Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Answer3Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Answer4Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
    }
}