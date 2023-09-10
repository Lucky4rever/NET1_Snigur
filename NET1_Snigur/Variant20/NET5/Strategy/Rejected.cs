namespace DOTNET.Variant20.NET5.Status
{
    class Rejected : GrantStatusStrategy
    {
        public Rejected()
        {
            this._status = StatusType.Rejected;
        }

        public override string ToString()
        {
            return "Rejected";
        }
    }
}
