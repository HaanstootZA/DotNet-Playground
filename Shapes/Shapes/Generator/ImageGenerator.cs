using System.Drawing;
using System.Drawing.Imaging;

namespace Shapes
{
    public static class ImageGenerator
    {
        public static Bitmap GenerateImageForCircle(int width, int height, Shape circle)
        {
            Bitmap bmp = new Bitmap(width, height);
            double midx = width / 2;
            double midy = height / 2;
            Vector<Coordinate> Circle = circle.GetItems;
            for (int i = 0; i < circle.Size; i++)
            {
                Coordinate currCoor = Circle.Items[i];
                double x = currCoor.Items[0] + midx;
                double y = currCoor.Items[1] + midy;
                if (x < width && x > 0 && y < height && y > 0)
                    bmp.SetPixel((int)(x), (int)(y), Color.Black);
            }
            return bmp;
        }
        
        public static Bitmap GenerateImageForCircleOnScreen(int width, int height, Shape circle)
        {
            Bitmap bmp = new Bitmap(width, height);
            Vector<Coordinate> Circle = circle.GetItems;
            for (int i = 0; i < circle.Size; i++)
            {
                Coordinate currCoor = Circle.Items[i];
                if (currCoor.Items[0] < width && currCoor.Items[0] >= 0 && currCoor.Items[1] < height && currCoor.Items[1] >= 0)
                    bmp.SetPixel((int)(currCoor.Items[0]), (int)(currCoor.Items[1]), Color.Black);
            }
            return bmp;
        }

        public static void GenerateImageForCircleToFile(int width, int height, Shape circle, string fileLocation)
        {
            Bitmap bmp = new Bitmap(width, height);
            double midx = width / 2;
            double midy = height / 2;
            Vector<Coordinate> Circle = circle.GetItems;
            for (int i = 0; i < Circle.Size; i++)
            {
                Coordinate currCoor = Circle.Items[i];
                bmp.SetPixel((int)(currCoor.Items[0] + midx), (int)(currCoor.Items[1] + midy), Color.Black);
            }
            bmp.Save(fileLocation, ImageFormat.Bmp);
        }
    }
}