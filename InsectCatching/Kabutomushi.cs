using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectCatching
{
    class Kabutomushi : Insect
    {
        Random rand = new Random();
        int speed = 0;
        string state = "up";

        public Kabutomushi(int maxWidth, int maxHeight) : base(maxWidth, maxHeight, Properties.Resources.beetle_up)
        {
            speed = rand.Next(5, 25);
            InitPosition();
            base.Draw();
        }

        public override void InitPosition()
        {
            PositionX = MaxWidth - Image.Width;
            PositionY = MaxHeight - Image.Height;
        }

        public override void Moving()
        {
            switch (state)
            {
                case "up":
                    if (PositionY <= 0)
                    {
                        state = "left";
                        Image = Properties.Resources.beetle_upsidedown;
                        PositionX = MaxWidth - base.Size.Width;
                        PositionY = 0;
                    }
                    else
                    {
                        PositionY -= speed;
                    }
                    break;
                case "left":
                    if (PositionX <= 0)
                    {
                        state = "down";
                        Image = Properties.Resources.beetle_down;
                        PositionX = 0;
                        PositionY = 0;
                    }
                    else
                    {
                        PositionX -= speed;
                    }
                    break;
                case "down":
                    if (PositionY >= MaxHeight - base.Size.Height)
                    {
                        state = "right";
                        Image = Properties.Resources.beetle_right;
                        PositionX = 0;
                        PositionY = MaxHeight - base.Size.Height;
                    }
                    else
                    {
                        PositionY += speed;
                    }
                    break;
                case "right":
                    if (PositionX >= MaxWidth - base.Size.Width)
                    {
                        state = "up";
                        Image = Properties.Resources.beetle_up;
                        this.InitPosition();
                    }
                    else
                    {
                        PositionX += speed;
                    }
                    break;
            }
            base.Draw();
        }
    }
}
