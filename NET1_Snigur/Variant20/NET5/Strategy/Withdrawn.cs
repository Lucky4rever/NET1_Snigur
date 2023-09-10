namespace DOTNET.Variant20.NET5.Status
{
    class Withdrawn : GrantStatusStrategy
    {
        public Withdrawn()
        {
            this._status = StatusType.Withdrawn;
        }

        public override string ToString()
        {
            return "Withdrawn";
        }
    }
}
