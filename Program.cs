using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceImage = @"Images/seattle.jpg";
            string squareTargetThumb = @"Images/seattle_square_thumb.jpg";
            string targetThumbAccordingToRatio = @"Images/seattle_ratio_thumb.jpg";
            string targetThumbAccordingToWidth = @"Images/seattle_width_thumb.jpg";
            string targetThumbAccordingToHeight = @"Images/seattle_height_thumb.jpg";

            ThumbLib.GenerateSquareThumbnail(sourceImage, squareTargetThumb, 240);
            ThumbLib.GenerateSpecifyThumbnail(sourceImage, targetThumbAccordingToRatio, ThumbOption.AccordingToRatio, 50);
            ThumbLib.GenerateSpecifyThumbnail(sourceImage, targetThumbAccordingToWidth, ThumbOption.AccordingToWidth, 240);
            ThumbLib.GenerateSpecifyThumbnail(sourceImage, targetThumbAccordingToHeight, ThumbOption.AccordingToHeight, 180);

            Console.WriteLine("Finish Test...");
            Console.ReadLine();
        }
    }
}
