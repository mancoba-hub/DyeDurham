namespace Liso.DnD
{
    public interface IFileHandler
    {
        List<Person> ReadFile(string filePath);

        void WriteToFile(string filePath, List<Person> personList);
    }
}
