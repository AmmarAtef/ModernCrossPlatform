using Northwind.Common.Models;

namespace Northwind.Mvc.Models
{
    public record HomeIndexViewModel
    (
        int visitorCount,
        IList<Category> Categories,
        IList<Product> Products
    );
}
