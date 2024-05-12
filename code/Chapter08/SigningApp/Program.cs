using Packt.Shared; // To use Protector.

Write("Enter some text to sign: ");
string? data = ReadLine();

if (string.IsNullOrEmpty(data))
{
  WriteLine("You must enter some text.");
  return; // Exit the app.
}

string signature = Protector.GenerateSignature(data);

WriteLine($"Signature: {signature}");
WriteLine("Public key used to check signature:");
WriteLine(Protector.PublicKey);

if (Protector.ValidateSignature(data, signature))
{
  WriteLine("Correct! Signature is valid. Data has not been manipulated.");
}
else
{
  WriteLine("Invalid signature or the data has been manipulated.");
}

// Simulate manipulated data by replacing the first 
// character with an X (or if already an X then Y).
char newFirstChar = 'X';

if (data[0] == newFirstChar)
{
  newFirstChar = 'Y';
}

string manipulatedData = $"{newFirstChar}{data.Substring(1)}";

if (Protector.ValidateSignature(manipulatedData, signature))
{
  WriteLine("Correct! Signature is valid. Data has not been manipulated. ");
}
else
{
  WriteLine($"Invalid signature or manipulated data: {manipulatedData}");
}
