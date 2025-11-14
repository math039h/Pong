using System.Threading.Tasks;
using Godot;

namespace Pong;

public partial class GoalZonePlayerTwo : Area2D
{
	private int PlayerOneScore { get; set; } = 0;
	private Label _playerOneScore;
	private Ball _ball;
	private Staller _staller;
	private Vector2 _startPosition = new(576, 320);
	private Vector2 _startVelocity = new(-300, 50);

	public override void _Ready()
	{
		_playerOneScore = GetNode<Label>("/root/Node2D/PlayerOneScore");
		_ball = GetNode<Ball>("/root/Node2D/RigidBody2D");

		_staller = new Staller();
		AddChild(_staller);
	}

	private void OnGoalEntered(Node2D node2D)
	{
		if (node2D is RigidBody2D)
		{
			Goal.Update("two", _playerOneScore);
			_ball.LinearVelocity = Vector2.Zero;
			_ball.Teleport(_startPosition);
			_ball.Freeze = true;
			_staller.Stall(2, () =>
			{
				_ball.Freeze = false;
				_ball.SetVelocity(_startVelocity);
			});
		}
	}
}
