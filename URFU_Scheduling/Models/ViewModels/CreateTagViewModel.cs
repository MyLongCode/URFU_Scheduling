using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace URFU_Scheduling.Models.ViewModels
{
    public class CreateTagViewModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public string ColorHex
        {
            get => $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
            set
            {
                if (!string.IsNullOrEmpty(value) && value.StartsWith("#"))
                {
                    var color = System.Drawing.ColorTranslator.FromHtml(value);
                    Color = Color.FromArgb(color.R, color.G, color.B);
                }
            }
        }
    }
}
