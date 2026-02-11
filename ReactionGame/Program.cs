using Scores;

bool playerAlive = true;
int score = 0;
Random random = new();

Console.Write("Enter your name: ");
string? username;

while (true)
{
    Console.Write("Enter your name: ");
    username = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(username) && username.Length <= 24)
        break;

    Console.WriteLine("Invalid username! Must be 1–24 chars and not empty.");
}

User.Name = username;

var values = (Directions[])Enum.GetValues(typeof(Directions));


while (playerAlive)
{
    Directions randomDirection = values[random.Next(values.Length)];
    
    Console.WriteLine("Press Key: " + randomDirection);
    var pressedKey = Console.ReadKey(true);
    
    if (pressedKey.Key == (ConsoleKey)randomDirection)
    {
        score += 1;
        Console.Clear();
        User.Score = score;
    }
    else
    {
        playerAlive = false;
        Console.WriteLine("------- Leaderboard --------");
        Console.Write($"{User.Name}: - Score [{User.Score}]");
    }
}

enum Directions {Right = ConsoleKey.RightArrow, Left = ConsoleKey.LeftArrow, Up = ConsoleKey.UpArrow, Down = ConsoleKey.DownArrow }
