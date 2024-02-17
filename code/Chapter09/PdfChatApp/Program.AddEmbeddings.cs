using Microsoft.SemanticKernel; // To use Kernel.
using Microsoft.SemanticKernel.Connectors.OpenAI; // To use WithOpenAITextEmbeddingGeneration.
using Microsoft.SemanticKernel.Connectors.Sqlite; // To use SqliteMemoryStore.
using Microsoft.SemanticKernel.Memory; // To use MemoryBuilder.

// Disable experimental warnings.
#pragma warning disable SKEXP0003, SKEXP0011, SKEXP0028, SKEXP0052, SKEXP0055

partial class Program
{
  private static async Task<ISemanticTextMemory> AddEmbeddings(
    Kernel kernel, Settings settings, string collectionName)
  {
    // Process text files and create embeddings.
    ISemanticTextMemory memory = new MemoryBuilder()
      .WithLoggerFactory(kernel.LoggerFactory)
      .WithMemoryStore(await SqliteMemoryStore.ConnectAsync("my_books.db"))
      .WithOpenAITextEmbeddingGeneration(
        modelId: "text-embedding-3-small",
        apiKey: settings.OpenAISecretKey)
      .Build();

    string txtFolder = "TextPages";
    string pathImport;

    string dir = Environment.CurrentDirectory;

    if (dir.EndsWith("net8.0"))
    {
      // In the <project>\bin\<Debug|Release>\net8.0 directory.
      pathImport = Path.Combine("..", "..", "..", txtFolder);
    }
    else
    {
      // In the <project> directory.
      pathImport = txtFolder;
    }

    // Convert to absolute path.
    pathImport = Path.GetFullPath(pathImport);

    IList<string> collections = await memory.GetCollectionsAsync();

    if (collections.Contains(collectionName))
    {
      WriteLine($"Found collection: {collectionName}");
    }
    else
    {
      string[] txtFiles = Directory.GetFiles(
        pathImport, searchPattern: "*.txt");

      foreach (string filePath in txtFiles)
      {
        string fileName = Path.GetFileName(filePath);
        WriteLine($"Processing {fileName}...");

        string pageContent = await File.ReadAllTextAsync(filePath);

        // Skip empty content.
        if (string.IsNullOrWhiteSpace(pageContent)) continue;

        await memory.SaveInformationAsync(
          collectionName, pageContent, id: fileName);
      }
    }
    return memory;
  }
}
