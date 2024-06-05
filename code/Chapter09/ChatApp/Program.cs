// Disable experimental warnings.
#pragma warning disable SKEXP0003, SKEXP0011, SKEXP0028, SKEXP0052, SKEXP0055

using Microsoft.SemanticKernel; // To use Kernel.

// To use ChatHistory and so on.
using Microsoft.SemanticKernel.ChatCompletion;

// To use OpenAIPromptExecutionSettings.
using Microsoft.SemanticKernel.Connectors.OpenAI;

using Microsoft.SemanticKernel.Memory; // To use ISemanticTextMemory.
using System.Text; // To use StringBuilder.

Settings? settings = GetSettings();
if (settings is null)
{
  WriteLine("Settings not found or not valid. Exiting the app.");
  return; // Exit the app.
}

Kernel kernel = GetKernel(settings);

// $question will be defined as an argument.
//KernelFunction function = kernel.CreateFunctionFromPrompt("""
//  Author biography: {{ authorInformation.getAuthorBiography }}.
//  {{ $question }}
//  """);

//KernelArguments arguments = new();

ConsoleKey key = ConsoleKey.A;

IChatCompletionService completion =
  kernel.GetRequiredService<IChatCompletionService>();

ChatHistory history = new(systemMessage: "You are an AI assistant based on Mark J Price's knowledge, skills, and experience.");

OpenAIPromptExecutionSettings options = new()
{ ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

// To help implement async streaming output.
StringBuilder builder = new();

while (key is not ConsoleKey.X)
{
  Write("Enter your question: ");
  string question = ReadLine()!;

  // WriteLine(await kernel.InvokePromptAsync(question));

  // arguments["question"] = question;
  // Call a single function.
  // WriteLine(await function.InvokeAsync(kernel, arguments));

  history.AddUserMessage(question);

  //ChatMessageContent answer = await 
  //  completion.GetChatMessageContentAsync(history);

  builder.Clear();
  await foreach (StreamingChatMessageContent message
    in completion.GetStreamingChatMessageContentsAsync(
      history, options, kernel))
  {
    Write(message.Content);
    builder.Append(message.Content);
  }

  history.AddAssistantMessage(builder.ToString());

  WriteLine();
  WriteLine("Press X to exit or any other key to ask another question.");
  key = ReadKey(intercept: true).Key;
}
