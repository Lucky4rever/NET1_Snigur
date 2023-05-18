using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3.Shape
{
    class Cycle : IShape
    {
        private readonly int _radius;

        public Cycle(int radius)
        {
            this._radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * this._radius * this._radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * this._radius;
        }

        public override string ToString()
        {
            return $"This is cycle with radius {this._radius}";
        }
    }
}
