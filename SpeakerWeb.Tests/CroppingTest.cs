using System.Drawing;
using SpeakerNet.Services;
using Xunit;

namespace SpeakerWeb.Tests
{
    public class CroppingTest
    {
        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf1()
        {
            var sourceSize = new Size(90, 180);
            var destSize = new Size(90, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(1.0, multi, 2);
        }

        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf2()
        {
            var sourceSize = new Size(90, 180);
            var destSize = new Size(180, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(2.0, multi, 2);
        }

        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf3()
        {
            var sourceSize = new Size(180, 180);
            var destSize = new Size(180, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(1.0, multi, 2);
        }

        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf4()
        {
            var sourceSize = new Size(360, 360);
            var destSize = new Size(180, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(0.5, multi, 2);
        }

        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf5()
        {
            var sourceSize = new Size(180, 360);
            var destSize = new Size(180, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(1, multi, 2);
        }

        [Fact]
        public void SameSourceAndDestSizeResultInMultiplicatorOf6()
        {
            var sourceSize = new Size(463, 600);
            var destSize = new Size(180, 180);

            var multi = new Cropping().GetMultiplicator(sourceSize, destSize);
            Assert.Equal(0.39, multi, 2);
        }
    }
}