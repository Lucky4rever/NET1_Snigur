using DOTNET.Variant20.NET3.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3
{
    partial class Polygon : CustomShape
    {
        public override void PrintAllAreas()
        {
            base.PrintAllAreas();

            foreach (var shape in Shapes)
            {
                if (shape != null)
                {
                    Console.WriteLine(shape?.GetArea());
                }
            }

            Console.WriteLine();
        }

        public override void PrintAllPerimeters()
        {
            base.PrintAllPerimeters();

            foreach (var shape in Shapes)
            {
                if (shape != null)
                {
                    Console.WriteLine(shape?.GetPerimeter());
                }
            }

            Console.WriteLine();
        }

        public override void PrintInfo()
        {
            base.PrintInfo();

            foreach (var shape in Shapes)
            {
                if (shape != null)
                {
                    Console.WriteLine(shape?.ToString());
                }
            }

            Console.WriteLine();
        }
    }
}
