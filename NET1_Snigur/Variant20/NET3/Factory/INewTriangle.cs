using DOTNET.Variant20.NET3.Shape;

namespace DOTNET.Variant20.NET3.AbstractFactory
{
    interface INewTriangle
    {
        Triangle CreateTriangle(int side1, int side2, int side3);
    }
}
