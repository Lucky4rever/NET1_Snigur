namespace DOTNET.Variant20.NET5.Status
{
    class Created : GrantStatusStrategy
    {
        public Created()
        {
            this._status = StatusType.Created;
        }

        public override string ToString()
        {
            return "Created";
        }
    }
}
