using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sedisy_app.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProductService productService;

    public List<Product> data { get; set; } = new();
    public IndexModel(ILogger<IndexModel> logger, IProductService productService)
    {
        _logger = logger;
        this.productService = productService;
    }

    public void OnGet()
    {
        data = productService.GetProducts();
    }
}
