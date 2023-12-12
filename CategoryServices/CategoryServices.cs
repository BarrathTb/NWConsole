using Microsoft.EntityFrameworkCore;


namespace NWConsole.Model
{
    public class CategoryServices
    {

        private readonly NWContext _dbContext; // Better name and readonly.

        public CategoryServices(NWContext dbContext)
        {
            _dbContext = dbContext; // Initialize here.
        }

        public void AddCategory()
        {
            var newCategory = GetCategoryDetailsFromUser();
            _dbContext.Categories.Add(newCategory);
            try
            {
                _dbContext.SaveChanges();
                LoggerConfig.LogDebug($"Category added with Id: {newCategory.CategoryId}");
            }
            catch (DbUpdateException ex)
            {
                LoggerConfig.LogDebug(ex.Message);
            }
        }

        public void EditCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            if (category == null)
            {
                LoggerConfig.LogDebug($"No category found with Id: {categoryId}");
                return;
            }

            GetCategoryDetailsFromUser(category);
            _dbContext.Entry(category).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
                LoggerConfig.LogDebug($"Category edited: {category.CategoryName}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                LoggerConfig.LogDebug(ex.Message);
            }
        }


        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                LoggerConfig.LogDebug($"No category found with Id: {id}");
                return;
            }

            _dbContext.Categories.Remove(category);
            try
            {
                _dbContext.SaveChanges();
                LoggerConfig.LogDebug($"Category deleted: {category.CategoryName}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                LoggerConfig.LogDebug(ex.Message);
            }
        }


        public void DisplayAllCategories()
        {
            var categories = _dbContext.Categories.OrderBy(c => c.CategoryId).ToList();

            foreach (var category in categories)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"{category.CategoryId} {category.CategoryName}\n{category.Description}");
                Console.WriteLine("----------------------------------------\n");

            }

            int numOfCategories = categories.Count;
            Console.WriteLine("\n----------------------------------------");

            Console.WriteLine($"Number of categories displayed: {numOfCategories}");
            Console.WriteLine("----------------------------------------\n");


            LoggerConfig.LogDebug("All categories displayed");
            LoggerConfig.LogDebug($"Number of categories displayed: {numOfCategories}");
        }

        public void DisplayAllCategoriesWithActiveProducts()
        {
            var categories = _dbContext.Categories.Include(c => c.Products).OrderBy(c => c.CategoryName);
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId} {category.CategoryName}\n{category.Description}");
                foreach (var product in category.Products.Where(p => !p.Discontinued))
                {
                    Console.WriteLine("\n----------------------------------------");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine("----------------------------------------\n");

                }
            }
        }


        public void DisplaySpecificCategoryWithActiveProducts(int categoryId)
        {
            var category = _dbContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                LoggerConfig.LogDebug($"No category found with Id: {categoryId}");
                return;
            }

            Console.WriteLine($"{category.CategoryId} {category.CategoryName}\n{category.Description}");
            foreach (var product in category.Products.Where(p => !p.Discontinued))
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine("----------------------------------------\n");

            }
        }


        public Category GetCategoryDetailsFromUser(Category category = null)
        {
            category ??= new Category();

            while (true)
            {
                Console.WriteLine("Enter Category Name:");
                var categoryName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(categoryName))
                {
                    category.CategoryName = categoryName;
                    break;
                }
                else
                {
                    LoggerConfig.LogDebug("Invalid input: Category name cannot be empty");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter Description:");
                var description = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(description))
                {
                    category.Description = description;
                    break;
                }
                else
                {
                    LoggerConfig.LogDebug("Invalid input: Description cannot be empty");
                }
            }

            return category;
        }

    }
}