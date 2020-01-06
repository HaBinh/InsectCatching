using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsectCatching
{
    public partial class Form1 : Form
    {
        const int NUM_OF_INSTANCES = 61;
        int score = 0;
        int counter = 600;
        Random rand = new Random();
        private Insect[] insects;
        int formHeight = 0;
        int formWidth = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            insects = new Insect[NUM_OF_INSTANCES];
            formHeight = this.Size.Height - 40;
            formWidth = this.Size.Width - 16;
            InitInsects();
        }

        private void InitInsects()
        {
            for (int i = 0; i < NUM_OF_INSTANCES; i++)
            {
                int r = rand.Next(0, 3);
                if (r == 0) insects[i] = new Kabutomushi(formWidth, formHeight);
                if (r == 1) insects[i] = new Inbo(formWidth, formHeight);
                if (r == 2) insects[i] = new Butterfly(formWidth, formHeight);
            }
            SuspendLayout();
            for (int i = 0; i < NUM_OF_INSTANCES; i++)
            {
                insects[i].Name = "insect" + i.ToString();
                insects[i].Click += new EventHandler(insect_Click);
            }
            Controls.AddRange(insects);
            ResumeLayout(false);
        }

        private void insect_Click(object sender, EventArgs e)
        {
            int n = int.Parse(((PictureBox)sender).Name.Substring(6));
            insects[n].Visible = false;
            score++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimeRemain.Text = "残り時間：" + counter / 10 + "秒";
            labelScore.Text = "得点：" + score;
            if (counter % 10 == 0)
            {
                insects[counter / 10].Visible = true;
            }
            counter--;
            for (int i = NUM_OF_INSTANCES - 1; i > counter/10; i--)
            {
                insects[i].Moving();
            }
            if (counter == 0)
            {
                timer1.Stop();
                labelTimeRemain.Text = "ゲームオーバー";
                foreach(Insect insect in insects)
                {
                    insect.Visible = false;
                }
                InitInsects();
                buttonStart.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            score = 0;
            counter = 600;
            timer1.Start();
            buttonStart.Enabled = false;
        }
    }
}
