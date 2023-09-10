using DOTNET.Variant20.NET5.Status;

namespace DOTNET.Variant20.NET5
{
    class GrantStatus
    {
        private GrantStatusStrategy Strategy { get; set; }

        public GrantStatus(GrantStatusStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public void ChangeStatus(GrantStatusStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public string GetStatus()
        {
            return this.Strategy.ToString();
        }
    }
}
