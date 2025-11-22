using Godot;

namespace Pong;

public partial class Goal : Area2D
{
    private static int PlayerOneScore { get; set; } = 0;
    private static int PlayerTwoScore { get; set; } = 0;
    private bool IsGameOver { get; set; }
    private Ball _ball;
    private Staller _staller;
    private PlayAgainButton _playAgainButton;

    public void Scored(string goalZone, Label updateScore, Ball ball, Staller staller, Label winnerLabel, PlayAgainButton playAgainButton)
    {
        Update(goalZone, updateScore);
        GameOver(winnerLabel, playAgainButton);
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

    private void GameOver(Label winnerLabel, PlayAgainButton playAgainButton)
    {
        if (PlayerOneScore == 3)
        {
            IsGameOver = true;
            winnerLabel.Text = "Player 1 won!";
            playAgainButton.Show();
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }
        else if (PlayerTwoScore == 3)
        {
            IsGameOver = true;
            winnerLabel.Text = "Player 2 won!";
            playAgainButton.Show();
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }
    }

    private void ResetBall(Ball ball, Staller staller)
    {
        ball.LinearVelocity = Vector2.Zero;
        ball.Teleport();
        ball.Freeze = true;
        if (IsGameOver)
        {
            ball.Teleport(new Vector2(1165, 0));
            return;
        }
        staller.Stall(2, () =>
        {
            ball.Freeze = false;
            ball.SetVelocity();
        });
    }
}