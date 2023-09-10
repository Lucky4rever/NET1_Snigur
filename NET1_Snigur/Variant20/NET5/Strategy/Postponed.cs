namespace DOTNET.Variant20.NET5.Status
{
    class Postponed : GrantStatusStrategy
    {
        public Postponed()
        {
            this._status = StatusType.Postponed;
        }

        public override string ToString()
        {
            return "Postponed";
        }
    }
}
