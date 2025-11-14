using Godot;

namespace Pong;

public partial class GoalZonePlayerOne : Area2D
{
	private Label _playerTwoScore;
	private Ball _ball;
	private Staller _staller;
	private Goal _goal = new();

	public override void _Ready()
	{
		_playerTwoScore = GetNode<Label>("/root/Node2D/PlayerTwoScore");
		_ball = GetNode<Ball>("/root/Node2D/RigidBody2D");

		_staller = new Staller();
		AddChild(_staller);
	}

	private void OnGoalEntered(Node2D node2D)
	{
		if (node2D is RigidBody2D)
		{
			_goal.Scored("one",  _playerTwoScore, _ball, _staller);
		}
	}
}
