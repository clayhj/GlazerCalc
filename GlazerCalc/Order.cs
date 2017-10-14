using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazerCalc
{
    class Order
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public string Tint { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public double WoodLength()
        {

            return 2 * (Width + Height) * 3.25;
        }

        public double GlassArea()
        {
            return 2 * (Width * Height);
        }

    }
}
