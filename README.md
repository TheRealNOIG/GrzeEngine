# GrzeEngine

## How To Setup A New Project
Firstly, download all dependence using Nuget through Giawa's OpenGL Repo `Install-Package Giawa.OpenGL`

Than, replace the `OpenGL.dll` & `OpenGL.Platform.dll` with the DLL's in the `~/Lib` folder due to the Nuget ones being outdated. (Also due to fixes that have not been merged into Giawa Master branch)

Finally, move `SDL2.dll`, found in `~/Lib`, into your output build directory. (Alternatively, place the dll into the root project folder and set it to `Copy if newer` in your IDE)

## Skeleton Window Class

```C#
class Window : GrzeEngine.Engine.Core.Window
{
    public Window(int width, int height) :base(width, height)
    {
        Initialize(this.width, this.height);
        StartLoop();
        CleanUp();
    }
    public override void Initialize(int width, int height)
    {
        base.Initialize(width, height);
    }
    public override void OnRender()
    {
        base.OnRender();
        //Render Code Here
        SwapBuffers();
    }
    public override void OnUpdate() {}
    public override void CleanUp() {}
}
```
