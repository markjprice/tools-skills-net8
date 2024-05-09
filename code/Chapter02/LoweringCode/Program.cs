List<Person> people = [ new("Bob", 47), new("Alice", 23) ];

foreach(Person person in people)
{
    Console.WriteLine(person);
}

record Person(string FirstName, int Age);
