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
            client = NET1.clients[clientId];
            return this;
        }
        internal ClientCovenant AddCovenant(int covenantId)
        {
            this.covenantId = covenantId;
            covenant = NET1.covenants[covenantId];
            return this;
        }
    }
}
