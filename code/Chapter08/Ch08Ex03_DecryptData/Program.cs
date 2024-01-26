using Packt.Shared; // To use Protector.
using System.Xml; // To use XmlReader.
using System.Security.Cryptography; // To use CryptographicException.

WriteLine("You must enter the correct password to decrypt the document.");
Write("Password: ");
string? password = ReadLine();

if (string.IsNullOrEmpty(password))
{
  WriteLine("A password is required to continue.");
  return; // Exit the app.
}

List<Customer> customers = new();

// Define an XML file to read from.
string xmlFile = Combine(CurrentDirectory,
  "..", "protected-customers.xml");

if (!File.Exists(xmlFile))
{
  WriteLine($"{xmlFile} does not exist!");
  return;
}

XmlReader xmlReader = XmlReader.Create(xmlFile,
  new XmlReaderSettings { IgnoreWhitespace = true });

while (xmlReader.Read())
{
  if (xmlReader.NodeType == XmlNodeType.Element 
    && xmlReader.Name == "customer")
  {
    xmlReader.Read(); // Move to <name> element.

    string name = xmlReader.ReadElementContentAsString();
    string creditcardEncrypted = xmlReader.ReadElementContentAsString();
    string? creditcard = null;
    string errorMessage = "No credit card";

    try
    {
      creditcard = Protector.Decrypt(creditcardEncrypted, password);
    }
    catch (CryptographicException)
    {
      errorMessage = $"Failed to decrypt {name}'s credit card.";
    }

    string passwordHashed = xmlReader.ReadElementContentAsString();
    string salt = xmlReader.ReadElementContentAsString();

    customers.Add(new Customer(name,
      creditcard ?? errorMessage, passwordHashed));
  }
}

xmlReader.Close();

WriteLine();
int number = 0;
WriteLine($"    {"Name",-20} {"Credit Card",-20}");

foreach (var customer in customers)
{
  WriteLine($"[{number}] {customer.Name,-20} {
    customer.CreditCard,-20}");

  number++;
}
WriteLine();

Write("Press the number of a customer to log in as: ");

string? customerName = null;

try
{
  number = int.Parse(ReadKey().KeyChar.ToString());
  customerName = customers[number].Name;
}
catch
{
  WriteLine();
  WriteLine("Not a valid customer selection.");
  return;
}

WriteLine();
Write($"Enter {customerName}'s password: ");

string? attemptPassword = ReadLine();

if (string.IsNullOrEmpty(attemptPassword))
{
  WriteLine("A password is required to continue.");
  return; // Exit the app.
}

if (Protector.CheckPassword(
  username: customers[number].Name,
  password: attemptPassword))
{
  WriteLine("Correct!");
}
else
{
  WriteLine("Wrong!");
}
