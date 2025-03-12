using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

var history = new List<string>();

app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync(Path.Combine(app.Environment.WebRootPath, "index.html"));
});

app.MapGet("/add", (HttpContext context) =>
{
    if (!double.TryParse(context.Request.Query["a"], out double a))
    {
        return Results.BadRequest("Invalid value for parameter 'a'.");
    }

    if (!double.TryParse(context.Request.Query["b"], out double b))
    {
        return Results.BadRequest("Invalid value for parameter 'b'.");
    }

    var result = a + b;
    history.Add($"{a} + {b} = {result}");
    return Results.Ok(result);
});

app.MapGet("/subtract", (HttpContext context) =>
{
    if (!double.TryParse(context.Request.Query["a"], out double a))
    {
        return Results.BadRequest("Invalid value for parameter 'a'.");
    }

    if (!double.TryParse(context.Request.Query["b"], out double b))
    {
        return Results.BadRequest("Invalid value for parameter 'b'.");
    }

    var result = a - b;
    history.Add($"{a} - {b} = {result}");
    return Results.Ok(result);
});

app.MapGet("/multiply", (HttpContext context) =>
{
    if (!double.TryParse(context.Request.Query["a"], out double a))
    {
        return Results.BadRequest("Invalid value for parameter 'a'.");
    }

    if (!double.TryParse(context.Request.Query["b"], out double b))
    {
        return Results.BadRequest("Invalid value for parameter 'b'.");
    }

    var result = a * b;
    history.Add($"{a} * {b} = {result}");
    return Results.Ok(result);
});

app.MapGet("/divide", (HttpContext context) =>
{
    if (!double.TryParse(context.Request.Query["a"], out double a))
    {
        return Results.BadRequest("Invalid value for parameter 'a'.");
    }

    if (!double.TryParse(context.Request.Query["b"], out double b))
    {
        return Results.BadRequest("Invalid value for parameter 'b'.");
    }

    if (b == 0)
    {
        return Results.BadRequest("Division by zero is not allowed.");
    }

    var result = a / b;
    history.Add($"{a} / {b} = {result}");
    return Results.Ok(result);
});

app.MapGet("/history", () => Results.Ok(history));
app.MapDelete("/history", () =>
{
    history.Clear();
    return Results.Ok();
});


app.Run();