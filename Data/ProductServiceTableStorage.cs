
using Azure.Data.Tables;
using Azure.Identity;

public class ProductServiceTableStorage : IProductService
{
    private readonly ILogger<ProductServiceTableStorage> logger;
    private readonly IConfiguration configuration;

    public ProductServiceTableStorage(ILogger<ProductServiceTableStorage> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
    }

    public List<Product> GetProducts()
    {
        string? cs = configuration["cs"];
        if (cs == null)
        {
            logger.LogError("Connection string is null");
            return new List<Product>();
        }
        TableClient cl = new TableClient(cs, "Products");
        // DefaultAzureCredential cred = new DefaultAzureCredential();
        // //AzureCliCredential cred = new AzureCliCredential();
        // string? tableuri = configuration["TableURI"];
        // if (tableuri == null)
        // {
        //     logger.LogError("Table URI is null");
        //     return new List<Product>();
        // }
        // TableClient cl = new TableClient(new Uri(tableuri),"Products", cred);
        Azure.Pageable<Product> r = cl.Query<Product>();
        return r.ToList();
    }
}