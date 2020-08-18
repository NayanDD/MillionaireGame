namespace GovnoGame
{
    partial class RemoveForm
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
            this.ArraySpin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RemoveText = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArraySpin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер вопроса: ";
            // 
            // ArraySpin
            // 
            this.ArraySpin.Location = new System.Drawing.Point(104, 13);
            this.ArraySpin.Maximum = new decimal(new int[] {
            15,
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
            this.ArraySpin.TabIndex = 1;
            this.ArraySpin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ArraySpin.ValueChanged += new System.EventHandler(this.ArraySpin_Scroll);
            this.ArraySpin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ArraySpin_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Вопрос для удаления: ";
            // 
            // RemoveText
            // 
            this.RemoveText.Enabled = false;
            this.RemoveText.Location = new System.Drawing.Point(12, 80);
            this.RemoveText.Name = "RemoveText";
            this.RemoveText.Size = new System.Drawing.Size(260, 20);
            this.RemoveText.TabIndex = 3;
            this.RemoveText.Text = "Текст вопроса";
            // 
            // RemoveButton
            // 
            this.RemoveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RemoveButton.Location = new System.Drawing.Point(16, 115);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 25);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(197, 115);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RemoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 151);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.RemoveText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArraySpin);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveForm";
            this.Text = "Удаление вопроса";
            this.Load += new System.EventHandler(this.RemoveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArraySpin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ArraySpin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RemoveText;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}