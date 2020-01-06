using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsectCatching
{
    abstract class Insect : PictureBox
    {
        public Insect(int maxWidth, int maxHeight, Image image)
        {
            base.Image = image;
            base.SizeMode = PictureBoxSizeMode.AutoSize;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            base.Visible = false;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set;  }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public abstract void Moving();
        public abstract void InitPosition();
        public void Draw()
        {
            base.Location = new Point(PositionX, PositionY);
        }
    }
}
