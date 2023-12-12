using System.Runtime.InteropServices;
using System.Reflection;

public class Art
{
    //Helper Methods for art display
    public void NWTitle()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Console.SetWindowSize(153, 25);

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                  .FirstOrDefault(str => str.EndsWith(".NWTitle.txt"));

                // Check if the resource exists.
                if (resourceName == null)
                {
                    throw new InvalidOperationException("Resource .ConsoleStyle.movieTitle.txt not found.");
                }

                using Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Check if the stream is valid.
                if (stream == null)
                {
                    throw new InvalidOperationException("Unable to get resource stream.");
                }

                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                var defaultForgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(2000);
                Console.WriteLine(result);

                Console.ForegroundColor = defaultForgroundColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void NWMenu()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Console.SetWindowSize(153, 25);

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                  .FirstOrDefault(str => str.EndsWith(".NWMenu.txt"));

                // Check if the resource exists.
                if (resourceName == null)
                {
                    throw new InvalidOperationException("Resource .ConsoleStyle.movieTitle.txt not found.");
                }

                using Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Check if the stream is valid.
                if (stream == null)
                {
                    throw new InvalidOperationException("Unable to get resource stream.");
                }

                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                var defaultForgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Thread.Sleep(2000);
                Console.WriteLine(result);

                Console.ForegroundColor = defaultForgroundColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void NWMainMenu()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Console.SetWindowSize(153, 25);

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                  .FirstOrDefault(str => str.EndsWith(".NWMainMenuDetail.txt"));

                // Check if the resource exists.
                if (resourceName == null)
                {
                    throw new InvalidOperationException("Resource .NWMainMenuDetail.txt not found.");
                }

                using Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Check if the stream is valid.
                if (stream == null)
                {
                    throw new InvalidOperationException("Unable to get resource stream.");
                }

                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                var defaultForgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(2000);
                Console.WriteLine(result);

                Console.ForegroundColor = defaultForgroundColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }


    public void NWProductMenu()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Console.SetWindowSize(153, 25);

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                  .FirstOrDefault(str => str.EndsWith(".NWProductMenu.txt"));

                // Check if the resource exists.
                if (resourceName == null)
                {
                    throw new InvalidOperationException("Resource .NWProductMenu.txt not found.");
                }

                using Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Check if the stream is valid.
                if (stream == null)
                {
                    throw new InvalidOperationException("Unable to get resource stream.");
                }

                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                var defaultForgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(2000);
                Console.WriteLine(result);

                Console.ForegroundColor = defaultForgroundColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void NWCategoryMenu()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                Console.SetWindowSize(153, 25);

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                  .FirstOrDefault(str => str.EndsWith(".NWCategoryMenu.txt"));

                // Check if the resource exists.
                if (resourceName == null)
                {
                    throw new InvalidOperationException("Resource .NWCategoryMenu.txt not found.");
                }

                using Stream stream = assembly.GetManifestResourceStream(resourceName);

                // Check if the stream is valid.
                if (stream == null)
                {
                    throw new InvalidOperationException("Unable to get resource stream.");
                }

                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                var defaultForgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(2000);
                Console.WriteLine(result);

                Console.ForegroundColor = defaultForgroundColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }


}