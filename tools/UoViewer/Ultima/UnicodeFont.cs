using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ultima
{
    public sealed class UnicodeFont
    {
        private UnicodeChar[] m_chars;
        public UnicodeChar[] Chars { get { return m_chars; } set { m_chars = value; } }

        public UnicodeFont()
        {
            m_chars = new UnicodeChar[0x10000];
        }

        /// <summary>
        /// Returns width of text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetWidth(string text)
        {
            if (text == null || text.Length == 0) { return 0; }

            int width = 0;

            for (int i = 0; i < text.Length; ++i)
            {
                int c = (int)text[i] % 0x10000;
                width += m_chars[c].Width;
                width += m_chars[c].XOffset;
            }

            return width;
        }

        /// <summary>
        /// Returns max height of text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetHeight(string text)
        {
            if (text == null || text.Length == 0) { return 0; }

            int height = 0;

            for (int i = 0; i < text.Length; ++i)
            {
                int c = (int)text[i] % 0x10000;
                height = Math.Max(height, m_chars[c].Height + m_chars[c].YOffset);
            }

            return height;
        }
    }

    public sealed class UnicodeChar
    {
        private byte[] m_Bytes;
        private sbyte m_xOffset;
        private sbyte m_yOffset;
        private int m_Height;
        private int m_Width;

        public byte[] Bytes { get { return m_Bytes; } set { m_Bytes = value; } }
        public sbyte XOffset { get { return m_xOffset; } set { m_xOffset = value; } }
        public sbyte YOffset { get { return m_yOffset; } set { m_yOffset = value; } }
        public int Height { get { return m_Height; } set { m_Height = value; } }
        public int Width { get { return m_Width; } set { m_Width = value; } }

        private static Color col1 = System.Drawing.Color.FromArgb(255, 0, 0, 0);

        public UnicodeChar()
        {

        }

        /// <summary>
        /// Gets Bitmap of Char
        /// </summary>
        /// <returns></returns>
        public Bitmap GetImage()
        {
            return GetImage(false);
        }

        /// <summary>
        /// Gets Bitmap of Char with Background -1
        /// </summary>
        /// <param name="fill"></param>
        /// <returns></returns>
        public Bitmap GetImage(bool fill)
        {
            if ((m_Width == 0) || (m_Height == 0))
                return null;
            Bitmap bmp = new Bitmap(m_Width, m_Height, PixelFormat.Format32bppArgb);
            if (fill)
            {
                Graphics newgraph = Graphics.FromImage(bmp);
                newgraph.Clear(Color.FromArgb(-1));
                newgraph.Dispose();
            }
            for (int y = 0; y < m_Height; y++)
            {
                for (int x = 0; x < m_Width; x++)
                {
                    if (IsPixelSet(m_Bytes, m_Width, x, y))
                        bmp.SetPixel(x, y, col1);
                }
            }
            return bmp;
        }

        private static bool IsPixelSet(byte[] data, int width, int x, int y)
        {
            int offset = x / 8 + y * ((width + 7) / 8);
            if (offset > data.Length)
                return false;
            return (data[offset] & (1 << (7 - (x % 8)))) != 0;
        }

        /// <summary>
        /// Resets Buffer with Bitmap
        /// </summary>
        /// <param name="bmp"></param>
        public void SetBuffer(Bitmap bmp)
        {
            m_Bytes = new byte[bmp.Height * (((bmp.Width - 1) / 8) + 1)];
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color col = bmp.GetPixel(x, y);
                    if (col == col1)
                    {
                        int offset = x / 8 + y * ((bmp.Width + 7) / 8);
                        m_Bytes[offset] |= (byte)(1 << (7 - (x % 8)));
                    }
                }
            }
        }
    }

    public static class UnicodeFonts
    {
        private static string[] m_files = new string[]
        {
            "unifont.mul",
            "unifont1.mul",
            "unifont2.mul",
            "unifont3.mul",
            "unifont4.mul",
            "unifont5.mul",
            "unifont6.mul"
        };
        public static UnicodeFont[] Fonts = new UnicodeFont[7];

        static UnicodeFonts()
        {
            Initialize();
        }

        /// <summary>
        /// Reads unifont*.mul
        /// </summary>
        public static void Initialize()
        {
            Color col1 = System.Drawing.Color.FromArgb(255, 0, 0, 0);

            for (int i = 0; i < m_files.Length; i++)
            {
                Fonts[i] = new UnicodeFont();
                string filePath = Files.GetFilePath(m_files[i]);
                if (filePath == null)
                    continue;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryReader bin = new BinaryReader(fs);
                    for (int c = 0; c < 0x10000; c++)
                    {
                        Fonts[i].Chars[c] = new UnicodeChar();
                        fs.Seek((long)((c) * 4), SeekOrigin.Begin);
                        int num2 = bin.ReadInt32();
                        if ((num2 >= fs.Length) || (num2 <= 0))
                            continue;
                        fs.Seek((long)num2, SeekOrigin.Begin);
                        sbyte xOffset = bin.ReadSByte();
                        sbyte yOffset = bin.ReadSByte();
                        int Width = bin.ReadByte();
                        int Height = bin.ReadByte();
                        Fonts[i].Chars[c].XOffset = xOffset;
                        Fonts[i].Chars[c].YOffset = yOffset;
                        Fonts[i].Chars[c].Width = Width;
                        Fonts[i].Chars[c].Height = Height;
                        if (!((Width == 0) || (Height == 0)))
                            Fonts[i].Chars[c].Bytes = bin.ReadBytes(Height * (((Width - 1) / 8) + 1));
                    }
                }
            }
        }

        /// <summary>
        /// Draws Text with font in Bitmap and returns
        /// </summary>
        /// <param name="fontId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Bitmap WriteText(int fontId, string text)
        {
            Bitmap result = new Bitmap(Fonts[fontId].GetWidth(text)+2, Fonts[fontId].GetHeight(text)+2);

            int dx = 2;
            int dy = 2;
            using (Graphics graph = Graphics.FromImage(result))
            {
                for (int i = 0; i < text.Length; ++i)
                {
                    int c = (int)text[i] % 0x10000;
                    Bitmap bmp = Fonts[fontId].Chars[c].GetImage();
                    dx += Fonts[fontId].Chars[c].XOffset;
                    graph.DrawImage(bmp, dx, dy+Fonts[fontId].Chars[c].YOffset);
                    dx += bmp.Width;
                }
            }
            return result;
        }

        /// <summary>
        /// Saves Font and returns string Filename
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public static string Save(string path, int filetype)
        {
            string FileName = Path.Combine(path, m_files[filetype]);
            using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                BinaryWriter bin = new BinaryWriter(fs);
                fs.Seek(0x10000 * 4, SeekOrigin.Begin);
                bin.Write(0); // Set first data
                for (int c = 0; c < 0x10000; c++)
                {
                    if (Fonts[filetype].Chars[c].Bytes == null)
                        continue;
                    fs.Seek((long)((c) * 4), SeekOrigin.Begin);
                    bin.Write((int)fs.Length);
                    fs.Seek(fs.Length, SeekOrigin.Begin);
                    bin.Write(Fonts[filetype].Chars[c].XOffset);
                    bin.Write(Fonts[filetype].Chars[c].YOffset);
                    bin.Write((byte)Fonts[filetype].Chars[c].Width);
                    bin.Write((byte)Fonts[filetype].Chars[c].Height);
                    bin.Write(Fonts[filetype].Chars[c].Bytes);
                }
            }
            return FileName;
        }
    }
}
