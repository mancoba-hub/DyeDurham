namespace Liso.DnD
{
    public interface IPersonService
    {
        List<Person> SortNames(string inputFilePath, string outputFilePath);
    }
}
