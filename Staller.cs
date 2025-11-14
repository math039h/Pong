using System;
using Godot;

namespace Pong;

public partial class Staller : Node
{
    public void Stall(float seconds, Action callback)
    {
        Timer timer = new Timer();
        timer.WaitTime = seconds;
        timer.OneShot = true;

        timer.Timeout += () =>
        {
            callback?.Invoke();
            timer.QueueFree();
        };

        AddChild(timer);
        timer.Start();
    }
}