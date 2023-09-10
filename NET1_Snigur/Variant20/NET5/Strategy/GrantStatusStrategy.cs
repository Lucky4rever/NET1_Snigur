namespace DOTNET.Variant20.NET5.Status
{
    abstract class GrantStatusStrategy
    {
        protected StatusType _status;

        public virtual StatusType GetStatus()
        {
            return this._status;
        }

        public override string ToString()
        {
            return "none";
        }
    }
}
