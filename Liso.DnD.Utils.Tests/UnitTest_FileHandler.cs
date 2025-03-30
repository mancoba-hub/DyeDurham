namespace Liso.DnD.Utils.Tests
{
    public class UnitTest_FileHandler
    {
        #region Properties 

        private readonly FileHandler _fileHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest_FileHandler"/> class.
        /// </summary>
        public UnitTest_FileHandler()
        {
            _fileHandler = new FileHandler();
        }

        #endregion

        #region Tests

        #region Read File

        /// <summary>
        /// Unit Test - read file should return list of names when input is valid.
        /// </summary>
        [Fact]
        public void Test_ReadFile_ShouldReturnListOfNames_WhenInputIsValid()
        {
            //Arrange
            var filePath = "./unsorted-names-list.txt";
            var content = "Janet Parsons\nAdonis Julius Archer\nMarin Alvarez";
            File.WriteAllText(filePath, content);

            //Act
            var unsortedNameList = _fileHandler.ReadFile(filePath);

            //Assert
            Assert.Equal(3, unsortedNameList.Count);
            Assert.Equal("Janet", unsortedNameList[0].GivenNames[0].ToString());
            Assert.Equal("Parsons", unsortedNameList[0].LastName);

            Assert.Equal("Adonis", unsortedNameList[1].GivenNames[0].ToString());
            Assert.Equal("Julius", unsortedNameList[1].GivenNames[1].ToString());
            Assert.Equal("Archer", unsortedNameList[1].LastName);

            Assert.Equal("Marin", unsortedNameList[2].GivenNames[0].ToString());
            Assert.Equal("Alvarez", unsortedNameList[2].LastName);

            // Clean up
            File.Delete(filePath);
        }

        /// <summary>
        /// Unit Test - the read file should throw format exception when line has invalid names.
        /// </summary>
        [Fact]
        public void Test_ReadFile_ShouldThrowFormatException_WhenLineHasInvalidNames()
        {
            // Arrange
            var filePath = "./invalid_names.txt";
            var content = "Liso\nLiso Mbiza";
            File.WriteAllText(filePath, content);

            // Act & Assert
            var exception = Assert.Throws<FormatException>(() => _fileHandler.ReadFile(filePath));
            Assert.Equal("Each line must contain at least on given name and a last name.", exception.Message);

            // Clean up
            File.Delete(filePath);
        }

        #endregion

        #region Write To File   

        /// <summary>
        /// Unit Test - write to file should create file with correct content when person list is valid.
        /// </summary>
        [Fact]
        public void Test_WriteToFile_ShouldCreateFileWithCorrectContent_WhenPersonListIsValid()
        {
            // Arrange
            var filePath = "./sorted-names-list.txt";
            var personList = new List<Person>
            {
                new(["Marin"], "Alvarez"),
                new(["Adonis Julius"], "Archer"),
                new(["Janet"], "Parsons")
            };

            // Act
            _fileHandler.WriteToFile(filePath, personList);

            // Assert
            var writtenContent = File.ReadAllLines(filePath);
            Assert.Equal(3, writtenContent.Length);
            Assert.Equal("Marin Alvarez", writtenContent[0]);
            Assert.Equal("Adonis Julius Archer", writtenContent[1]);
            Assert.Equal("Janet Parsons", writtenContent[2]);

            // Clean up
            File.Delete(filePath);
        }

        #endregion

        #endregion
    }
}