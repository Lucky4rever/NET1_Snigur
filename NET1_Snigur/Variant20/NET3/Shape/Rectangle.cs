using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3.Shape
{
    class Rectangle : IShape
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(int width, int height)
        {
            this._width = width;
            this._height = height;
        }

        public double GetArea()
        {
            return this._width * this._height;
        }

        public double GetPerimeter()
        {
            return 2 * (this._width + this._height);
        }

        public override string ToString()
        {
            return $"This is rectangle with width {this._width} and height {this._height}";
        }
    }
}
