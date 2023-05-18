namespace DOTNET.Variant20.NET1
{
    public class ClientCovenant
    {
        public int ClientId { get; set; }
        public int CovenantId { get; set; }

        public ClientCovenant(int clientId, int covenantId)
        {
            this.ClientId = clientId;
            this.CovenantId = covenantId;
        }
    }
}
