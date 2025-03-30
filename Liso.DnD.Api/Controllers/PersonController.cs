using Microsoft.AspNetCore.Mvc;

namespace Liso.DnD
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        #region Properties

        private readonly IPersonService _personService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PersonController> _personLogger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PersonController(IPersonService personService, ILogger<PersonController> personLogger, IConfiguration configuration)
        {
            _personService = personService;
            _configuration = configuration;
            _personLogger = personLogger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sorts the name list.
        /// </summary>
        /// <param name="inputFilePath">The input file path.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inputFilePath</exception>
        /// <exception cref="InvalidOperationException">Output file path is not configured.</exception>
        [HttpGet(Name = "Sort")]
        public string SortByName(string inputFilePath)
        {
            _personLogger.LogInformation("Sorting by name");

            if (string.IsNullOrWhiteSpace(inputFilePath))
                throw new ArgumentNullException(nameof(inputFilePath));

            if (!System.IO.File.Exists(inputFilePath))
            {
                _personLogger.LogError("File does NOT exist.");
                throw new FileNotFoundException(nameof(inputFilePath));
            }

            string? outputFilePath = _configuration["SaveFilePath"];
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                _personLogger.LogWarning("Output file path is not configured.");
                outputFilePath = "./sorted-names-list.txt";
            }

            try
            {
                List<Person> personList = _personService.SortNames(inputFilePath, outputFilePath);
                return string.Join(Environment.NewLine, personList.Select(p => p.ToString()));
            }
            catch (Exception exc)
            {
                _personLogger.LogError(exc, "Error sorting by name");
                throw;
            }
        }

        #endregion
    }
}
