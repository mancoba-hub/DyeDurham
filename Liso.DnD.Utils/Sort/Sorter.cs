namespace Liso.DnD
{
    public class Sorter : ISorter
    {
        #region Methods

        /// <summary>
        /// Sorts the names.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Person> SortNames(List<Person> names)
        {
            return names == null
                ? throw new ArgumentNullException(nameof(names))
                : names.OrderBy(p => p.LastName).ThenBy(p => string.Join(" ", p.GivenNames)).ToList();
        }

        #endregion
    }
}
