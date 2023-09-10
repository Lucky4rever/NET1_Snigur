namespace DOTNET.Variant20.NET5.Status
{
    class Considered : GrantStatusStrategy
    {
        public Considered()
        {
            this._status = StatusType.Considered;
        }

        public override string ToString()
        {
            return "Considered";
        }
    }
}
