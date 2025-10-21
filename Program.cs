var builder = WebApplication.CreateBuilder(args);

// Configure to listen on HTTP only for simplicity
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5294);
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    // Check for the presence of "secure=true" query parameter, https simulation
    if (context.Request.Query["secure"] != "true")
    {
        // Block the request as if it were non-HTTPS
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Simulated HTTPS required.");
      
    }

    // If secure=true is present, continue to next middleware
    await next();
});

app.Use(async(context, next) =>
{
    var input = context.Request.Query["input"];
  if (!IsValidInput(input))
  {
      context.Response.StatusCode = 400; // Bad Request
      await context.Response.WriteAsync("Invalid input detected.");
     
  }
  
  await next();
});

static bool IsValidInput(string? input) // Simple validation function
{
    // Add your validation logic here
    return !string.IsNullOrEmpty(input) && !input.Contains("<script>");
}

app.Run();