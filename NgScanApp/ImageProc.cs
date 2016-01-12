using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NgScanApp
{
    class ImageProc
    {
        public static BitmapSource ImgToBmpSource(System.Drawing.Image imageData)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageData.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bI = new BitmapImage();
                bI.BeginInit();
                bI.CacheOption = BitmapCacheOption.OnLoad;
                bI.StreamSource = ms;
                bI.EndInit();
                return bI;
            }
        }
        public static Bitmap ImgToBmp(System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Bmp);
                Bitmap bi = new Bitmap(ms);
                return bi;
            }
        }

        public static BitmapSource BmpToBmpSource(Bitmap bmp)
        {
            var bitmapData = bmp.LockBits(
        new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height, 50, 50, PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bmp.UnlockBits(bitmapData);
            return bitmapSource;
        }

        public static BitmapSource setPixelFormat(BitmapSource image, System.Windows.Media.PixelFormat format)
        {
            var formatted = new FormatConvertedBitmap();

            formatted.BeginInit();
            formatted.Source = image;
            formatted.DestinationFormat = format;
            formatted.EndInit();
            return formatted;
        }
    }
}
