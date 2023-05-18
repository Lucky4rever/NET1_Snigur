using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3.Shape
{
    class Triangle : IShape
    {
        internal readonly int side1;
        internal readonly int side2;
        internal readonly int side3;

        public Triangle(int side1, int side2, int side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - this.side1) * (p - this.side2) * (p - this.side3));
        }

        public double GetPerimeter()
        {
            return this.side1 + this.side2 + this.side3;
        }

        public override string ToString()
        {
            return $"This is triangle with lengths of the sides {this.side1}, {this.side2} and {this.side3}";
        }
    }
}
