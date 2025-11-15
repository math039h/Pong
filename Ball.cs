using Godot;

namespace Pong;

public partial class Ball : RigidBody2D
{
	private bool _shouldTeleport = false;
	private bool _shouldSetVelocity = false;
	private Vector2 _targetPosition;
	private Vector2 _targetVelocity;
	private Vector2 _startPosition = new(576, 320);
	private Vector2 _startVelocity = new(-300, 50);

	public void Teleport(Vector2 position = default)
	{
		if (position == default)
			position = new Vector2(576, 320);
		
		_targetPosition = position;
		_shouldTeleport = true;
	}

	public void SetVelocity()
	{
		_shouldSetVelocity = true;
		_targetVelocity = _startVelocity;
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
