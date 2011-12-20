using System;
using System.Drawing;
using Machine.Specifications;
using SpeakerNet.Services;

namespace SpeakerWeb.Tests
{
    [Subject(typeof(Cropping))]
    public class CropImageSpecsBaseBoSizesAreEqual : CropImageSpecsBase
    {
        Establish context = () =>
                                {
                                    sourceSize = new Size(90, 180);
                                    destSize = new Size(90, 180);
                                };

        It shoud_return_a_multiplicator_of_1 = () => multi.ShouldEqual(1.0);
    }

    public abstract class CropImageSpecsBase
    {
        Because because = () => multi = new Cropping().GetMultiplicator(sourceSize, destSize);
        protected static double multi;
        protected static Size sourceSize;
        protected static Size destSize;
    }
}