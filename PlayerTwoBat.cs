using Godot;

namespace Pong;

public partial class PlayerTwoBat : CharacterBody2D
{
	private const float Speed = 300.0f;
	private const float PushForce = 300;

	private void GetInput()
	{
		var inputDirection = Input.GetVector("left2", "right2", "Up2", "Down2");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);

			if (collision.GetCollider() is RigidBody2D)
			{
				var rigidBody = collision.GetCollider() as RigidBody2D;
				var pushDir = -collision.GetNormal();

				rigidBody?.ApplyCentralImpulse(pushDir * PushForce * (float)delta);
			}
		}
	}
}
