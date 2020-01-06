using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectCatching
{
    class Butterfly : Insect
    {
        const int MIN_SPEED_X = 5;
        const int MAX_SPEED_X = 30;
        const int MIN_SPEED_Y = 2;
        const int MAX_SPEED_Y = 10;
        Random rand = new Random();
        int speedX = 0;
        int speedY = 0;
        int signSpeedX = 1;
        int signSpeedY = 1;
        public Butterfly(int maxWidth, int maxHeight)
            : base(maxWidth, maxHeight, Properties.Resources.butterfly_right)
        {
            RandSpeed();
            InitPosition();
            base.Draw();
        }
        private void RandSpeed()
        {
            speedX = rand.Next(MIN_SPEED_X, MAX_SPEED_X);
            speedY = rand.Next(MIN_SPEED_Y, MAX_SPEED_Y);
        }
        public override void InitPosition()
        {
            PositionX = 0;
            PositionY = MaxHeight - Size.Height;
        }

        public override void Moving()
        {
            int r = rand.Next(100);
            if (r < 70)
            {
                speedX = rand.Next(MIN_SPEED_X, MAX_SPEED_X) * signSpeedX;
            }
            else
            {
                speedX = rand.Next(MIN_SPEED_X, MAX_SPEED_X) * -signSpeedX;
            }

            r = rand.Next(100);
            if (r < 70)
            {
                speedY = rand.Next(MIN_SPEED_Y, MAX_SPEED_Y) * signSpeedY;
            }
            else
            {
                speedY = rand.Next(MIN_SPEED_Y, MAX_SPEED_Y) * -signSpeedY;
            }

            PositionX += speedX;
            if (PositionX + Size.Width >= MaxWidth)
            {
                Image = Properties.Resources.butterfly_left;
                PositionX = MaxWidth - Size.Width;
                signSpeedX *= -1;
            }
            if (PositionX <= 0)
            {
                Image = Properties.Resources.butterfly_right;
                PositionX = 0;
                signSpeedX *= -1;
            }
            PositionY += speedY;
            if ((PositionY + Size.Height >= MaxHeight))
            {
                PositionY = MaxHeight - Size.Height;
                signSpeedY *= -1;
            }
            if ((PositionY <= 0))
            {
                PositionY = 0;
                signSpeedY *= -1;
            }
            Draw();
        }
    }
}
