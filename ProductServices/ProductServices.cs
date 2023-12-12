using Microsoft.EntityFrameworkCore;
using NWConsole.Model;




public class ProductServices
{


    // Instance of DbContext
    private readonly NWContext _dbContext;

    public ProductServices(NWContext dbContext)
    {   //initialize DbContext
        this._dbContext = dbContext;
    }
    public void AddProduct()
    {
        var newProduct = GetProductDetailsFromUser();

        // Check if supplier exists
        var supplierExists = _dbContext.Suppliers.Any(s => s.SupplierId == newProduct.SupplierId);
        if (!supplierExists)
        {
            LoggerConfig.LogDebug($"No Supplier found for Supplier ID: {newProduct.SupplierId}");
            return;
        }

        // Check if category exists
        var categoryExists = _dbContext.Categories.Any(c => c.CategoryId == newProduct.CategoryId);
        if (!categoryExists)
        {
            LoggerConfig.LogDebug($"No Category found for Category ID: {newProduct.CategoryId}");
            return;
        }

        _dbContext.Products.Add(newProduct);
        try
        {
            _dbContext.SaveChanges();
            LoggerConfig.LogDebug($"Product added with Id: {newProduct.ProductId}");
        }
        catch (DbUpdateException ex)
        {
            LoggerConfig.LogDebug(ex.InnerException.Message);
        }
    }

    public void EditProduct(int productId)
    {

        var product = _dbContext.Products.Find(productId);
        if (product == null)
        {
            LoggerConfig.LogDebug($"No product found with Id: {productId}");
            return;
        }

        var editedProduct = GetProductDetailsFromUser(product);

        // Check if supplier exists
        var supplierExists = _dbContext.Suppliers.Any(s => s.SupplierId == editedProduct.SupplierId);
        if (!supplierExists)
        {
            LoggerConfig.LogDebug($"No Supplier found for Supplier ID: {editedProduct.SupplierId}");
            return;
        }

        // Check if category exists
        var categoryExists = _dbContext.Categories.Any(c => c.CategoryId == editedProduct.CategoryId);
        if (!categoryExists)
        {
            LoggerConfig.LogDebug($"No Category found for Category ID: {editedProduct.CategoryId}");
            return;
        }

        _dbContext.Entry(product).State = EntityState.Modified;

        try
        {
            _dbContext.SaveChanges();
            LoggerConfig.LogDebug($"Product edited: {product.ProductName}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            LoggerConfig.LogDebug(ex.Message);
        }
    }

    public void DeleteProduct(int id)
    {
        DisplayAllProducts();
        var product = _dbContext.Products.Find(id);
        if (product == null)
        {
            LoggerConfig.LogDebug($"No product found with Id: {id}");
            return;
        }

        _dbContext.Products.Remove(product);
        try
        {
            _dbContext.SaveChanges();
            LoggerConfig.LogDebug($"Product deleted: {product.ProductName}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            LoggerConfig.LogDebug(ex.Message);
        }
    }

    public void DisplayActiveProducts()
    {
        // Method for displaying active products
        var activeProducts = _dbContext.Products.Where(p => !p.Discontinued).OrderBy(p => p.ProductId).ToList();

        foreach (var product in activeProducts)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"Product ID: {product.ProductId}");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"Quantity per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"Unit Price: {product.UnitPrice}");
            Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
            Console.WriteLine($"Units on Order: {product.UnitsOnOrder}");
            Console.WriteLine($"Reorder Level: {product.ReorderLevel}");
            Console.WriteLine("----------------------------------------\n");
        }

        // Get and print the number of displayed products
        int numOfActiveProducts = activeProducts.Count;
        Console.WriteLine($"Number of active products displayed: {numOfActiveProducts}");

        LoggerConfig.LogDebug("All active products displayed");
        LoggerConfig.LogDebug($"Number of active products displayed: {numOfActiveProducts}");
    }

    public void DisplayDiscontinuedProducts()
    {
        // Method for displaying discontinued products
        var discontinuedProducts = _dbContext.Products.Where(p => p.Discontinued).OrderBy(p => p.ProductId).ToList();

        foreach (var product in discontinuedProducts)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"Product ID: {product.ProductId}");
            Console.WriteLine($"Product Name: {product.ProductName} (DISCONTINUED)");
            Console.WriteLine($"Quantity per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"Unit Price: {product.UnitPrice}");
            Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
            Console.WriteLine($"Units on Order: {product.UnitsOnOrder}");
            Console.WriteLine($"Reorder Level: {product.ReorderLevel}");
            Console.WriteLine("----------------------------------------\n");
        }

        // Get and print the number of displayed products
        int numOfDiscontinuedProducts = discontinuedProducts.Count;
        Console.WriteLine($"Number of discontinued products displayed: {numOfDiscontinuedProducts}");

        LoggerConfig.LogDebug("All discontinued products displayed");
        LoggerConfig.LogDebug($"Number of discontinued products displayed: {numOfDiscontinuedProducts}");
    }

    public void DisplayAllProducts()
    {
        // Method for displaying all products
        var products = _dbContext.Products.OrderBy(p => p.ProductId).ToList();

        foreach (var product in products)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"Product ID: {product.ProductId}");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"Quantity per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"Unit Price: {product.UnitPrice}");
            Console.WriteLine($"Units in Stock: {product.UnitsInStock}");
            Console.WriteLine($"Units on Order: {product.UnitsOnOrder}");
            Console.WriteLine($"Reorder Level: {product.ReorderLevel}");
            Console.WriteLine($"Discontinued: {product.Discontinued}");
            Console.WriteLine("----------------------------------------\n");
        }

        // Get and print the number of displayed products
        int numOfProducts = products.Count;
        Console.WriteLine($"Number of products displayed: {numOfProducts}");

        LoggerConfig.LogDebug("All products displayed");
        LoggerConfig.LogDebug($"Number of products displayed: {numOfProducts}");
    }



    public void DisplayProduct(int id)
    {
        // Method for displaying a specific product
        var product = _dbContext.Products.Find(id);

        if (product != null)
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"ID: {product.ProductId}\n" +
                              $"Name: {product.ProductName}\n" +
                              $"Category: {product.CategoryId}\n" +
                              $"Supplier: {product.SupplierId}\n" +
                              $"Price: {product.UnitPrice:C}\n" +
                              $"In Stock: {product.UnitsInStock}\n" +
                              $"On Order: {product.UnitsOnOrder}\n" +
                              $"Reorder Level: {product.ReorderLevel}\n" +
                              $"Discontinued: {(product.Discontinued ? "Yes" : "No")}");
            Console.WriteLine("----------------------------------------\n");
        }
        LoggerConfig.LogDebug($"Product displayed: {product.ProductName}");
    }

    public void RecommendRandomProduct()
    { // Method for recommending a random product
        int totalProducts = _dbContext.Products.Count();

        if (totalProducts > 0)
        {
            Random rand = new Random();
            int skipCount = rand.Next(totalProducts);

            var randomProduct = _dbContext.Products.OrderBy(p => p.ProductId).Skip(skipCount).FirstOrDefault();

            if (randomProduct != null)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"We recommend: {randomProduct.ProductName}");
                Console.WriteLine("----------------------------------------\n");
            }
            LoggerConfig.LogDebug($"Recommended product: {randomProduct.ProductName}");
        }
        else
        {
            Console.WriteLine("No products available for recommendation.");
            LoggerConfig.LogDebug("No products available for recommendation.");
        }
    }

    public void SearchProducts(string searchTerm)
    {
        var matchedProducts = _dbContext.Products.Where(p => p.ProductName.Contains(searchTerm)).ToList();
        if (matchedProducts.Count > 0)
        {
            Console.WriteLine($"Found {matchedProducts.Count} match(es) for '{searchTerm}':");
            foreach (var product in matchedProducts)
            {
                Console.WriteLine($"{product.ProductId}: {product.ProductName}");
            }
        }
        else
        {
            Console.WriteLine($"No matches found for '{searchTerm}'.");
        }
    }

    public void CompareProducts(int id1, int id2)
    {
        var product1 = _dbContext.Products.Find(id1);
        var product2 = _dbContext.Products.Find(id2);

        if (product1 != null && product2 != null)
        {
            Console.WriteLine($"Price of {product1.ProductName}: {product1.UnitPrice:C}");
            Console.WriteLine($"Price of {product2.ProductName}: {product2.UnitPrice:C}");

            if (product1.UnitPrice > product2.UnitPrice)
            {
                Console.WriteLine($"{product1.ProductName} is more expensive than {product2.ProductName}");
            }
            else if (product1.UnitPrice < product2.UnitPrice)
            {
                Console.WriteLine($"{product1.ProductName} is cheaper than {product2.ProductName}");
            }
            else
            {
                Console.WriteLine($"{product1.ProductName} costs the same as {product2.ProductName}");
            }
        }
        else
        {
            Console.WriteLine("One or both of the product IDs are invalid.");
        }
    }

    public void SortProducts(string orderBy)
    {
        List<Product> products;

        switch (orderBy.ToLower())
        {
            case "name":
                products = _dbContext.Products.OrderBy(p => p.ProductName).ToList();
                break;
            case "price":
                products = _dbContext.Products.OrderBy(p => p.UnitPrice).ToList();
                break;
            default:
                Console.WriteLine($"Invalid sort term '{orderBy}'. Choices are 'name' or 'price'.");
                return;
        }

        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductId}: {product.ProductName} - {product.UnitPrice:C}");
        }
    }




    public Product GetProductDetailsFromUser(Product product = null)
    {
        product ??= new Product();

        // Validate the input while getting
        var productName = GetValidStringInput("Enter Product Name:", 1, 50); // Example: limit name to 50 characters

        // Check if a product with the same name exists
        var productExists = _dbContext.Products.Any(p => p.ProductName == productName);

        if (productExists)
        {
            Console.WriteLine($"Warning: A product named '{productName}' already exists.");
        }

        // Validate other inputs
        var supplierId = GetValidNumberInput("Enter Supplier ID:", 1, int.MaxValue);
        var categoryId = GetValidNumberInput("Enter Category ID:", 1, int.MaxValue);
        var unitsInStock = GetValidNumberInput("Enter Units In Stock:", 0, short.MaxValue);
        var unitsOnOrder = GetValidNumberInput("Enter Units On Order:", 0, short.MaxValue);
        var reorderLevel = GetValidNumberInput("Enter Reorder Level:", 0, short.MaxValue);
        var quantityPerUnit = GetValidStringInput("Enter Quantity Per Unit:", 1, 20); // Example: limit string length to 20 characters

        Console.WriteLine("Enter Unit Price:");
        var unitPriceStr = Console.ReadLine();
        decimal unitPrice;
        while (!decimal.TryParse(unitPriceStr, out unitPrice) || unitPrice < 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive Decimal number for Unit Price:");
            unitPriceStr = Console.ReadLine();
        }

        Console.WriteLine("Is the Product Discontinued? (yes/no)");
        var discontinuedInput = Console.ReadLine();
        bool isDiscontinued = (discontinuedInput.ToLower() == "yes");

        product.ProductName = productName;
        product.SupplierId = supplierId;
        product.CategoryId = categoryId;
        product.UnitsInStock = (short?)unitsInStock;
        product.UnitsOnOrder = (short?)unitsOnOrder;
        product.ReorderLevel = (short?)reorderLevel;
        product.QuantityPerUnit = quantityPerUnit;
        product.UnitPrice = unitPrice;
        product.Discontinued = isDiscontinued;

        return product;
    }

    public int GetValidNumberInput(string prompt, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= min && number <= max)
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Invalid input! Please enter a valid number between {min} and {max}.");
            }
        }
    }

    public string GetValidStringInput(string prompt, int minLength, int maxLength)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length >= minLength && input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                Console.WriteLine($"Invalid input! Please enter a valid text between {minLength} and {maxLength} characters.");
            }
        }
    }



}


internal class NWConsoleContext
{
    public static implicit operator NWConsoleContext(NWContext v)
    {
        throw new NotImplementedException();
    }
}