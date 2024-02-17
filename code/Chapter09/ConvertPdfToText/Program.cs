using UglyToad.PdfPig.Content; // To use Page, Word.
using UglyToad.PdfPig; // To use PdfDocument.

string pdfFolder = "PDFs";
string txtFolder = "TextPages";

string pathImport;
string pathExport;

string dir = Environment.CurrentDirectory;

if (dir.EndsWith("net8.0"))
{
  // In the <project>\bin\<Debug|Release>\net8.0 directory.
  pathImport = Path.Combine("..", "..", "..", pdfFolder);
  pathExport = Path.Combine("..", "..", "..", txtFolder);
}
else
{
  // In the <project> directory.
  pathImport = pdfFolder;
  pathExport = txtFolder;
}

// Convert to absolute paths.
pathImport = Path.GetFullPath(pathImport);
pathExport = Path.GetFullPath(pathExport);

string[] pdfFiles = Directory.GetFiles(pathImport, searchPattern: "*.pdf");

foreach (string filePath in pdfFiles)
{
  string fileName = Path.GetFileName(filePath);
  WriteLine($"Processing {fileName}...");

  // For Packt book PDFs, the first part of the filename
  // (up to the first hyphen) is the ISBN.
  string isbn = fileName[..fileName.IndexOf('-')];

  using PdfDocument document = PdfDocument.Open(filePath);

  int pageNumber = 1;

  foreach (Page page in document.GetPages())
  {
    using StreamWriter writer = File.CreateText(
      Path.Combine(pathExport,
        $"{isbn}-page-{pageNumber:D4}.txt"));

    // page.Text does not have spaces between words, so    
    // write each word in the page separated by space.
    foreach(Word word in page.GetWords())
    {
      writer.Write(word.Text);
      writer.Write(' ');
    }

    writer.Flush();
    writer.Close();

    pageNumber++;
  }
}

