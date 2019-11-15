# GrzeEngine

## How To Setup A New Project
Firstly, download all dependence using Nuget through Giawa's OpenGL Repo `Install-Package Giawa.OpenGL.Platform`

Than, replace the `OpenGL.dll` & `OpenGL.Platform.dll` with the DLL's in the `~/Lib` folder due to the Nuget ones being outdated. (Also due to fixes that have not been merged into Giawa Master branch)

Finally, move `SDL2.dll`, found in `~/Lib`, into your output build directory. (Alternatively, place the dll into the root project folder and set it to `Copy if newer` in your IDE)

## Skeleton

```C#
class Window : GrzeEngine.Engine.Core.Window
{
    private Camera2D camera2D;
    private MasterRenderer masterRenderer;

    public Window(int width, int height) : base(width, height) {
        Initialize(this.width, this.height);
        StartLoop();
        CleanUp();
    }
    public override void Initialize(int width, int height) {
        //Setup Window & OpenGL context
        base.Initialize(width, height);
        //Init CameraType
        camera2D = new Camera2D();
        //Setup renderers and provide projection matrix size 
        masterRenderer = new MasterRenderer(this.width, this.height, camera2D);
        //Create Test Sprite
        masterRenderer.AddSprite(new Sprite(Vector2.Zero, new Vector2(10, 10), Vector2.Zero, masterRenderer.GetSpriteShader()));
    }
    public override void OnRender() {
        base.OnRender();
        //Proccess all sprites before renderering
        masterRenderer.ProcessSprite();
        //Render to screen
        masterRenderer.Render();
        //Swap rendered buffer with current screen buffer
        SwapBuffers();
    }
    public override void OnUpdate() {
        float delta = clock.delta();
        //Update the Camera and the renderer
        camera2D.Update(delta);
        masterRenderer.Update(delta);
    }
    public override void CleanUp() {
        //Inform the MasterRenderer to clean up
        masterRenderer.Cleanup();
    }
    public override void OnExit() {
        base.OnExit();
        Environment.Exit(0);
    }
}
```
