namespace ListaTelefonica.APIAna.Infrastructure
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ContatosCollectionName { get; set; } = null!;
    }
}
