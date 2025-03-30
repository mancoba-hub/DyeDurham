namespace Liso.DnD.Utils.Tests
{
    public class UnitTest_Sorter
    {
        #region Properties

        private readonly Sorter _sorter;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest_Sorter"/> class.
        /// </summary>
        public UnitTest_Sorter()
        {
            _sorter = new Sorter();
        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Unit Test - sort names should return sorted list when input is valid.
        /// </summary>
        [Fact]
        public void Test_SortNames_ShouldReturnSortedList_WhenInputIsValid()
        {
            // Arrange
            var names = new List<Person>
            {
                new(["Janet"], "Parsons"),
                new(["Adonis Julius"], "Archer"),
                new(["Marin"], "Alvarez")
            };

            var expectedSortedNames = new List<Person>
            {
                new(["Marin"], "Alvarez"),
                new(["Adonis Julius"], "Archer"),
                new(["Janet"], "Parsons")
            };

            // Act
            var actualSortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expectedSortedNames.Count, actualSortedNames.Count);
            for (int i = 0; i < expectedSortedNames.Count; i++)
            {
                Assert.Equal(expectedSortedNames[i].ToString(), actualSortedNames[i].ToString());
            }
        }

        /// <summary>
        /// Unit Test - sort names should throw argument null exception when input is null.
        /// </summary>
        [Fact]
        public void Test_SortNames_ShouldThrowArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            List<Person>? names = null;

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _sorter.SortNames(names));
            Assert.Equal("names", exception.ParamName);
        }

        /// <summary>
        /// Unit Test - sort names should return empty list when input is empty.
        /// </summary>
        [Fact]
        public void Test_SortNames_ShouldReturnEmptyList_WhenInputIsEmpty()
        {
            // Arrange
            var names = new List<Person>();

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Empty(sortedNames);
        }

        #endregion
    }
}
