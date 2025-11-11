using Godot;

namespace Pong;

public partial class Ball : RigidBody2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area2D");
		area.BodyEntered += DoSomething;
		if (area.HasMethod("_on_area_2d_body_entered"))
		{
			//area.Trigger
		}
	}

	private void DoSomething(Node2D node)
	{
		QueueFree();
		if (node is RigidBody2D)
		{
			GD.Print("Deleting object!");
			QueueFree();
		}
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
