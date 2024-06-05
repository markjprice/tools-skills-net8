using OllamaSharp; // To use OllamaApiClient.
using OllamaSharp.Models; // To use Model.
using Spectre.Console; // To use Table.
using System.Diagnostics; // To use Stopwatch.

// Default port for the Ollama API is 11434.
string port = "11434";
Uri uri = new($"http://localhost:{port}");

OllamaApiClient ollama = new(uri);

Table table = new();
table.AddColumn("Name");
table.AddColumn("Size");

// Get the list of models.
IEnumerable<Model> models = await ollama.ListLocalModels();
foreach (Model model in models)
{
  table.AddRow(model.Name, model.Size.ToString("N0"));
}

AnsiConsole.Write(table);

string modelName = "llama3:latest";

WriteLine();
WriteLine($"Selected model: {modelName}");
ollama.SelectedModel = modelName;

Write("Please enter your prompt: ");
string? prompt = ReadLine();
if (string.IsNullOrWhiteSpace(prompt))
{
  WriteLine("Prompt is required. Exiting the app.");
  return;
} 

Stopwatch timer = Stopwatch.StartNew();

ConversationContext context = new([]);
context = await ollama.StreamCompletion(
  prompt, context, stream => Write(stream.Response));

timer.Stop();

WriteLine();
WriteLine();
WriteLine($"Elapsed time: {timer.ElapsedMilliseconds:N0} ms");
