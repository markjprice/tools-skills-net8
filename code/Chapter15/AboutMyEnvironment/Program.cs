using Spectre.Console; // To use Table.

EnvironmentLib.EnvironmentInfo info = new();

Table t = new();
t.AddColumn("Property");
t.AddColumn("Value");

t.AddRow("User", info.UserName);
t.AddRow("Host", info.HostName);
t.AddRow("OS", info.OS);
t.AddRow("Architecture", info.Architecture);
t.AddRow("Platform", info.DotNet);
t.AddRow("Processors", info.Processors.ToString());
t.AddRow("In a container", info.InContainer.ToString());

AnsiConsole.Write(t);

WriteLine("I will output the time every five seconds.");
WriteLine("Press Ctrl + C to stop.");

while (true)
{
  await Task.Delay(TimeSpan.FromSeconds(5));
  WriteLine(DateTime.Now.ToLongTimeString());
}
