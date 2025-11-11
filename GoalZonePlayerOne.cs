using Godot;

namespace Pong;

public partial class GoalZonePlayerOne : Area2D
{
	public override void _Ready()
	{
		var ball = GetNode<RigidBody2D>("RigidBody2D");
		ball.HasMethod("_on_area_2d_body_entered");
	}

	//Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnGoalEntered(Node2D node2D)
	{
		GD.Print("Goal entered");
		if (node2D is RigidBody2D)
		{
			GD.Print("disposing body");
			node2D.Dispose();
		}
	}

	public void _on_rigid_body_2d_body_entered(RigidBody2D body)
	{
		GD.Print("goal entered");
		QueueFree();
	}
}
