using DOTNET.Variant20.NET5.Status;

namespace DOTNET.Variant20.NET5
{
    class StatusManager
    {
        public GrantStatusStrategy Created()
        {
            return new Created();
        }
        public GrantStatusStrategy Considered()
        {
            return new Considered();
        }
        public GrantStatusStrategy Postponed()
        {
            return new Postponed();
        }
        public GrantStatusStrategy Rejected()
        {
            return new Rejected();
        }
        public GrantStatusStrategy Confirmed()
        {
            return new Confirmed();
        }
        public GrantStatusStrategy Withdrawn()
        {
            return new Withdrawn();
        }
        public GrantStatusStrategy Other()
        {
            return new Other();
        }
    }
}
