using System.Runtime.Loader; // To use AssemblyDependencyResolver.

internal class DemoAssemblyLoadContext : AssemblyLoadContext
{
  private AssemblyDependencyResolver _resolver;

  public DemoAssemblyLoadContext(string mainAssemblyToLoadPath)
    : base(isCollectible: true)
  {
    _resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
  }
}
