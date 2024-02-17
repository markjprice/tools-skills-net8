using Microsoft.EntityFrameworkCore; // To use Include.
using Northwind.EntityModels; // To use NorthwindContext.
using System.Text.Json; // To use JsonSerializer.

partial class Program
{
  private static string GetAuthorBiography()
  {
    return """
Mark J Price is a former Microsoft Certified Trainer (MCT) and current 
Microsoft Specialist: Programming in C# and Architecting Microsoft 
Azure Solutions, with more than 20 years' of educational and 
programming experience. 

Since 1993 Mark has passed more than 80 Microsoft programming exams 
and specializes in preparing others to pass them too. His students 
range from professionals with decades of experience to 16-year-old 
apprentices with none. Mark successfully guides all of them by 
combining educational skills with real-world experience consulting 
and developing systems for enterprises worldwide. 

Between 2001 and 2003 Mark was employed full-time to write official 
courseware for Microsoft in Redmond, USA. Mark's team wrote the 
first training courses for C# while it was still an early alpha 
version. While with Microsoft he taught "train-the-trainer" classes 
to get other MCTs up-to-speed on C# and .NET. 

Between 2016 and 2022, Mark created and delivered training courses 
for Optimizely's Digital Experience Platform, the best .NET CMS for 
Digital Marketing and E-commerce. 

In 2010 Mark studied for a Post-Graduate Certificate in Education 
(PGCE). He taught GCSE and A-Level mathematics in two London 
secondary schools. Mark holds a Computer Science BSc. Hons. Degree 
from the University of Bristol, UK.

Mark J Price has authored the following books:
- C# 6 and .NET Core 1.0 – Modern Cross-Platform Development, 
1st Edition, 2016
- C# 7 and .NET Core – Modern Cross-Platform Development, 
2nd Edition, 2017
- C# 7.1 and .NET Core 2.0 – Modern Cross-Platform Development, 
3rd Edition, 2017
- C# 8.0 and .NET Core 3.0 – Modern Cross-Platform Development, 
4th Edition, 2019
- C# 9 and .NET 5 – Modern Cross-Platform Development, 
5th Edition, 2020
- C# 10 and .NET 6 – Modern Cross-Platform Development, 
6th Edition, 2021
- C# 11 and .NET 7 – Modern Cross-Platform Development Fundamentals, 
7th Edition, 2022
- Apps and Services with .NET 7, 1st Edition, 2022
- C# 12 and .NET 8 – Modern Cross-Platform Development Fundamentals, 
8th Edition, 2023
- Apps and Services with .NET 8, 2nd Edition, 2023
""";
  }

  // It is more efficient to cache this than create it every time.
  private static JsonSerializerOptions jsonSerializerOptions = 
    new() { WriteIndented = true };

  private static string GetProductsInCategory(string categoryName)
  {
    using NorthwindContext db = new();

    var products = db.Products
      .Include(p => p.Category)
      .Where(p => p.Category!.CategoryName == categoryName)
      .Select(p => new
      {
        p.ProductId,
        p.ProductName,
        p.Category!.CategoryName,
        p.UnitPrice,
        p.UnitsInStock,
        p.UnitsOnOrder,
        p.Discontinued
      })
      .ToArray();

    // Convert the array of products to a JSON string.
    string json = JsonSerializer.Serialize(
      products, jsonSerializerOptions);

    return json;
  }
}
