namespace Packt.Shared;

[AttributeUsage(
  AttributeTargets.Class | AttributeTargets.Method,
  AllowMultiple = true)]
public class CoderAttribute(
  string coder, string lastModified) : Attribute
{
  public string Coder { get; set; } = coder;

  public DateTime LastModified { get; set; }
    = DateTime.Parse(lastModified);
}
