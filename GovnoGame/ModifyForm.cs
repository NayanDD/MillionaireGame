using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GovnoGame
{
    public partial class ModifyForm : Form
    {
        Adapted_string toBeModified;
        Adapted_strings Adstrs;
        Adapted_string[] LocalAdstr;
        int counter = 0;
        NumericUpDown nud;

        public Adapted_string ToBeModified
        {
            get { return toBeModified; }
        }

        public ModifyForm(Adapted_strings Adstrs)
        {
            InitializeComponent();
            nud = this.ArraySpin;
            nud.Maximum = Adstrs.Length;
            LocalAdstr = Adstrs.GimmeStrings;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            toBeModified = new Adapted_string(this.QuestionBox.Text, this.CorrectAnswerBox.Text, this.Answer2Box.Text, this.Answer3Box.Text, this.Answer4Box.Text);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArraySpin_Scroll(object sender, ScrollEventArgs e)
        {
            counter = (int)nud.Value - 1;
            this.QuestionBox.Text = LocalAdstr[counter].quest;
            this.CorrectAnswerBox.Text = LocalAdstr[counter].correct_answer;
            this.Answer2Box.Text = LocalAdstr[counter].answer2;
            this.Answer3Box.Text = LocalAdstr[counter].answer3;
            this.Answer4Box.Text = LocalAdstr[counter].answer4;
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            this.QuestionBox.Text = LocalAdstr[counter].quest;
            this.CorrectAnswerBox.Text = LocalAdstr[counter].correct_answer;
            this.Answer2Box.Text = LocalAdstr[counter].answer2;
            this.Answer3Box.Text = LocalAdstr[counter].answer3;
            this.Answer4Box.Text = LocalAdstr[counter].answer4;
        }

        private void ArraySpin_Scroll(object sender, EventArgs e)
        {
            counter = (int)nud.Value - 1;
            this.QuestionBox.Text = LocalAdstr[counter].quest;
            this.CorrectAnswerBox.Text = LocalAdstr[counter].correct_answer;
            this.Answer2Box.Text = LocalAdstr[counter].answer2;
            this.Answer3Box.Text = LocalAdstr[counter].answer3;
            this.Answer4Box.Text = LocalAdstr[counter].answer4;
        }
    }
}
