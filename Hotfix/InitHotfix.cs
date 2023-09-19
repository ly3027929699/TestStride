using Stride.Core.Diagnostics;
using Stride.Engine;

namespace Hotfix;

public static class InitHotfix
{
    public static void Start(Scene scene)
    {
        GlobalLogger.GetLogger("Hotfix").Info("Invoke Hotfix Logic!");
        var entity = new Entity("Test");
        entity.Add(new Test());
        entity.Scene = scene;
    }
}