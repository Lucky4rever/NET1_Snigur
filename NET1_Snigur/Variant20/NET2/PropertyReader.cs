//using DOTNET.Variant20.NET1;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace DOTNET.Variant20.NET2
//{
    //struct Variable
    //{
    //    public string name;
    //    public Type type;
    //    public object value;
    //}
//    class PropertyReader
//    {
//        public static Variable[] getProperties<T>(T variable)
//        {
//            Type type = variable.GetType();
//            var propertyValues = type.GetProperties();
//            var result = new List<Variable>();

//            for (int i = 0; i < propertyValues.Length; i++)
//            {
//                var y = variable.GetType().GetFields();
//                var x = variable.GetType().GetField(propertyValues[i].Name);
//                var propertyType = x.FieldType;
//                if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(decimal) || propertyType == typeof(DateTime) || propertyType.IsEnum)
//                {
//                    Variable thisVariable = new Variable
//                    {
//                        name = propertyValues[i].Name,
//                        type = propertyType,
//                        value = type.GetProperty(propertyValues[i].Name).GetValue(variable, null).ToString()
//                    };
//                    result.Add(thisVariable);
//                }
//            }

//            return result.ToArray();
//        }
//    }
//}
