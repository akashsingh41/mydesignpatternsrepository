using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        public class AdvancedSettings
        {
            public int Saturation { get; set; }
        }
        public class Color : ICloneable
        {
            public int _red { get; set; }
            public int _blue { get; set; }
            public int _green { get; set; }

            public AdvancedSettings color_saturation = new AdvancedSettings();
            public AdvancedSettings advanced_settings
            {
                get
                {
                    return this.color_saturation;
                }
                set
                {
                    this.color_saturation = value;
                }
            }

            public object ShallowCopy()
            {
                return this.MemberwiseClone();
            }
            public object DeepCopy()
            {
                Color new_color = new Color();
                new_color._red = this._red;
                new_color._red = this._red;
                new_color._red = this._red;
                new_color.color_saturation.Saturation = this.color_saturation.Saturation;
                return new_color;

            }
            public object Clone()
            {
                return DeepCopy();
            }
        }
        static void Main(string[] args)
        {
            Color c1 = new Color();
            c1._red = 10;
            c1._blue = 0;
            c1._green = 0;
            c1.color_saturation.Saturation = 50;

            Color c2 = (Color)c1.Clone();
            Color c3 = (Color)c1.ShallowCopy();

            Console.WriteLine(String.Format("Color C1: {0},{1},{2}, Saturation: {3}", c1._red, c1._blue, c1._green, c1.color_saturation.Saturation));
            Console.WriteLine(String.Format("Color C2: {0},{1},{2}, Saturation: {3}", c2._red, c2._blue, c2._green, c2.color_saturation.Saturation));
            Console.WriteLine(String.Format("Color C3: {0},{1},{2}, Saturation: {3}", c3._red, c3._blue, c3._green, c3.color_saturation.Saturation));

            c3._green = 10;
            c3.color_saturation.Saturation = 12;

            Console.WriteLine(String.Format("Color C1: {0},{1},{2}, Saturation: {3}", c1._red, c1._blue, c1._green, c1.color_saturation.Saturation));
            Console.WriteLine(String.Format("Color C2: {0},{1},{2}, Saturation: {3}", c2._red, c2._blue, c2._green, c2.color_saturation.Saturation));
            Console.WriteLine(String.Format("Color C3: {0},{1},{2}, Saturation: {3}", c3._red, c3._blue, c3._green, c3.color_saturation.Saturation));


            Console.ReadLine();


        }
    }
}
