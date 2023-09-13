namespace DOTNET
{
    partial class Labs
    {
        private static Labs _instance;

        private Labs() { }

        public static Labs GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Labs();
            }

            return _instance;
        }
    }
}
