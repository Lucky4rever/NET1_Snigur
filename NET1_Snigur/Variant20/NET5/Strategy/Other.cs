namespace DOTNET.Variant20.NET5.Status
{
    class Other : GrantStatusStrategy
    {
        public Other()
        {
            this._status = StatusType.Other;
        }

        public override string ToString()
        {
            return "Other";
        }
    }
}
