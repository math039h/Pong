using Godot;

namespace Pong;

public partial class PlayAgainButton : Button
{

	private void OnPressed()
	{
		GD.Print("Button pressed! Loading scene...");
		GetTree().ChangeSceneToFile("res://MainScene.tscn");
	}
}
