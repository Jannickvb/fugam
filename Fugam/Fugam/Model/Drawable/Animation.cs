using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fugam.Model.Drawable
{
    public class Animation
    {

        private Bitmap spritesheet;
        private Bitmap[] subimages;
        private int spriteIndex;
        private bool hasPlayedOnce;
        private long startTime, delay;

        public Animation(Bitmap spritesheet, int width, int height, long delay)
        {
            this.spritesheet = spritesheet;

            this.spriteIndex = 0;
            this.delay = delay;
            this.startTime = DateTime.Now.ToFileTime();

            this.subimages = new Bitmap[spritesheet.Width / width];

            for(int i = 0; i < subimages.Length; i++)
            {
                subimages[i] = spritesheet.Clone(new Rectangle(i*width,0,width, height),spritesheet.PixelFormat);
            }

        }

        public void Update()
        {
            if (delay == -1)
                return;

            spriteIndex++;

            if(spriteIndex == subimages.Length)
            {
                spriteIndex = 0;
                hasPlayedOnce = true;
            }

            Thread.Sleep((int)delay);
        }

        public Bitmap GetCurrentImage()
        {
            return subimages[spriteIndex];
        }

        public void SetDelay(long d)
        {
            delay = d;
        }

        public void SetFrame(int i)
        {
            spriteIndex = i;
        }

    }
}
