using DOTNET.Variant20.NET3.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3
{
    class PolygonBuilder
    {
        private readonly List<IShape> _shapes;

        public PolygonBuilder()
        {
            this._shapes = new List<IShape>();
        }

        public void AddShape(IShape shape)
        {
            this._shapes.Add(shape);
        }

        public void AddTriangle(Triangle triangle)
        {
            this._shapes.Add(triangle);
        }

        public void AddRectangle(Rectangle rectangle)
        {
            this._shapes.Add(rectangle);
        }

        public void AddCycle(Cycle cycle)
        {
            this._shapes.Add(cycle);
        }

        public Polygon Build()
        {
            return new Polygon(_shapes);
        }
    }
}
