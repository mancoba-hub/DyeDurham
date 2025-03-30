namespace Liso.DnD
{
    public class Person
    {
        #region Properties

        public List<string> GivenNames { get; }

        public string LastName { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="givenNames">The given names.</param>
        /// <param name="lastName">The last name.</param>
        public Person(List<string> givenNames, string lastName)
        {
            GivenNames = givenNames;
            LastName = lastName;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{string.Join(" ", GivenNames)} {LastName}";
        }

        #endregion
    }
}
