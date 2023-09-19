using Stride.Engine;

namespace Hotfix;

public class Test: SyncScript
{
    private HotfixGame _game;

    public override void Start()
    {
        base.Start();
        this._game = new HotfixGame();
        this._game.Setup();
    }

    public override void Update()
    {
        var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
        this._game.Update(deltaTime);
    }
}