using Godot;

namespace Pong;

public partial class Area2dBall : Area2D
{
	private Vector2 _velocity = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_velocity = new Vector2(-300, 200);
		// var area = GetNode<Area2D>("Area2D");
		// area.BodyEntered += DoSomething;
		// if (area.HasMethod("_on_area_2d_body_entered"))
		// {
		// 	//area.Trigger
		// }
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition += _velocity * (float)delta;
	}
}
