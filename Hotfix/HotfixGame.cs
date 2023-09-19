using System.Runtime.CompilerServices;
using Stride.Core.Diagnostics;
using Stride.Core.IO;

namespace Hotfix;

internal class HotfixGame
{
    private static Logger logger = null!;
    public static Logger Logger =>logger;

    public HotfixGame()
    {
        logger = GlobalLogger.GetLogger("HotfixGame");
    }
    public void Setup()
    {
        HotfixGame.Logger.Info("Setup HotfixGame!");
        
        PrintPath(VirtualFileSystem.ApplicationDatabasePath);
        PrintPath(VirtualFileSystem.LocalDatabasePath);
        PrintPath(VirtualFileSystem.Drive.RootPath);
        var filePath = "aaa";
        PrintPath(VirtualFileSystem.Drive.GetLocalPath(filePath));
        PrintPath(VirtualFileSystem.Drive.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationObjectDatabase?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationObjectDatabase?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationBinary?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationBinary?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationLocal?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationLocal?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationRoaming?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationRoaming?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationData?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationData?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationDatabase?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationDatabase?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationCache?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationCache?.GetAbsolutePath(filePath));
        PrintPath(VirtualFileSystem.ApplicationTemporary?.RootPath);
        PrintPath(VirtualFileSystem.ApplicationTemporary?.GetAbsolutePath(filePath));
        
        
    }

    private void PrintPath(object? str,[CallerArgumentExpression(nameof(str))]string? name=null)
    {
        Logger.Info($"{name}:{str} ");
    }

    public void Update(float deltaTime)
    {
        
    }
}