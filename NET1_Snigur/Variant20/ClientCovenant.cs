namespace NET1_Snigur.Variant20
{
    class ClientCovenant
    {
        public int clientId { get; set; }
        public Client client { get; set; }

        public int covenantId { get; set; }
        public Covenant covenant { get; set; }

        internal ClientCovenant AddClient(int clientId)
        {
            this.clientId = clientId;
            client = TestData.clients[clientId];
            return this;
        }
        internal ClientCovenant AddCovenant(int covenantId)
        {
            this.covenantId = covenantId;
            covenant = TestData.covenants[covenantId];
            return this;
        }
    }
}
