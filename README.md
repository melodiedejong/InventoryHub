# InventoryHub

A simple inventory management sample built with a Blazor WebAssembly front-end and a .NET Minimal API back-end.  
It demonstrates clean separation of concerns, shared data models, response compression, caching, error handling, and interactive Swagger docs.

---

## Table of Contents

- [Features](#features)  
- [Solution Structure](#solution-structure)  
- [Reflections on Copilot Use](#reflections-on-copilot-use)  
- [Getting Started](#getting-started)  
- [Running the App](#running-the-app)  
- [Key Technologies](#key-technologies)  
- [Contributing](#contributing)  
- [Future Roadmap](#future-roadmap)  
- [GitHub Copilot Credits](#github-copilot-credits)  

---

## Features

- 🚀 **Fast Minimal API**: .NET 7 minimal-API endpoints for CRUD operations  
- 🌐 **Blazor WASM Client**: Single-page app to list products, with built-in error handling  
- 📦 **Shared Models**: Single source of truth for `Product` & `Category` types  
- 🛡️ **CORS, Compression & Caching**  
  - Allows Blazor client to call the API  
  - Gzip & Brotli response compression  
  - 30-second client-side caching via HTTP headers  
- 🐞 **Global Error Handling**: Developer exception page in Dev, ProblemDetails endpoint in Prod  
- 📄 **Swagger / OpenAPI**: Interactive API docs in Development  

---

## Solution Structure

InventoryHub.sln
├── Shared
│ └── Models
│ ├── Category.cs
│ └── Product.cs
├── Server
│ ├── Services
│ │ └── ProductService.cs
│ └── Program.cs
└── Client
├── Pages
│ └── FetchProducts.razor
├── Services
│ └── ProductClient.cs
└── Program.cs

yaml
Copy
Edit

---

## Reflections on Copilot Use

### ✅ Summary of Use

| Task | Completed with Copilot |
|------|------------------------|
| Generated and refined front-end/back-end integration code | ✅ |
| Debugged and resolved integration issues | ✅ |
| Created and implemented JSON structures for API communication | ✅ |
| Optimized integration code for performance | ✅ |
| Included reflective summary | ✅ |

---

### 💡 Reflections

**Integration Support**  
Copilot accelerated the process of building integration between the Blazor client and the Minimal API by scaffolding `HttpClient` calls, proposing the use of typed clients, and encouraging consistent JSON serialization strategies with `GetFromJsonAsync`.

**Debugging Help**  
Common integration issues like CORS errors and JSON deserialization bugs were flagged and fixed with Copilot's suggestions. It correctly diagnosed shadowing bugs, suggested `Console.WriteLine` debugging, and led to the right use of `AddCors`.

**JSON Modeling**  
It helped define and refine the structure of the JSON payloads by recommending nested models (`Category`) and init-only, constructor-based POCOs. Moving the models into a shared project was also its suggestion, ensuring consistency across client and server.

**Performance Optimization**  
Copilot recommended meaningful improvements such as Gzip/Brotli response compression, response caching, and fluent API setup. These were straightforward to implement and yielded immediate performance wins with minimal code changes.

**Learning Outcome**  
This project taught me to treat Copilot as a collaborative developer—it excels at setting up scaffolding, identifying pitfalls, and offering incremental improvements. The key to success was refining its suggestions and layering them strategically into the project.

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)  
- Visual Studio 2022 / VS Code / JetBrains Rider  
- Optional: `git` CLI  

### Clone & Build

```bash
git clone https://github.com/your-org/InventoryHub.git
cd InventoryHub
dotnet build
Running the App
Start the API Backend
bash
Copy
Edit
cd Server
dotnet run
Listens on https://localhost:5001 (HTTPS) and http://localhost:5000 (HTTP).

Start the Blazor WASM Client
bash
Copy
Edit
cd ../Client
dotnet run
Serves at https://localhost:5238.

Browse the UI
Open your browser to https://localhost:5238/fetchproducts to view your product catalog.

Key Technologies
.NET 7 / C# 11

ASP.NET Core Minimal APIs

Blazor WebAssembly

System.Text.Json with source-gen options

Response Compression & Caching Middleware

Swagger / Swashbuckle

Contributing
Fork the repo

Create a feature branch (git checkout -b feature/my-awesome-feature)

Commit your changes & push

Open a Pull Request – we’ll review together!

Future Roadmap
✅ Complete initial List (GET) endpoint
🔄 Add full CRUD: POST, PUT, DELETE with validation
🔍 Implement filtering, sorting & paging parameters
💾 Swap in EF Core + SQL Server or SQLite backend
📊 Build dashboards for stock analytics
🚧 Enhance client resiliency with Polly-based retries

GitHub Copilot Credits
I leveraged GitHub Copilot extensively to bootstrap and refine this solution:

Project Scan-up: Generated initial minimal-API boilerplate (CORS, Swagger, Endpoints)

Service Layer: Suggested encapsulating mock data in ProductService, centralizing Category instances

Compression & Caching: Recommended response-compression middleware and [ResponseCache] metadata

Error Handling: Guided setup of DeveloperExceptionPage / ExceptionHandler and the global /error ProblemDetails endpoint

Client Fetch: Scaffolded OnInitializedAsync, JSON (de)serialization settings, and robust error-handling logic in FetchProducts.razor

Thank you, Copilot, for accelerating my development journey! 
