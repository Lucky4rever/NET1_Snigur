using DOTNET.Variant20.NET3.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3.AbstractFactory
{
    class ShapeFactory : INewRectangle, INewCycle, INewTriangle
    {
        private static ShapeFactory instance;
        public static ShapeFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ShapeFactory();
            }
            return instance;
        }

        public Rectangle CreateRectangle(int width, int height)
        {
            return new Rectangle(width, height);
        }

        public Cycle CreateCycle(int radius)
        {
            return new Cycle(radius);
        }

        public Triangle CreateTriangle(int side1, int side2, int side3)
        {
            return new Triangle(side1, side2, side3);
        }
    }
}
