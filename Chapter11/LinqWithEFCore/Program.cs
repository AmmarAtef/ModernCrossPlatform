using LinqWithEFCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static System.Console;



static void FilterAndSort()
{
    using (Northwind db = new Northwind())
    {
        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts = allProducts.Where(p => p.UnitPrice < 10M);

        IOrderedQueryable<Product> sortedAndFilteredProducts =
            filteredProducts.OrderByDescending(p => p.UnitPrice);

        WriteLine("Products that cost less than $10:");


        var projectedProducts = sortedAndFilteredProducts.
            Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.UnitPrice
            });

        foreach (var p in projectedProducts)
        {
            WriteLine($"{p.ProductId}: {p.ProductName} costs {p.UnitPrice:$#,##0.00}");
        }
        WriteLine();
    }
}

static void JoinCategoriesAndProducts()
{
    using (Northwind db = new Northwind())
    {
        var queryJoin = db.Categories.Join(
            inner: db.Products,
            outerKeySelector: c => c.CategoryId,
            innerKeySelector: p => p.CategoryId,
            resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId }
            ).OrderBy(cp => cp.CategoryName);

        foreach (var c in queryJoin)
        {
            WriteLine($"{c.ProductId}: {c.ProductName} is in {c.CategoryName}");
        }
    }
}

static void GroupjoinCategoriesAndProducts()
{
    using (Northwind db = new Northwind())
    {
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(
            inner: db.Products,
            outerKeySelector: c => c.CategoryId,
            innerKeySelector: p => p.CategoryId,
            resultSelector: (c, matchingProducts) => new { c.CategoryName, Products = matchingProducts.OrderBy(p => p.ProductName) }
            );

        foreach (var c in queryGroup)
        {
            WriteLine($"......................");
            WriteLine($"{c.CategoryName} has {c.Products.Count()} products:");
            foreach (var product in c.Products)
            {
                WriteLine($"{product.ProductName}");
            }
        }

    }

}

//GroupjoinCategoriesAndProducts();

static void AggregateProducts()
{
    using (Northwind db = new Northwind())
    {
        WriteLine($"product Count : {db.Products.Count()}");

        WriteLine($"Highest product price: {db.Products.Max(c => c.UnitPrice)}");

        WriteLine($"Sum of units in stocks : {db.Products.Sum(c => c.UnitsInStock)}");

        WriteLine($"Sum of units on order: {db.Products.Sum(p => p.UnitsOnOrder)}");

        WriteLine($"Average unit prices: {db.Products.Average(c => c.UnitPrice)}");
        WriteLine($"Value of units in stocks: {db.Products.Sum(p => p.UnitPrice * p.UnitsInStock)}");


    }
}
//AggregateProducts();

string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin" };

var query = names.Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);


var query2 = from name in names
             where name.Length > 4
             orderby name.Length, name
             select name;

//UseExtensionMethod();
static void UseExtensionMethod()
{
    using (Northwind db = new Northwind())
    {
        DbSet<Product>? allProducts = db.Products;
        IQueryable<Product> products = allProducts.ProcessSequence();

        IQueryable<Product> filteredProducts = products.Where(c => c.UnitPrice < 10M);


        WriteLine($"Mean units in stock: {db.Products.Average(c => c.UnitsInStock)}");
        WriteLine($"Mean unit price: {db.Products.Average(c => c.UnitPrice)}");
        WriteLine($"Median units in stock: {db.Products.Median(c => c.UnitsInStock)}");
        WriteLine($"Median unit price: {db.Products.Median(c => c.UnitPrice)}");
        WriteLine($"Mode units in stock: {db.Products.Mode(c => c.UnitsInStock)}");
        WriteLine($"Mode unit price: {db.Products.Mode(c => c.UnitPrice)}");
    }
}


static void OutputProductsAsXml()
{
    using (Northwind db = new Northwind())
    {
        Product[] productsArray = db.Products.ToArray();
        XElement xElement = new XElement("products",
            from p in productsArray
            select new XElement("product",
              new XAttribute("id", p.ProductId),
              new XAttribute("price", p.UnitPrice),
              new XElement("name", p.ProductName)
            ));

        WriteLine(xElement.ToString());


    }
}

//OutputProductsAsXml();

static void ProcessSettings()
{
    XDocument doc = XDocument.Load("settings.xml");
    var appSettings = doc.Descendants("appSettings")
                         .Descendants("add")
                         .Select(node => new
                         {
                             key = node.Attribute("key")?.Value,
                             value = node.Attribute("value")?.Value
                         }).ToArray();

    foreach(var item in appSettings)
    {
        WriteLine($"{item.key}: {item.value}");
    }
}

ProcessSettings();