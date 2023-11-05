namespace DataStructure;

public class DictionaryExample
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Name=" + Name + " Surname=" + Surname + " Age=" + Age;
        }
    }

    public void Example()
    {
        Dictionary<string, Person> phoneBook = new Dictionary<string, Person>();
        phoneBook.Add("0502301717", new Person("bb", "bb", 22));
        phoneBook.Add("0506434787", new Person("cc", "cc", 33));
        phoneBook.Add("0517606617", new Person("aa", "aa", 11));
        
        Show(phoneBook);

        Console.WriteLine();
        
        if (phoneBook.TryGetValue("0502301717", out Person person))
        {
            Console.WriteLine("Find person by his phone number: " + person);
        }
    }

    public void Show(Dictionary<string, Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine("Key: " + person.Key + " Value: " + person.Value);
        }
    }
}