
namespace Liso.DnD
{
    public class FileHandler : IFileHandler
    {
        #region Methods

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Person> ReadFile(string filePath)
        {
            List<Person> personList = [];

            using (var reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var information = line.Trim().Split(' ');
                    if (information.Length < 2)
                    {
                        throw new FormatException("Each line must contain at least on given name and a last name.");
                    }
                    var lastName = information.Last();
                    var givenNames = information.Take(information.Length - 1).ToList();
                    personList.Add(new Person(givenNames, lastName));
                }
            }
            return personList;
        }

        /// <summary>
        /// Writes to the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="personList">The person list.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteToFile(string filePath, List<Person> personList)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var person in personList)
            {
                writer.WriteLine(person.ToString());
            }
        }

        #endregion
    }
}
