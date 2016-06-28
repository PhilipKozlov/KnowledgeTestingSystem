using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace MvcPL
{
    /// <summary>
    /// Provides functionality for generating Captcha images.
    /// </summary>
    public class CaptchaImage : IDisposable
    {
        #region Fields
        private string text;
        private int width;
        private int height;
        private string familyName;
        private Bitmap image;
        private Random random;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates CaptchaImage with specified parameters.
        /// </summary>
        /// <param name="s"> Captcha string.</param>
        /// <param name="width"> Image width.</param>
        /// <param name="height"> Image height.</param>
        public CaptchaImage(string s, int width, int height) : this(s, width, height, string.Empty) { }

        /// <summary>
        /// Instanciates CaptchaImage with specified parameters.
        /// </summary>
        /// <param name="s"> Captcha string.</param>
        /// <param name="width"> Image width.</param>
        /// <param name="height"> Image height.</param>
        /// <param name="fontFamily"> Font name.</param>
        public CaptchaImage(string s, int width, int height, string fontFamily)
        {
            random = new Random();
            text = s;
            SetDimensions(width, height);
            SetFamilyName(fontFamily);
            GenerateImage();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets Captcha image.
        /// </summary>
        public Bitmap Image => image;
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Generates random alphanumeric string.
        /// </summary>
        /// <param name="length"> String length.</param>
        /// <returns> Random alphanumeric string.</returns>
        public static string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Cleans up unmanaged resources.
        /// </summary>
        /// <param name="disposing"> If true - disposes of unmanaged resourses associated with this instance.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) image.Dispose();
        }
        #endregion

        #region Finalizer
        /// <summary>
        /// Releases all unmanaged resources used by this object.
        /// </summary>
        ~CaptchaImage()
        {
            Dispose(false);
        }
        #endregion

        #region Private Methods
        private void SetDimensions(int aWidth, int aHeight)
        {
            if (aWidth <= 0)
                throw new ArgumentOutOfRangeException(nameof(aWidth));
            if (aHeight <= 0)
                throw new ArgumentOutOfRangeException(nameof(aHeight));
            width = aWidth;
            height = aHeight;
        }

        private void SetFamilyName(string aFamilyName)
        {
            try
            {
                Font font = new Font(aFamilyName, 12F);
                familyName = aFamilyName;
                font.Dispose();
            }
            catch
            {
                familyName = FontFamily.GenericSerif.Name;
            }
        }

        private void GenerateImage()
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, width, height);
            var hatchBrush = new HatchBrush(RandomBrushStyle(), RandomColor(), Color.White);
            g.FillRectangle(hatchBrush, rect);
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            do
            {
                fontSize--;
                font = new Font(familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(text, font);
            } while (size.Width > rect.Width);

            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4F;
            PointF[] points =
            {
                new PointF(random.Next(rect.Width) / v, random.Next(rect.Height) / v),
                new PointF(rect.Width - random.Next(rect.Width) / v, random.Next(rect.Height) / v),
                new PointF(random.Next(rect.Width) / v, rect.Height - random.Next(rect.Height) / v),
                new PointF(rect.Width - random.Next(rect.Width) / v, rect.Height - random.Next(rect.Height) / v)
            };
            var matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
            hatchBrush = new HatchBrush(RandomBrushStyle(), RandomColor(), Color.DarkGray);
            g.FillPath(hatchBrush, path);

            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m / 50);
                int h = random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            image = bitmap;
        }

        private HatchStyle RandomBrushStyle()
        {
            var values = Enum.GetValues(typeof(HatchStyle));
            var random = new Random();
            var randomStyle = (HatchStyle)values.GetValue(random.Next(32, 44));
            return randomStyle;
        }

        private Color RandomColor()
        {
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
        #endregion
    }
}