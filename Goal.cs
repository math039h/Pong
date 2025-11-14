using Godot;

namespace Pong;

public partial class Goal : Area2D
{
    private static int PlayerOneScore { get; set; } = 0;
    private static int PlayerTwoScore { get; set; } = 0;
    private Ball _ball;
    private Staller _staller;

    public void Scored(string goalZone, Label updateScore, Ball ball, Staller staller)
    {
        Update(goalZone, updateScore);
        ResetBall(ball, staller);
    }

    private static void Update(string goalZone, Label score)
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

    private void ResetBall(Ball ball, Staller staller)
    {
        ball.LinearVelocity = Vector2.Zero;
        ball.Teleport();
        ball.Freeze = true;
        staller.Stall(2, () =>
        {
            ball.Freeze = false;
            ball.SetVelocity();
        });
    }
}