using Packt.Shared; // To use Protector.
using System.Security.Principal; // To use IPrincipal.
using System.Security.Claims; // To use ClaimsPrincipal, Claim.
using System.Security; // To use SecurityException.

WriteLine("Registering Alice, Bob, and Eve with passwords Pa$$w0rd.");

Protector.Register("Alice", "Pa$$w0rd", roles: new[] { "Admins" });

Protector.Register("Bob", "Pa$$w0rd",
  roles: new[] { "Sales", "TeamLeads" });

// Register Eve who is not a member of any roles.
Protector.Register("Eve", "Pa$$w0rd");

WriteLine();

// Prompt the user to enter a username and password to login
// as one of these three users.

Write("Enter your username: ");
string? username = ReadLine()!;

Write("Enter your password: ");
string? password = ReadLine()!;

Protector.LogIn(username, password);

if (Thread.CurrentPrincipal == null)
{
  WriteLine("Log in failed.");
  return; // Exit the app.
}

IPrincipal p = Thread.CurrentPrincipal;

WriteLine($"IsAuthenticated: {p.Identity?.IsAuthenticated}");
WriteLine(
  $"AuthenticationType: {p.Identity?.AuthenticationType}");
WriteLine($"Name: {p.Identity?.Name}");
WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

if (p is ClaimsPrincipal principal)
{
    WriteLine($"{principal.Identity?.Name} has the following claims:");

    foreach (Claim claim in principal.Claims)
    {
        WriteLine($"{claim.Type}: {claim.Value}");
    }
}

try
{
  SecureFeature();
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()}: {ex.Message}");
}

static void SecureFeature()
{
  if (Thread.CurrentPrincipal is null)
  {
    throw new SecurityException(
      "A user must be logged in to access this feature.");
  }

  if (!Thread.CurrentPrincipal.IsInRole("Admins"))
  {
    throw new SecurityException(
      "User must be a member of Admins to access this feature.");
  }

  WriteLine("You have access to this secure feature.");
}
