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
using System.Media;

namespace GovnoGame
{
    public partial class WinForm : Form
    {
        int flag  = 0; // 1 = выиграл, -1 = проиграл, 0 = игра была остановлена.
        int index = 0; /* Текущий выигрыш на случай, если игра была остановлена.
                        * -1 = не показывать выигрыш (действовать по шаблону, т.е. выиграл миллион/проиграл окончательно)
                        * от 1 до 14 = выигрыш соответствующий таблице. */

        public WinForm(int f, int uindex)
        {
            InitializeComponent();
            flag = f;
            index = uindex;
        }
        private void WinForm_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.pictureBox1.BackgroundImage = Properties.Resources.Vifrash;
                this.PictureGalkin.BackgroundImage = Properties.Resources._12122;
                this.Matugalnik.Text = "Поздравляем, вы выиграли миллион!";
            }
            else if (flag == 0)
            {
                this.Text = "Вы остановились!";
                this.pictureBox1.BackgroundImage = Properties.Resources.vig;
                this.PictureGalkin.BackgroundImage = Properties.Resources._12122;
                this.Matugalnik.Text = "Вы решили остановится. Ваш выигрыш : " + IndexConverter().ToString();
            }
            else if (flag == -1)
            {
                this.Text = "Вы проиграли!";
                this.pictureBox1.BackgroundImage = Properties.Resources.vig;
                this.PictureGalkin.BackgroundImage = Properties.Resources._12122;
                if (IndexConverter() == 0)
                    this.Matugalnik.Text = "Ну что ж... В следующий раз повезёт!!";
                else
                    this.Matugalnik.Text = "Ну что ж... В следующий раз повезёт больше!! Ваш выигрыш : " + IndexConverter().ToString();
            }
            else
            {
                this.Text = "Если вы читаете это, значит что-то пошло не так...";
                this.Matugalnik.Name = "Если вы читаете это, значит что-то пошло не так...";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int IndexConverter()
        {
            int result = 0;
            if(result >= 5)
                return 1000;
            if (result >= 10)
                return 32000;
            else if (result == 15)
                return 1000000;
            else
                return 0;
        }

        private void WinForm_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
