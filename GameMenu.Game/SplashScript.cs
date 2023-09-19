// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.IO;
using System.Linq;
using System.Reflection;
using Stride.Core.Diagnostics;
using Stride.Core.IO;
using Stride.Core.Serialization;
using Stride.Engine;
using Stride.Input;

namespace GameMenu
{
    public class SplashScript : UISceneBase
    {
        public UrlReference<Scene> NextSceneUrl { get; set; }

        protected override void LoadScene()
        {
            // Allow user to resize the window with the mouse.
            Game.Window.AllowUserResizing = true;
            
            
//            using var stream = Content.OpenAsStream(new UrlReference("Hotfix.dll"));
//            using var streamReader = new BinaryReader(stream);
//            //read the raw asset content
//            var buffer = streamReader.ReadBytes((int)(stream.Length - stream.Position));
//                
//            var assembly = Assembly.Load(buffer);
//            var type = assembly.GetType("Hotfix.InitHotfix");
//            var methodInfo = type?.GetMethod("Start", BindingFlags.Static | BindingFlags.Public);
//            GlobalLogger.GetLogger("PreHotfix").Info("Pre Start!!!!");
//            methodInfo?.Invoke(null, new object[]{Entity.Scene});
        }

        protected override void UpdateScene()
        {
            if (Input.PointerEvents.Any(e => e.EventType == PointerEventType.Pressed))
            {
                // Next scene
                SceneSystem.SceneInstance.RootScene = Content.Load(NextSceneUrl);
                Cancel();
            }
        }
    }
}
