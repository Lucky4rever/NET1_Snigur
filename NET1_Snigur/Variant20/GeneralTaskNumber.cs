using System.Collections.Generic;

namespace DOTNET.Variant20
{
    public class GeneralTaskNumber
    {
        protected static readonly GeneralTaskNumber Empty = new GeneralTaskNumber(0);
        public override string ToString()
        {
            return $"Task {Value}";
        }

        protected GeneralTaskNumber(int value)
        {
            this.Value = value;
        }

        public int Value { get; private set; }

        public static GeneralTaskNumber GetGeneralTaskNumber(int key)
        {
            return Empty;
        }
    }
}
