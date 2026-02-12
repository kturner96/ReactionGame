var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var entries = new List<ScoreEntry>();

app.MapGet("/scores", () =>
{
    return Results.Ok(entries);
});

app.MapPost("/scores", (AddScoreRequest request) =>
{
    entries.Add(new ScoreEntry(request.name, request.score));
    return Results.Created("/scores", request);
});

app.Run();

record AddScoreRequest(string name, int score);
record ScoreEntry(string name, int score);
