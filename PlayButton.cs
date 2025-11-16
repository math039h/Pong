using Godot;

namespace Pong;

public partial class PlayButton : Button
{
	private void OnPressed()
	{
		GD.Print("PlayButton pressed! Loading scene...");
		GetTree().ChangeSceneToFile("res://MainScene.tscn");
	}
}
