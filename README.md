# DyeDurham

The Name Sorter Solution is a C# application designed to read a list of names from a text file, sort them by last name and then by given names, and write the sorted names to an output text file. The application adheres to the SOLID principles of object-oriented design, ensuring maintainability and scalability.

## Architecture
The solution consists of the following components:

Person Class: Represents an individual with given names and a last name.
Sorter Class: Contains the logic for sorting a list of Person objects.
FileHandler Class: Manages reading from and writing to text files.
Program Class: The entry point of the application that orchestrates the reading, sorting, and writing processes.
Swagger UI: The UI of the application that orchestrates the reading, sorting, and writing processes.

## Components

**1. Person Class**

```
public class Person
{
    public List<string> GivenNames { get; }

    public string LastName { get; }

    public Person(List<string> givenNames, string lastName)
    {
        GivenNames = givenNames;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{string.Join(" ", GivenNames)} {LastName}";
    }
}
```

- Properties:
  - 'GivenNames': A list of strings representing the given names of the person.
  - 'LastName': A string representing the last name of the person.
- Methods:
  -  'ToString()': Returns a string representation of the person in the format "GivenNames LastName"

  
**2. Sorter Class**

   ```
   public class Sorter : ISorter
   {
     public List<Person> SortNames(List<Person> names)
     {
         return names == null
             ? throw new ArgumentNullException(nameof(names))
             : names.OrderBy(p => p.LastName).ThenBy(p => string.Join(" ", p.GivenNames)).ToList();
     }
   }
   ```
- Methods:
  - 'SortNames(List<Person> names)': sorts the list of 'Person' objects first by last name and then by given names. Throws an 'ArgumentNullException' if the input list is null.

**3. FileHandler Class**

```
	public class FileHandler : IFileHandler
{
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

	public void WriteToFile(string filePath, List<Person> personList)
	{
		using var writer = new StreamWriter(filePath);
		foreach (var person in personList)
		{
			writer.WriteLine(person.ToString());
		}
	}
}
```

- Methods:
  - 'ReadFile(string filePath)': reads names from a specified file and returns a list of 'Person' objects. Throws a 'FormatException' if a line does not contain at least one given name and last name.
  - 'WriteToFile(string filePath, List<Person> personList)': writes the list of names to a specified file.

4. Program Class
   
   - Main method: The entry point of the application that handles command-line arguments, reads names from a file, sorts them, and writes the sorted names to an output file.
   
6. Swagger UI
   
   ![image](https://github.com/user-attachments/assets/cea963ef-e924-4eda-a881-ccf8c78057d4)

8. Usage Instructions
   
   - Input File Format: Create a text file (e.g. 'unsorted-names-list.txt') with each name on a new line in the format:
     
     ```
      Janet Parsons
      Vaugh Lewis
      Adonis Julius Archer
      Shelby Nathan Yoder
      Marin Alvarez
      London Lindsey
      Beau Tristan Bentley
      Leo Gardner
      Hunter Uriah Mathew Clarke
      Mikayla Lopez
      Frankie Conner Ritter
     ```
   

   

   
