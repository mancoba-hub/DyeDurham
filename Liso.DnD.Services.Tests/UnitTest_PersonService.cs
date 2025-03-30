using Moq;

namespace Liso.DnD
{
    public class UnitTest_PersonService
    {
        #region Properties

        private readonly Mock<ISorter> _mockSorter;
        private readonly Mock<IFileHandler> _mockFileHandler;

        private readonly string inputFilePath = "./unsorted-names-list.txt";
        private readonly string outputFilePath = "./sorted_names.txt";

        private PersonService _personService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest_PersonService"/> class.
        /// </summary>
        public UnitTest_PersonService()
        {
            _mockSorter = new Mock<ISorter>();
            _mockFileHandler = new Mock<IFileHandler>();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Unit Tests - sort names should return sorted list when input file is valid.
        /// </summary>
        [Fact]
        public void Test_SortNames_ShouldReturnSortedList_WhenInputFileIsValid()
        {
            //Arrange
            var unsortedPersonList = GetUnsortedPersonList();
            var expectedSortedPersonList = GetSortedPersonList();
            _mockSorter.Setup(x => x.SortNames(unsortedPersonList)).Returns(expectedSortedPersonList);
            _mockFileHandler.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(unsortedPersonList);
            _mockFileHandler.Setup(x => x.WriteToFile(It.IsAny<string>(), expectedSortedPersonList));
            _personService = new PersonService(_mockSorter.Object, _mockFileHandler.Object);

            //Act
            var actualSortedList = _personService.SortNames(inputFilePath, outputFilePath);

            //Assert
            Assert.NotNull(actualSortedList);
            Assert.True(actualSortedList.Any());
            Assert.Equal(expectedSortedPersonList, actualSortedList);
            _mockFileHandler.Verify(x => x.WriteToFile(outputFilePath, actualSortedList), Times.Once);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the unsorted person list.
        /// </summary>
        /// <returns></returns>
        private List<Person> GetUnsortedPersonList()
        {
            return
            [
                new(["Janet"], "Parsons"),
                new(["Adonis Julius"], "Archer"),
                new(["Marin"], "Alvarez")
            ];
        }

        /// <summary>
        /// Gets the sorted person list.
        /// </summary>
        /// <returns></returns>
        private List<Person> GetSortedPersonList()
        {
            return
            [
                new(["Marin"], "Alvarez"),
                new(["Adonis Julius"], "Archer"),
                new(["Janet"], "Parsons")
            ];
        }

        #endregion
    }
}