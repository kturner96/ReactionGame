using System.Net;
using System.Text;
using System.Text.Json;

namespace Requests;

public static class LeaderboardRequests
{
    private static readonly HttpClient LeaderboardClient = new()
    {
        BaseAddress = new Uri("http://localhost:5092")
    };

    public static async Task PostScores(int score, string username)
    {
        var payload = new { name = username, score };

        using var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json"
        );

        using var response = await LeaderboardClient.PostAsync("/scores", content);
        response.EnsureSuccessStatusCode();
    }

    public static async Task<List<ScoreEntry>?> GetScores()
    {
        var response = await LeaderboardClient.GetAsync("/scores");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<ScoreEntry>>(json);
    }
}

public record ScoreEntry(string name, int score);