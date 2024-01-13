using Microsoft.EntityFrameworkCore;
using static System.Console;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using WorkingWithEFCore;
using WorkingWithEFCore.AutoGen;



//static void QueryingWithLike()
//{
//    using (Northwind db = new Northwind())
//    {
//        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
//        loggerFactory.AddProvider(new ConsoleLoggerProvider());

//        Write("Enter part of the product name: ");
//        string? input = ReadLine();

//        IQueryable<Product>? products = db.Products?.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
        
//        if(products is null)
//        {
//            WriteLine("No products found.");
//            return;
//        }

//        foreach(Product product in products)
//        {
//            WriteLine($"{product.ProductName} has {product.UnitsInStock} units in stock. Discontinued? {product.Discontinued}");
//        }
//    }
//}

//QueryingWithLike();
