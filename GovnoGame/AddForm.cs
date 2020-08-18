using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GovnoGame
{
    public partial class AddForm : Form
    {
        Adapted_string toBeAdded;

        public Adapted_string ToBeAdded
        {
            get { return toBeAdded; }
        }


        public AddForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            toBeAdded = new Adapted_string(this.QuestionBox.Text, this.CorrectAnswerBox.Text, this.Answer2Box.Text, this.Answer3Box.Text, this.Answer4Box.Text);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
