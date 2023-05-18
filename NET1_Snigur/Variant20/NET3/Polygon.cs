using DOTNET.Variant20.NET3.Shape;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DOTNET.Variant20.NET3
{
    partial class Polygon
    {
        private List<IShape> Shapes { get; } = new List<IShape>();

        public int Copacity
        {
            get
            {
                return Shapes.Count;
            }
        }

        public Polygon(List<IShape> shapes)
        {
            Shapes.AddRange(shapes);
        }
        //rewrite as a builder
        public void AddShape(IShape shape)
        {
            Shapes.Add(shape);
        }
    }
}
