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

```
InventoryHub.sln
├── Shared
│   └── Models
│       ├── Category.cs
│       └── Product.cs
├── Server
│   ├── Services
│   │   └── ProductService.cs
│   └── Program.cs
└── Client
    ├── Pages
    │   └── FetchProducts.razor
    ├── Services
    │   └── ProductClient.cs
    └── Program.cs
```

---

## Reflective Summary: Using GitHub Copilot in InventoryHub

### How Copilot Assisted Development
GitHub Copilot was instrumental throughout the development of InventoryHub, especially in the following areas:
API Integration: Copilot generated scaffolding for calling the /api/products endpoint in the Blazor WebAssembly frontend. It helped simplify deserialization using GetFromJsonAsync and encouraged best practices such as cancellation tokens and typed HTTP clients.
CORS and Debugging: When facing CORS errors during API calls, Copilot suggested the exact configuration to add in Program.cs, including how to define and apply a CORS policy tailored to the frontend’s origin.
Response Compression and Caching: It recommended enabling AddResponseCompression() and AddResponseCaching() to improve payload efficiency and performance. Copilot also suggested how to annotate the endpoint with ResponseCacheAttribute for browser caching.
JSON Structuring: Copilot guided the evolution of in-memory mock data to include nested category objects and helped refactor them into a shared model. It proposed converting to strongly typed models and eventually to init-only constructor-based types for immutability and clarity.
Code Optimization: It identified and eliminated redundant logic in the ProductService using centralized Category definitions and concise C# 9 object initialization. Copilot also proposed a fully fluent style for Program.cs, improving readability and modularity.

### Challenges and How Copilot Helped
Initial CORS Failures: The frontend failed to reach the backend due to missing headers. Copilot diagnosed the issue from the error and suggested the necessary CORS setup with correct origins and middleware placement.
Null Product List: Early bugs stemmed from local variable shadowing and deserialization mismatches. Copilot helped spot these issues by recommending assignment to the correct field and adding helpful console debugging.
Constructor Errors: When transitioning models to constructor-based init-only properties, Copilot assisted in updating initialization logic and resolving missing argument errors with clear explanations.
Performance Bottlenecks: As product volume increased, Copilot introduced response compression and caching concepts that significantly improved perceived load times with minimal code.

###What I Learned About Using Copilot Effectively
Using Copilot in a full-stack Blazor + Minimal API project taught me:
Prompts Matter: Clear, task-specific prompts like "Add response compression to .NET minimal API" yield highly relevant suggestions.
Copilot as a Partner: Copilot excels when treated as a pair programmer—great for kickstarting boilerplate, surfacing overlooked bugs, and suggesting clean refactors.
Prune and Polish: While Copilot provides solid starting points, refining its suggestions to match architectural and formatting standards is still essential.
Iterative Workflow: By iteratively layering Copilot’s suggestions (e.g., from manual API calls to typed clients, from raw objects to records), I was able to improve both performance and maintainability with minimal churn.
Overall, Copilot proved to be an efficient and reliable coding assistant, especially for tasks like middleware setup, API design, and frontend integration in a modern .NET full-stack app.


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
```

---

## Running the App

### Start the API Backend

```bash
cd Server
dotnet run
```

Listens on:

- https://localhost:5001 (HTTPS)  
- http://localhost:5000 (HTTP)

### Start the Blazor WASM Client

```bash
cd ../Client
dotnet run
```

Serves at:  
https://localhost:5238

### Browse the UI

Open your browser to:  
https://localhost:5238/fetchproducts

---

## Key Technologies

- .NET 7 / C# 11  
- ASP.NET Core Minimal APIs  
- Blazor WebAssembly  
- System.Text.Json with source-gen options  
- Response Compression & Caching Middleware  
- Swagger / Swashbuckle  

---

## Contributing

1. Fork the repo  
2. Create a feature branch:  
   ```bash
   git checkout -b feature/my-awesome-feature
   ```
3. Commit your changes & push  
4. Open a Pull Request – we’ll review it together!  

---

## Future Roadmap

- ✅ Complete initial List (GET) endpoint  
- 🔄 Add full CRUD: POST, PUT, DELETE with validation  
- 🔍 Implement filtering, sorting & paging parameters  
- 💾 Swap in EF Core + SQL Server or SQLite backend  
- 📊 Build dashboards for stock analytics  
- 🚧 Enhance client resiliency with Polly-based retries  

---

## GitHub Copilot Credits

I leveraged GitHub Copilot extensively to bootstrap and refine this solution:

- **Project Scan-up**: Generated initial minimal-API boilerplate (CORS, Swagger, Endpoints)  
- **Service Layer**: Suggested encapsulating mock data in `ProductService`, centralizing `Category` instances  
- **Compression & Caching**: Recommended response-compression middleware and `[ResponseCache]` metadata  
- **Error Handling**: Guided setup of `DeveloperExceptionPage`, global `/error` handler, and fallback behavior  
- **Client Fetch**: Scaffolded `OnInitializedAsync`, `GetFromJsonAsync`, and error handling logic in `FetchProducts.razor`  

💡 Thank you, Copilot, for accelerating my development journey! 🚀
