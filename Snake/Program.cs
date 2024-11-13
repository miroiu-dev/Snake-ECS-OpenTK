using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Snake;

var gameWindowSettings = GameWindowSettings.Default;
var nativeWindowSettings = NativeWindowSettings.Default;
nativeWindowSettings.Profile = ContextProfile.Compatability;
nativeWindowSettings.Title = "Snake";
nativeWindowSettings.MinimumClientSize = new OpenTK.Mathematics.Vector2i(1000, 1000);

using var game = new Game(gameWindowSettings, nativeWindowSettings);
game.Run();

