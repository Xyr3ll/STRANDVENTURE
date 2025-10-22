using System.Drawing;
using System.Drawing.Imaging;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services
{
    public interface ICaptchaService
    {
        CaptchaModel GenerateCaptcha();
        bool ValidateCaptcha(string userInput, string sessionCaptcha);
    }

    public class CaptchaService : ICaptchaService
    {
        private readonly Random _random = new Random();
        private const string CaptchaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public CaptchaModel GenerateCaptcha()
        {
            string captchaText = GenerateRandomString(5);
            string imageBase64 = GenerateImageBase64(captchaText);

            return new CaptchaModel
            {
                CaptchaText = captchaText,
                CaptchaImageBase64 = imageBase64
            };
        }

        public bool ValidateCaptcha(string userInput, string sessionCaptcha)
        {
            return !string.IsNullOrEmpty(userInput) && 
                   !string.IsNullOrEmpty(sessionCaptcha) &&
                   userInput.Equals(sessionCaptcha, StringComparison.OrdinalIgnoreCase);
        }

        private string GenerateRandomString(int length)
        {
            // Production code would use:
            return new string(Enumerable.Repeat(CaptchaChars, length)
                 .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private string GenerateImageBase64(string text)
        {
            // Always use SVG fallback for cross-platform compatibility
            return GenerateSimpleCaptchaBase64(text);
            
            /* Original implementation with System.Drawing (Windows only)
            try
            {
                int width = 120;
                int height = 40;

                using var bitmap = new Bitmap(width, height);
                using var graphics = Graphics.FromImage(bitmap);

                // Background
                graphics.Clear(Color.LightGray);

                // Text
                using var font = new Font("Arial", 16, FontStyle.Bold);
                using var brush = new SolidBrush(Color.Black);
                
                // Add some noise
                for (int i = 0; i < 50; i++)
                {
                    int x = _random.Next(width);
                    int y = _random.Next(height);
                    graphics.FillRectangle(new SolidBrush(GetRandomColor()), x, y, 2, 2);
                }

                // Draw text with slight random positioning
                float x_pos = 10;
                for (int i = 0; i < text.Length; i++)
                {
                    float y_pos = 8 + _random.Next(-3, 4);
                    graphics.DrawString(text[i].ToString(), font, brush, x_pos, y_pos);
                    x_pos += 18;
                }

                // Add some lines
                for (int i = 0; i < 3; i++)
                {
                    using var pen = new Pen(GetRandomColor(), 1);
                    graphics.DrawLine(pen, _random.Next(width), _random.Next(height),
                                    _random.Next(width), _random.Next(height));
                }

                using var stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
            catch
            {
                // Fallback for environments without GDI+ support
                return GenerateSimpleCaptchaBase64(text);
            }
            */
        }

        private string GenerateSimpleCaptchaBase64(string text)
        {
            // Simple SVG-based captcha
            string svg = $@"<svg width='120' height='40' xmlns='http://www.w3.org/2000/svg'>
                <rect width='120' height='40' fill='#f0f0f0' stroke='#ccc' stroke-width='2'/>
                <text x='20' y='25' font-family='Arial, sans-serif' font-size='18' font-weight='bold' fill='#333'>{text}</text>
                <circle cx='15' cy='15' r='2' fill='#999'/>
                <circle cx='105' cy='25' r='2' fill='#999'/>
                <line x1='5' y1='30' x2='25' y2='10' stroke='#999' stroke-width='1'/>
                <line x1='95' y1='10' x2='115' y2='30' stroke='#999' stroke-width='1'/>
            </svg>";
            
            byte[] svgBytes = System.Text.Encoding.UTF8.GetBytes(svg);
            return Convert.ToBase64String(svgBytes);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(100, 200), _random.Next(100, 200), _random.Next(100, 200));
        }
    }
}