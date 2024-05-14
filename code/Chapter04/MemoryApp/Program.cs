List<Person> people = new();

for (int i = 0; i < 10_000; i++)
{
  people.Add(new Person { Name = $"Person {i}", Age = i });
}

WriteLine($"Finished creating {people.Count} people.");

class Person
{
  public string? Name { get; set; }
  public int Age { get; set; }
}