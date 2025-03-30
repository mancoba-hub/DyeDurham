
namespace Liso.DnD
{
    public class PersonService : IPersonService
    {
        #region Properties

        private readonly ISorter _sort;
        private readonly IFileHandler _fileHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="fileHandler">The file handler.</param>
        public PersonService(ISorter sort, IFileHandler fileHandler)
        {
            _sort = sort;
            _fileHandler = fileHandler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sorts the names.
        /// </summary>
        /// <param name="inputFilePath">The input file path.</param>
        /// <param name="outputFilePath">The output file path.</param>
        /// <returns></returns>
        public List<Person> SortNames(string inputFilePath, string outputFilePath)
        {
            //Read the file with unsorted name list
            var names = _fileHandler.ReadFile(inputFilePath);

            //Sort the names
            var sortedList = _sort.SortNames(names);

            //Save the file with sorted name list
            _fileHandler.WriteToFile(outputFilePath, sortedList);

            //Return the sorted list to the screen
            return sortedList;
        }

        #endregion
    }
}
