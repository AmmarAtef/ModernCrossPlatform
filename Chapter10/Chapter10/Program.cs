using WorkingWithEFCore;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.AutoGen;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

WriteLine($"Using {ProjectConstants.DataBaseProvider} database provider.");

static void QueryingCategories()
{
    using (Northwind db = new Northwind())
    {
        WriteLine("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);

        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }


        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }







    }


}

static void FilteredData()
{
    WriteLine($"Enter a minimum for units in stocks");
    string unitsInStock = ReadLine() ?? "10";
    short stock = short.Parse(unitsInStock);
    using (Northwind db = new Northwind())
    {
        IQueryable<Category>? filteredCategories = db.Categories?.Include(c => c.Products.Where(n => n.UnitsInStock >= stock));

        if (filteredCategories is null)
        {
            WriteLine("No categories found.");
            return;
        }


        foreach (Category c in filteredCategories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
            foreach (Product p in c.Products)
            {
                WriteLine($"{p.ProductName} has {p.UnitsInStock} units in stock");
            }
        }
    }
}


static void QueryingProducts()
{

    using (Northwind db = new Northwind())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        WriteLine("Products that cost more than a price, highest at top.");
        string? input;
        decimal price;

        do
        {
            WriteLine($"Enter Product Price");
            input = ReadLine();

        } while (!decimal.TryParse(input, out price));


        IQueryable<Product>? products = db.Products?
            .Where(p => p.UnitPrice > price)
            .OrderByDescending(x => x.UnitPrice);

        if (products is null)
        {
            WriteLine("No products found.");
            return;
        }

        foreach (Product p in products)
        {
            WriteLine($"{p.ProductId}: {p.ProductName} costs {p.UnitPrice: $#,##0.00} and has {p.UnitsInStock} in stock.");
        }


    }
}





static void QueryingWithLike()
{
    using (Northwind db = new Northwind())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        Write("Enter part of the product name: ");
        string? input = ReadLine();

        IQueryable<Product>? products = db.Products?.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

        if (products is null)
        {
            WriteLine("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            WriteLine($"{product.ProductName} has {product.UnitsInStock} units in stock. Discontinued? {product.Discontinued}");
        }
    }
}



static bool AddProduct(int categoryId, string productName, decimal? price)
{
    using (Northwind db = new Northwind())
    {
        Product product = new Product()
        {
            CategoryId = categoryId,
            ProductName = productName,
            UnitPrice = price
        };


        // mark product as added in change tracking
        db.Products.Add(product);

        // save tracked change to database
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static void ListProducts()
{
    using (Northwind db = new Northwind())
    {
        WriteLine($"Id - Product Name - Cost - Stock - Disc");

        foreach (Product product in db.Products.OrderByDescending(c => c.UnitPrice))
        {
            WriteLine($"{product.ProductId:000} - {product.ProductName:-35} - {product.UnitPrice,8:$#,##0.00} - {product.UnitPrice,5} - {product.UnitsInStock} -{product.Discontinued}");
        }
    }
}



static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
{
    using (Northwind db = new Northwind())
    {
        Product updateProduct = db.Products.First(c => c.ProductName.StartsWith(productNameStartsWith));
        updateProduct.UnitPrice += amount;

        int affected = db.SaveChanges();
        return (affected == 1);
    }
}





static int DeleteProducts(string productNameStartsWith)
{
    using (Northwind db = new Northwind())
    {
        IQueryable<Product>? products = db.Products?.Where(
            p => p.ProductName.StartsWith(productNameStartsWith)
            );

        if (products is null)
        {
            WriteLine($"No products found to delete.");
            return 0;
        }
        else
        {
            db.Products.RemoveRange(products);
        }


        int affected = db.SaveChanges();

        return affected;
    }

}


static int DeleteProductsByName(string name)
{
    using (Northwind db = new Northwind())
    {
        using (IDbContextTransaction t = db.Database.BeginTransaction())
        {
            WriteLine($"Transaction isolation levle: {t.GetDbTransaction().IsolationLevel}");

            IQueryable<Product>? products = db.Products?.Where(p => p.ProductName.StartsWith(name));

            if (products is null)
            {
                WriteLine("No products found to delete.");
                return 0;
            }
            else
            {
                db.Products.RemoveRange(products);
            }

            int affected = db.SaveChanges();
            t.Commit();
            return affected;
        }
    }
}

//QueryingCategories();
//FilteredData();
//QueryingProducts();
//Console.ReadLine();
//QueryingWithLike();


/*
if (AddProduct(6, "Bob's Burger", 2000))
{
    WriteLine("Add Product Successful.");
}
*/


int deleted = DeleteProductsByName("Bob");
WriteLine($"{deleted} products ");

ListProducts();