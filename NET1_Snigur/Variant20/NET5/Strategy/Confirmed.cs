namespace DOTNET.Variant20.NET5.Status
{
    class Confirmed : GrantStatusStrategy
    {
        public Confirmed()
        {
            this._status = StatusType.Confirmed;
        }

        public override string ToString()
        {
            return "Confirmed";
        }
    }
}
