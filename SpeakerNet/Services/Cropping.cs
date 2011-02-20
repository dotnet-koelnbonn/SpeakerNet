using System;
using System.Drawing;

namespace SpeakerNet.Services
{
    public class Cropping
    {
        public double GetMultiplicator(Size sourceSize, Size destSize)
        {
            double sWidth = sourceSize.Width;
            double sHeight = sourceSize.Height;
            double dWidth = destSize.Width;
            double dHeight = destSize.Height;
            double heightMux = dHeight/sHeight;
            double widthMux = dWidth/sWidth;
            return Math.Max(heightMux, widthMux);
        }
    }
}