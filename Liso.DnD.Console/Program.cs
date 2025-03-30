// See https://aka.ms/new-console-template for more information

using Liso.DnD;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: Liso.DnD.Console <input-file-path>");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = "./sorted-names-list.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("File does NOT exist.");
            return;
        }

        //Setup the dependency injection container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISorter, Sorter>()
            .AddSingleton<IFileHandler, FileHandler>()
            .AddSingleton<IPersonService, PersonService>()
            .BuildServiceProvider();

        //Resolve the service and call the PersonService method
        var personService = serviceProvider.GetService<IPersonService>();
        if (personService != null)
        {
            var personList = personService.SortNames(inputFilePath, outputFilePath);
            Console.WriteLine(string.Join(Environment.NewLine, personList.Select(p => p.ToString())));
        }
    }
}
