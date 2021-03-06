# GrzeEngine

## How To Setup A New Project
Import the `GrzeEngine`, `OpenGL.dll`, & `OpenGL.Platform.dll` libraries into your project

Than, move `SDL2.dll`, found in `~/Lib`, into your output build directory. (Alternatively, place the dll into the root project folder and set it to `Copy if newer` in your IDE)

## Skeleton

```C#
class Window : GrzeEngine.Engine.Core.Window
{
    private MasterRenderer masterRenderer;
    public int[] viewWindow = { 250, 250 };

    public Window(int width, int height) : base(width, height)
    {
        Initialize(width, height);
        StartLoop();
        CleanUp();
    }
    public override void Initialize(int width, int height)
    {
        //Setup Window & OpenGL context
        base.Initialize(width, height);

        //Init Master renderer and pass in a new renderer
        masterRenderer = new MasterRenderer();
        //Setup renderer with a 2d camera and correct aspect ratio with the viewWindow
        masterRenderer.AddRenderer("Renderer", new Renderer(viewWindow[0], (int)(viewWindow[1] / this.aspectRatio), new Camera2D(), new Static2DShader()));
        //Create Test Sprite
        masterRenderer.AddEntity("Renderer", new Sprite(Vector2.Zero, new Vector2(10, 10), Vector2.Zero, masterRenderer.GetShader("Renderer")));
    }
    public override void OnRender()
    {
        base.OnRender();
        //Proccess all entities before renderering
        masterRenderer.ProcessEntities();
        //Render to buffer
        masterRenderer.Render();
        //Swap rendered buffer with current screen buffer
        SwapBuffers();
    }
    public override void OnUpdate()
    {
        float delta = clock.delta();
        //Update all Renderers and entities
        masterRenderer.Update(delta);
    }
    public override void CleanUp()
    {
        //Inform all Renderers to cleanup
        masterRenderer.Cleanup();
    }
    public override void OnExit()
    {
        base.OnExit();
        Environment.Exit(0);
    }
}
```
