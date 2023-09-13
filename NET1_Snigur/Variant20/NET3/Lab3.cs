using DOTNET.Variant20.NET3;
using DOTNET.Variant20.NET3.AbstractFactory;
using DOTNET.Variant20.NET3.Shape;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var20_Lab3()
        {
            Console.WriteLine("Variant 20\nVariant 1\n");

            ShapeFactory factory = ShapeFactory.GetInstance();

            Cycle cycle1 = factory.CreateCycle(1);
            Cycle cycle2 = factory.CreateCycle(8);
            Rectangle rectangle = factory.CreateRectangle(8, 19);
            Triangle triangle = factory.CreateTriangle(3, 4, 5);

            PolygonBuilder builder = new PolygonBuilder();

            builder.AddCycle(cycle1);
            builder.AddCycle(cycle2);
            builder.AddRectangle(rectangle);
            builder.AddTriangle(triangle);

            Polygon shape = builder.Build();

            shape.PrintInfo();
            shape.PrintAllAreas();
            shape.PrintAllPerimeters();
        }
    }
}
