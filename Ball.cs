using Godot;

namespace Pong;

public partial class Ball : RigidBody2D
{
	private bool _shouldTeleport = false;
	private bool _shouldSetVelocity = false;
	private Vector2 _targetPosition;
	private Vector2 _targetVelocity;
	private Ball _ball;

	public override void _Ready()
	{
		var _ball = GetNode<Ball>("root/Node2D/RigidBody2D");
	}

	public void Teleport(Vector2 position)
	{
		_targetPosition = position;
		_shouldTeleport = true;
	}
	
	public void SetVelocity(Vector2 velocity)
	{
		_targetVelocity = velocity;
		_shouldSetVelocity = true;
	}
	
	public void TeleportAndSetVelocity(Vector2 position, Vector2 velocity)
	{
		_targetPosition = position;
		_targetVelocity = velocity;
		_shouldSetVelocity = true;
		_shouldTeleport = true;
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		if (_shouldTeleport)
		{
			state.Transform = new Transform2D(state.Transform.Rotation, _targetPosition);
			_shouldTeleport = false;
		}
		if (_shouldSetVelocity)
		{
			state.LinearVelocity = _targetVelocity;
			_shouldSetVelocity = false;
		}
	}
}
