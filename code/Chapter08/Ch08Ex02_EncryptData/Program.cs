using Packt.Shared; // To use Protector.
using System.Xml; // To use XmlWriter.

WriteLine("You must enter a password to encrypt the sensitive data in the document.");
WriteLine("You must enter the same passord to decrypt the document later.");
Write("Password: ");
string? password = ReadLine();

if (string.IsNullOrEmpty(password))
{
  WriteLine("A password is required to continue.");
  return; // Exit the app.
}

// Define two example customers and note they have the same password.

Customer c1 = new Customer("Bob Smith", 
  "1234-5678-9012-3456", "Pa$$w0rd");

Customer c2 = new Customer("Leslie Knope",
    "8002-5265-3400-2511", "Pa$$w0rd");

List<Customer> customers = [c1, c2];

// Define an XML file to write to.
string xmlFile = Combine(CurrentDirectory,
  "..", "protected-customers.xml");

XmlWriter xmlWriter = XmlWriter.Create(xmlFile,
  new XmlWriterSettings { Indent = true });

xmlWriter.WriteStartDocument();

xmlWriter.WriteStartElement("customers");

foreach (var customer in customers)
{
  xmlWriter.WriteStartElement("customer");
  xmlWriter.WriteElementString("name", customer.Name);

  // To protect the credit card number we must encrypt it
  // using the app-level password.
  xmlWriter.WriteElementString("creditcard",
    Protector.Encrypt(customer.CreditCard, password));

  // To protect the password we must salt and hash it
  // and we must store the random salt used.
  User user = Protector.Register(customer.Name, customer.Password);
  xmlWriter.WriteElementString("password", user.SaltedHashedPassword);
  xmlWriter.WriteElementString("salt", user.Salt);

  xmlWriter.WriteEndElement();
}
xmlWriter.WriteEndElement();
xmlWriter.WriteEndDocument();
xmlWriter.Close();

WriteLine();
WriteLine("Contents of the protected file:");
WriteLine();
WriteLine(File.ReadAllText(xmlFile));
