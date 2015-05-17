using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThumbnail
{
    /// <summary>
    /// Option to generate thumbnail
    /// </summary>
    public enum ThumbOption
    {
        AccordingToRatio = 0,
        AccordingToWidth,
        AccordingToHeight
    }

    /// <summary>
    /// APIs for image thumbnail library
    /// </summary>
    public class ThumbLib
    {
        /// <summary>
        /// Generate Sepecify thumbnail according to different options
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <param name="option"></param>
        /// <param name="value"></param>
        public static void GenerateSpecifyThumbnail(string sourcePath, string targetPath, ThumbOption option, int value)
        {
            using (Image sourceImage = Image.FromFile(sourcePath))
            {
                int newWidth = 0;
                int newHeight = 0;

                switch (option)
                {
                    case ThumbOption.AccordingToRatio:
                        newWidth = sourceImage.Width * value / 100;
                        newHeight = sourceImage.Height * value / 100;
                        break;
                    case ThumbOption.AccordingToWidth:
                        newWidth = value;
                        newHeight = newWidth * sourceImage.Height / sourceImage.Width;
                        break;
                    case ThumbOption.AccordingToHeight:
                        newHeight = value;
                        newWidth = newHeight * sourceImage.Width / sourceImage.Height;
                        break;
                    default:
                        break;
                }

                // construct Bitmap object for drawing
                Bitmap partImage = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(partImage);

                // original rect and destination rect
                Rectangle origRect = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                Rectangle destRect = new Rectangle(0, 0, newWidth, newHeight);

                // draw from orig to dest rect
                graphics.DrawImage(sourceImage, destRect, origRect, GraphicsUnit.Pixel);

                // save to target using Jpeg format
                partImage.Save(targetPath, ImageFormat.Jpeg);

                // Dispose Bitmap
                partImage.Dispose();
            } // end using
        }

        /// <summary>
        /// Generate Square Thumbnail for a given image
        /// if width > height, then use height as squareWidth
        /// if width < height, then use width as squareWidth
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <param name="squareWidth"></param>
        public static void GenerateSquareThumbnail(string sourcePath, string targetPath, int squareWidth)
        {
            using (Image sourceImage = Image.FromFile(sourcePath))
            {
                int newWidth = squareWidth;
                int newHeight = squareWidth;

                // construct Bitmap object for drawing
                Bitmap partImage = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(partImage);

                // original rect and destination rect
                Rectangle origRect;
                Rectangle destRect;

                if (sourceImage.Height <= sourceImage.Width)
                {
                    int cutWidth = sourceImage.Height;
                    int cutHeight = cutWidth;

                    int cutStartX = (sourceImage.Width - cutWidth) / 2;
                    int cutStartY = 0;

                    origRect = new Rectangle(cutStartX, cutStartY, cutWidth, cutHeight);
                    destRect = new Rectangle(0, 0, newWidth, newHeight);
                }
                else
                {
                    int cutWidth = sourceImage.Width;
                    int cutHeight = cutWidth;

                    int cutStartX = 0;
                    int cutStartY = (sourceImage.Height - cutHeight) / 2; ;

                    origRect = new Rectangle(cutStartX, cutStartY, cutWidth, cutHeight);
                    destRect = new Rectangle(0, 0, newWidth, newHeight);
                }

                // draw from orig to dest rect
                graphics.DrawImage(sourceImage, destRect, origRect, GraphicsUnit.Pixel);

                // save to target using Jpeg format
                partImage.Save(targetPath, ImageFormat.Jpeg);

                // Dispose Bitmap
                partImage.Dispose();
            } // end using
        }
    }
}
