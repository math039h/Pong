using Godot;

namespace Pong;

public partial class ExitButton : Button
{
	private void OnPressed()
	{
		GD.Print("PlayButton pressed! Loading scene...");
		GetTree().Quit();
	}
}
