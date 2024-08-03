**Improvements** (1 item)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net8/issues) or email me at markjprice (at) gmail.com.

- [Page 24 - Setting up SQL Server and the Northwind database](#page-24---setting-up-sql-server-and-the-northwind-database)

# Page 24 - Setting up SQL Server and the Northwind database

> Thanks to `CoericK` for asking a question in the book's Discord channel that prompted this improvement item.

`@CoericK`: "Hello @markjprice , I have a question, I'm running MacOS Catalina, according to your suggestions on page 24, your recommend to install Azure SQL Edge container for linux (i assume macos as well), https://github.com/markjprice/tools-skills-net8/blob/main/docs/sql-server/edge.md, however I already have an existing docker container running this image as base mcr.microsoft.com/mssql/server:2022-latest and installing mssqlserver via apt-get  apt-get install -y mssql-server-fts, can I just use my existing container? or would it be better to follow along your instructions for this book using Azure SQL Edge?"

`@markjprice`: "You can use your existing container. Just be aware that the SQL script will create a database named `Northwind` in a schema named `dbo`. That shouldn't be an issue or conflict with any existing SQL objects that you have. I say to use SQL Edge partly to provide extra separation between what you'll do in the book, and what you might already have. "Use at your own risk." as they say. 🙂 You sound like you know what you're doing."

`@CoericK`: "Thanks Mark, I think that I will create an azure sql edge container, and run it at a different port, I assume I will have to customize the conection port where required"

`@CoericK`: "created it on port 1434, worked like a charm. I'm using Azure Data Studio on MacOS btw"

`@CoericK`: "i used this tool to generate the connection string https://www.aireforge.com/tools/sql-server-connection-string-generator"

`@automaton`: "My issue was with the Trust certificate in the connection string, something that isn't prompted necessarily though the VSCode extension."

`@CoericK`: "I'm on mac, So in order to follow along the guide I had to create a virtual machine with windows install visual studio a connect to thee db in the host machine, since I'm using SQL Server Edge I had to run this command to get the classes created on page 28
 `dotnet ef dbcontext scaffold "Data Source=HOSTNAME,PORT;Integrated Security=false;User ID=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;Initial Catalog=Northwind;" Microsoft.EntityFrameworkCore.SqlServer --namespace Northwind.EntityModels --data-annotations`"

In the next edition, *Tools and Skills for .NET 10*, I will add notes about how to use existing SQL Server instances, how to customize the port number to avoid conflicts with existing container images, and tools like Azure Data Studio and websites for generating database connection strings. I will also add a note about trusting the certificate in the connection string too.
