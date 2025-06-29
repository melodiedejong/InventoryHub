// Server/Program.cs
/*
 * GitHub Copilot Contributions to InventoryHub Server setup:
 *   1) Registered CORS policy to allow Blazor WASM client during development.
 *   2) Enabled EndpointsApiExplorer & SwaggerGen for interactive API documentation.
 *   3) Configured response compression (Gzip & Brotli) to reduce payload sizes.
 *   4) Added response caching services to honor endpoint cache metadata.
 *   5) Streamlined all service registrations into a single fluent chain.
 *   6) Ordered middleware for optimal performance (compression → caching → CORS).
 *   7) Mapped GET /api/products and enriched it with cache metadata, endpoint naming, and OpenAPI response annotations.
*    8) Set up centralized error handling
 */

using InventoryHub.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    // Copilot suggested registering a CORS policy named "AllowBlazorClient"
    .AddCors(o => o.AddPolicy("AllowBlazorClient", p =>
         p.WithOrigins("http://localhost:5238")
          .AllowAnyHeader()
          .AllowAnyMethod()))
    // Copilot recommended enabling API explorer & Swagger for live docs
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    // Copilot suggested adding response compression to shrink JSON payloads
    .AddResponseCompression(opts =>
    {
        // Copilot suggested enable compression (gzip & brotli) also over HTTPS
        opts.EnableForHttps = true;
    })
     // Copilot proposed adding response caching services
    .AddResponseCaching();

var app = builder.Build();

//———————————————————————————————
// Copilot : Exception‐handling & Swagger
//———————————————————————————————
if (app.Environment.IsDevelopment())
{
    // detailed error pages in Development
    app.UseDeveloperExceptionPage();

    // interactive API docs
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // global exception handler in Production
    app.UseExceptionHandler("/error");
}

// Copilot-guided middleware ordering for best throughput
app.UseResponseCompression();
app.UseResponseCaching();
app.UseCors("AllowBlazorClient");

//———————————————————————————————
// Copilot Global “/error” endpoint for ProblemDetails
//———————————————————————————————
app.Map("/error", (HttpContext http) =>
{
    var feature = http.Features.Get<IExceptionHandlerFeature>();
    var exception = feature?.Error;

    // You could inject ILogger and log the exception here
    
    return Results.Problem(
        title: "An unexpected error occurred.",
        detail: app.Environment.IsDevelopment() ? exception?.StackTrace : null
    );
})
.ExcludeFromDescription(); // hide this from Swagger UI

// Copilot proposed mapping GET /api/products to the static ProductService
var getProductsEndpoint = app.MapGet("/api/products", () =>
    Results.Ok(ProductService.GetProducts())
);

// Copilot-suggested enriching the endpoint:
//  • ResponseCache metadata (Duration = 30 seconds)
//  • A friendly endpoint name for OpenAPI
//  • Declared response type for Swagger UI
getProductsEndpoint
    .WithMetadata(new ResponseCacheAttribute { Duration = 30 })
    .WithName("GetProducts")
    .Produces<IEnumerable<InventoryHub.Shared.Models.Product>>(StatusCodes.Status200OK);

app.Run();
