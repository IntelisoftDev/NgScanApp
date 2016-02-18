using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NgScanApp
{
    class ImageProc
    {
        public static Bitmap BitmapTo1Bpp(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            byte[] scan = new byte[(w + 7) / 8];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (x % 8 == 0) scan[x / 8] = 0;
                    System.Drawing.Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                Marshal.Copy(scan, 0, (IntPtr)((long)data.Scan0 + data.Stride * y), scan.Length);
            }
            bmp.UnlockBits(data);
            return bmp;
        }

        public static System.Drawing.Bitmap setPixelFormat2(BitmapSource bitmapsource, System.Drawing.Imaging.PixelFormat format)
        {
            //convert image format
            var src = new System.Windows.Media.Imaging.FormatConvertedBitmap();
            src.BeginInit();
            src.Source = bitmapsource;
            if (format == System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
            {
                src.DestinationFormat = System.Windows.Media.PixelFormats.BlackWhite;
            }
            if (format == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                src.DestinationFormat = System.Windows.Media.PixelFormats.Gray8;
            }
            if (format == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                src.DestinationFormat = System.Windows.Media.PixelFormats.Bgr24;
            }
            if (format == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                src.DestinationFormat = System.Windows.Media.PixelFormats.Bgra32;
            }
            src.EndInit();

            //copy to bitmap
            Bitmap bitmap = new Bitmap(src.PixelWidth, src.PixelHeight, format);
            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, format);
            src.CopyPixels(System.Windows.Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bitmap.UnlockBits(data);

            return bitmap;
        }
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

        public static BitmapSource setPixelFormat1(BitmapSource image, System.Windows.Media.PixelFormat format)
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
