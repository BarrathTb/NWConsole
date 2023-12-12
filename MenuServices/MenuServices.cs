using System.Runtime.CompilerServices;
using NWConsole.Model;

public class MenuServices
{
    // Instance of DbContext
    private NWContext DBContext;

    public MenuServices(NWContext dbContext)
    {
        this.DBContext = dbContext;
    }

    public void DisplayMainMenu()
    {


        ProductServices productServices = new ProductServices(DBContext);
        CategoryServices categoryServices = new CategoryServices(DBContext);
        bool displayMenu = true;
        var art = new Art();
        art.NWTitle();
        while (displayMenu)
        {

            art.NWMenu();




            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- --\n");
            Console.WriteLine("| 1. Products Menu                   |\n");
            Console.WriteLine("| 2. Category Menu                   |\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| q. Exit Menu                       |\n");
            Console.ResetColor();

            Console.WriteLine("| Select an option from the menu:    |\n");
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- --\n");



            // Console.WriteLine("1) Product Menu");
            // Console.WriteLine("2) Category Menu");
            // Console.WriteLine("\"q\" to quit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DisplayProductMenu(productServices);
                    break;

                case "2":
                    DisplayCategoryMenu(categoryServices);
                    break;

                case "q":
                    displayMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please choose a valid option");
                    break;
            }
        }
    }


    public void DisplayProductMenu(ProductServices productServices)
    {
        var art = new Art();
        art.NWProductMenu();
        bool displayMenu = true;
        while (displayMenu)
        {

            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- --\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| 1. Add Product                    |\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| 2. Edit Product                   |\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| 3. Delete Product                 |\n");
            Console.ResetColor();
            Console.WriteLine("| 4. Display All Products           |\n");
            Console.WriteLine("| 5. Display Active Products        |\n");
            Console.WriteLine("| 6. Display Discontinued Products  |\n");
            Console.WriteLine("| 7. Display Specific Product       |\n");
            Console.WriteLine("| 8. Recommend Random Product       |\n");
            Console.WriteLine("| 9. Search Products                |\n");
            Console.WriteLine("| 10. Compare Product Prices        |\n");
            Console.WriteLine("| 11. Sort Products                 |\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| q. To go Back                     |\n");
            Console.ResetColor();
            Console.WriteLine("| Select an option from the menu:   |\n");
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- --\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    productServices.DisplayAllProducts();
                    productServices.AddProduct();
                    break;
                case "2":
                    productServices.DisplayAllProducts();
                    Console.WriteLine("Enter Product ID to edit:");
                    if (int.TryParse(Console.ReadLine(), out int prodIdEdit))
                    {
                        productServices.EditProduct(prodIdEdit);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                    }
                    break;
                case "3":
                    productServices.DisplayAllProducts();
                    Console.WriteLine("Enter Product ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int prodIdDelete))
                    {
                        productServices.DeleteProduct(prodIdDelete);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                    }
                    break;
                case "4":
                    productServices.DisplayAllProducts();
                    break;
                case "5":
                    productServices.DisplayActiveProducts();
                    break;
                case "6":
                    productServices.DisplayDiscontinuedProducts();
                    break;
                case "7":
                    int productId; // Assuming we're getting a productId from user.
                    Console.WriteLine("Enter the ID for the product:");
                    if (Int32.TryParse(Console.ReadLine(), out productId))
                        productServices.DisplayProduct(productId);
                    else
                        Console.WriteLine("Invalid input, please enter a valid number.");
                    break;
                case "8":
                    productServices.RecommendRandomProduct();
                    break;

                case "9":
                    Console.WriteLine("Enter search term:");
                    var searchTerm = Console.ReadLine();
                    productServices.SearchProducts(searchTerm);
                    break;
                case "10":
                    Console.WriteLine("Enter first product ID:");
                    int.TryParse(Console.ReadLine(), out int id1);
                    Console.WriteLine("Enter second product ID:");
                    int.TryParse(Console.ReadLine(), out int id2);
                    productServices.CompareProducts(id1, id2);
                    break;
                case "11":
                    Console.WriteLine("Enter order by (name or price):");
                    var orderBy = Console.ReadLine();
                    productServices.SortProducts(orderBy);
                    break;
                case "q":
                    displayMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please choose a valid option");
                    break;
            }
        }
    }


    public void DisplayCategoryMenu(CategoryServices categoryServices)
    {
        var art = new Art();
        art.NWCategoryMenu();
        bool displayMenu = true;
        while (displayMenu)
        {

            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n");
            Console.WriteLine("| 1. Display Categories                      |\n");
            Console.ResetColor();
            Console.WriteLine("| 2. Display Categories with Active Products |\n");
            Console.WriteLine("| 3. Display Specific Category               |\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| 4. Add Category                            |\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| 5. Edit Category                           |\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("| 6. Delete Category                         |\n");
            Console.ResetColor();
            Console.WriteLine("| q. Back to Main Menu                       |\n");
            Console.WriteLine("| Select an option from the menu:            |\n");
            Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- -- -- -- --\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    categoryServices.DisplayAllCategories();
                    break;

                case "2":
                    categoryServices.DisplayAllCategoriesWithActiveProducts();
                    break;

                case "3":
                    categoryServices.DisplayAllCategories();
                    Thread.Sleep(1000);
                    Console.WriteLine("Enter Category ID:");
                    if (Int32.TryParse(Console.ReadLine(), out int categoryId))
                    {
                        categoryServices.DisplaySpecificCategoryWithActiveProducts(categoryId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Enter Category Name:");
                    categoryServices.AddCategory();
                    break;

                case "5":
                    categoryServices.DisplayAllCategories();
                    Thread.Sleep(1000);
                    Console.WriteLine("Enter Category ID to edit:");
                    if (int.TryParse(Console.ReadLine(), out int categoryIdEdit))
                    {
                        categoryServices.EditCategory(categoryIdEdit);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                    }
                    break;

                case "6":
                    categoryServices.DisplayAllCategories();
                    Thread.Sleep(1000);
                    Console.WriteLine("Enter Category ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int categoryIdDelete))
                    {
                        categoryServices.DeleteCategory(categoryIdDelete);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number.");
                    }
                    break;

                case "q":
                    displayMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please choose a valid option");
                    break;
            }
        }
    }

    public void RunProgram()
    {
        DisplayMainMenu();
    }
}

