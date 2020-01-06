using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectCatching
{
    class Inbo : Insect
    {
        const int MIN_SPEED = 5;
        const int MAX_SPEED = 35;
        Random rand = new Random();
        int speedX = 0;
        int speedY = 0;
        public Inbo(int maxWidth, int maxHeight) 
            : base(maxWidth, maxHeight, Properties.Resources.dragonfly_right)
        {
            speedX = rand.Next(MIN_SPEED, MAX_SPEED);
            speedY = rand.Next(MIN_SPEED, MAX_SPEED);
            InitPosition();
            base.Draw();
        }

        public override void InitPosition()
        {
            PositionX = 0;
            PositionY = 40;
        }

        public override void Moving()
        {
            PositionX += speedX;
            if (PositionX + Size.Width >= MaxWidth)
            {
                Image = Properties.Resources.dragonfly_left;
                speedX = rand.Next(MIN_SPEED, MAX_SPEED);
                speedX *= -1;
            }
            if (PositionX <= 0)
            {
                Image = Properties.Resources.dragonfly_right;
                speedX = rand.Next(MIN_SPEED, MAX_SPEED);
            }
            PositionY += speedY;
            if ((PositionY + Size.Height >= MaxHeight))
            {
                speedY = rand.Next(MIN_SPEED, MAX_SPEED);
                speedY *= -1;
            }
            if ((PositionY <= 0))
            {
                speedY = rand.Next(MIN_SPEED, MAX_SPEED);
            }
            base.Draw();
        }
    }
}
