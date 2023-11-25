using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stokageapp
{
    public static class Themecolor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }    
        public static List<string> ColorList = new List<string>(){"#3F51B5",
                                                                "#009688",
                                                                "#FF5722",
                                                                "#607D8B",
                                                                "#FF9800",
                                                                "#9C27B0",
                                                                "#2196F3",
                                                                "#E91E63",
                                                                "#00BCD4",
                                                                "#4CAF50",
                                                                "#FFEB3B",
                                                                "#795548",
                                                                "#CDDC39",
                                                                "#FFC107",
                                                                "#03A9F4",
                                                                "#8BC34A",
                                                                "#FF9800",
                                                                "#9E9E9E",
                                                                "#673AB7",
                                                                "#F44336",
                                                                "#00BCD4",
                                                                "#4CAF50",
                                                                "#FFEB3B",
                                                                "#795548",
                                                                "#CDDC39",
                                                                "#FFC107",
                                                                "#03A9F4",
                                                                "#8BC34A",
                                                                "#FF9800",
                                                                "#9E9E9E",
                                                                "#673AB7",
                                                                "#F44336",
                                                                "#00BCD4",
                                                                "#4CAF50",
                                                                "#FFEB3B",
                                                                "#795548",
                                                                "#CDDC39",
                                                                "#FFC107",
                                                                "#03A9F4",
                                                                "#8BC34A",
                                                                "#FF9800",
                                                                "#9E9E9E",
                                                                "#673AB7",
                                                                "#F44336",
                                                                "#00BCD4",
                                                                "#4CAF50",
                                                                "#FFEB3B",
                                                                "#795548",
                                                                "#CDDC39",
                                                                "#FFC107",
                                                                "#03A9F4",
                                                                "#8BC34A",
                                                                "#FF9800",
                                                                "#9E9E9E"};
        
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = (double)color.R;
            double green = (double)color.G;
            double blue = (double)color.B;
            
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            
            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }       
    }
}
