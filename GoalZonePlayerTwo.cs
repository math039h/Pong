using Godot;

namespace Pong;

public partial class GoalZonePlayerTwo : Area2D
{
	private Label _playerOneScore;
	private Ball _ball;
	private Staller _staller;
	private Goal _goal = new();
	private Label _winnerLabel;
	private PlayAgainButton _playAgainButton;

	public override void _Ready()
	{
		_playAgainButton = GetNode<PlayAgainButton>("/root/CanvasLayer/Control/Button");
		_playerOneScore = GetNode<Label>("/root/Node2D/PlayerOneScore");
		_ball = GetNode<Ball>("/root/Node2D/RigidBody2D");
		_winnerLabel = GetNode<Label>("/root/Node2D/WinnerLabel");
		_staller = new Staller();
		AddChild(_staller);
	}

	private void OnGoalEntered(Node2D node2D)
	{
		if (node2D is RigidBody2D)
		{
			_goal.Scored("two",  _playerOneScore, _ball, _staller, _winnerLabel, _playAgainButton);
		}
	}
}
