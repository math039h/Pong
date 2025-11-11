using Godot;

namespace Pong;

public partial class Sprite2d : Sprite2D
{
	private Sprite2d _sprite2d;

	private Vector2 _sprite2dPosition;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("move_up"))
		{
			_sprite2dPosition = _sprite2d.Position;
			var sprite2dPosition = _sprite2dPosition;
			sprite2dPosition.Y += 2 * (float)delta;
		}
		else if (Input.IsActionPressed("move_down"))
		{
			_sprite2dPosition = _sprite2d.Position;
			var sprite2dPosition = _sprite2dPosition;
			sprite2dPosition.Y += 2 * (float)delta;
		}
	}
	
	[Export] public int Speed = 200;

	private Vector2 _velocity = new Vector2();

	public void GetInput()
	{
		_velocity = new Vector2();
		if (Input.IsActionPressed("right"))
		{
			_sprite2d._sprite2dPosition.X += 1;
		}
		if (Input.IsActionPressed("left"))
		{
			_sprite2d._sprite2dPosition.X -= 1;
		}
		if (Input.IsActionPressed("Down"))
		{
			_sprite2d._sprite2dPosition.Y += 1;
		}
		if (Input.IsActionPressed("Up"))
		{
			_sprite2d._sprite2dPosition.Y -= 1;
		}
		_velocity = _velocity.Normalized() * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
	}
}

public partial class Movement : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;

	public void GetInput()
	{

		Vector2 inputDirection = Input.GetVector("left", "right", "Up", "Down");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
