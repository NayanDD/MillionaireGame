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
    public partial class RemoveForm : Form
    {
        Adapted_string toBeDeleted;
        Adapted_strings Adstrs;
        Adapted_string[] LocalAdstr;
        int counter = 0;
        NumericUpDown nud;

        public Adapted_string ToBeDeleted
        {
            get { return toBeDeleted; }
        }
        public RemoveForm(Adapted_strings Adstrs)
        {
            InitializeComponent();
            nud = this.ArraySpin;
            nud.Maximum = Adstrs.Length;
            LocalAdstr = Adstrs.GimmeStrings;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            toBeDeleted = new Adapted_string(this.RemoveText.Text, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArraySpin_Scroll(object sender, ScrollEventArgs e)
        {
            counter = (int)nud.Value - 1;
            this.RemoveText.Text = LocalAdstr[counter].quest;
        }

        private void RemoveForm_Load(object sender, EventArgs e)
        {
            this.RemoveText.Text = LocalAdstr[counter].quest;
        }

        private void ArraySpin_Scroll(object sender, EventArgs e)
        {
            counter = (int)nud.Value - 1;
            this.RemoveText.Text = LocalAdstr[counter].quest;
        }
    }
}
