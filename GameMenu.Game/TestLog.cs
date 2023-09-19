using Stride.Core.Diagnostics;
using Stride.Engine;
using Stride.Graphics;

namespace GameMenu;

public class Script : SyncScript
{
    public Texture myTexture;

    public override void Start()
    {
        // Initialization of the script.
        Log.ActivateLog(LogMessageType.Debug);
        Log.Debug("Start loading");
    }

    public override void Update()
    {
        
    }
}