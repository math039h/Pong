using Godot;

namespace Pong;

public partial class Goal : Node2D
{
    private static int PlayerOneScore { get; set; } = 0;
    private static int PlayerTwoScore { get; set; } = 0;
    
    public static void Update(string goalZone, Label score)
    {
        if (goalZone == "one")
        {
            PlayerTwoScore++;
            score.Text = PlayerTwoScore.ToString();
        }
        else if (goalZone == "two")
        {
            PlayerOneScore++;
            score.Text = PlayerOneScore.ToString();
        }
    }
}