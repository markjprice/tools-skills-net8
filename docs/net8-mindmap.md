# What does a modern C# and .NET 8 developer need to know?

## .NET 8 overview
```mermaid
mindmap
  root((.NET 8))
    C# language
    .NET libraries
    Web development
    Apps
    Services
    Tools
    Skills
```

## C# language detail
```mermaid
mindmap
  root((C#))
    Variables
    Data types
    Controlling flow
    Converting types
    Handling exceptions
    Writing functions
    Debugging
    Unit testing
    Object-oriented programming
      Defining types
        Fields
        Properties
        Methods
        Operators
        Delegates
        Events
      Implementing interfaces
      Inheritance
```

## .NET libraries detail
```mermaid
mindmap
    root((.NET APIs))
      .NET class libraries
        Publishing NuGet packages
        Native AOT
        Decompiling assemblies
      Common types
        Collections
        Regular expressions
      File I/O
        Serialization
          JSON
          XML
      Entity Framework Core
        Queries
        Changes
      LINQ
        Deferred queries
        Scalar
      Specialized libraries
        Internationalization
          NodaTime
        Third-party libraries
          QuestPDF
          AutoMapper
          FluentValidation
```

## Web development detail
```mermaid
mindmap
  root((Web))
    Core
      HTTP
      HTML
      CSS
      JavaScript
    ASP.NET Core
      Configuration
        HTTP pipelines
        Service containers
      Razor
      MVC
    Caching
      Output caching
      Response caching
      Object caching
    Blazor
      Full Stack
      WebAssembly
```

## Apps detail
```mermaid
mindmap
  root((Apps))
    .NET MAUI
      Mobile
        iPhone
        Android
      Desktop
        Windows
        MacOS Catalyst
    Blazor WebAssembly
    Third-party
      Avalonia
      Uno
    Windows
      WinForms
      WPF
      WinUI 3
```

## Services detail
```mermaid
mindmap
  root((Services))
    Web services
      ASP.NET Core 
        Web API with controllers
        Minimal APIs
        OData
    GraphQL
      HotChocolate
    Nanoservices
      Azure Functions
    Realtime & broadcast
      SignalR
    Microservices
      gRPC
    Common features
      Distributed caching
      Queuing
        RabbitMQ
```

## Tools detail
```mermaid
mindmap
  root((Tools))
    Code editor tools
      Code snippets
      Editor config
    Visual Studio
      Tasks
    Visual Studio Code
      Extensions
    Debuggers
      Memory usage
```

## Skills detail
```mermaid
mindmap
  root((Skills))
    Debugging
    Documenting
      DoxFX
      Mermaid
    ChatGPT

```

## Graph used for a "mind map"

```mermaid
graph LR
    A[.NET 8 professional 2024] --> B(General Development)
    A --> C[.NET Frameworks and Platforms]
    A --> D[Web Development]
    A --> E[Databases]
    A --> F[Cloud Services]
    A --> G[DevOps and Version Control]
    A --> H[Testing and Quality Assurance]
    A --> I[Development Principles and Practices]
    A --> J[Security]
    A --> K[Performance and Optimization]
    A --> L[Continuous Learning]

    B --> B1(Git)
    B --> B2(Getting Help)
    B --> B3(Documentation)

    C --> C1(.NET Core / .NET 5+)
    C --> C2(ASP.NET Core)
    C --> C3(Entity Framework Core)
    C --> C4(Blazor)

    D --> D1(HTML)
    D --> D2(CSS)
    D --> D3(JavaScript)
    D --> D4(HTTP, TLS)

    E --> E1(SQL Server)
    E --> E2(NoSQL Databases)
    E --> E3(EF Core Migrations)

    F --> F1(Azure)
    F --> F2(AWS)

    G --> G1(Git)
    G --> G2(GitHub / Azure DevOps)
    G --> G3(Docker)
    G --> G4(Kubernetes)

    H --> H1(Unit Testing)
    H --> H2(Integration Testing)
    H --> H3(Mocking Frameworks)

    I --> I1(SOLID Principles)
    I --> I2(Design Patterns)
    I --> I3(Agile and Scrum)

    J --> J1(Authentication and Authorization)
    J --> J2(Data Protection)
    J --> J3(OWASP Top 10)

    K --> K1(Caching)
    K --> K2(Profiling Tools)
    K --> K3(Best Practices)

    L --> L1(Community Engagement)
    L --> L2(Experimentation)
    L --> L3(Cross-disciplinary Skills)

    B1 --> B1A(GitHub)
    B1 --> B1B(Git UI Tools)

    B2 --> B2A(Microsoft Learn)
    B2 --> B2B(dotnet CLI help)
    B2 --> B2C(ChatGPT)

    B3 --> B3A(DocFX)
    B3 --> B3B(Mermaid)

    D3 --> D3A(React)
    D3 --> D3B(Angular)
    D3 --> D3C(Vue.js)
    
    E2 --> CosmosDB
```


## Graph showing variety of elements and custom styling
```mermaid
graph TD
    %% Define the root node
    A[Root Node] -->|Link Text| B(Child Node 1)
    A --> C{Child Node 2}
    A --> D[Child Node 3]
    
    %% Branching out from Child Node 1
    B --> B1[Grandchild 1.1]
    B --> B2(Grandchild 1.2)
    %% Dashed line without arrow
    B -.- B3{Grandchild 1.3} 
    
    %% Branching out from Child Node 2, with different arrow types
    C -->|Solid Line| C1[Grandchild 2.1]
    C -.->|Dashed Line| C2(Grandchild 2.2)
    
    %% Branching out from Child Node 3, showcasing styling
    D --> D1[Grandchild 3.1]
    D --> D2[Grandchild 3.2]
    D --> D3[Grandchild 3.3]
    
    %% Applying styles
    class B,C,D specialStyle;
    class B1,B2,B3,C1,C2,D1,D2,D3 endStyle;
    
    %% Defining styles
    classDef specialStyle fill:#f9f,stroke:#333,stroke-width:2px;
    classDef endStyle fill:#bbf,stroke:#f66,stroke-width:2px,stroke-dasharray: 5, 5;
```
