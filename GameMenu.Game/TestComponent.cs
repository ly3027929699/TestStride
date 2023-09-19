using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core;
using Stride.Core.Collections;
using Stride.Core.Diagnostics;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace GameMenu
{
    public class TestComponent: StartupScript
    {
        [Display("num")] public int num;
        [Display("position")] public Vector3 position;
        //crach if use this
        //[Display("prefab")] public Prefab _prefab;

        private TrackingCollection<Entity> rootSceneEntities1;
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            try
            {
                var prefab = this.Content.Load<Prefab>("TestCube");
                this.rootSceneEntities1 = this.SceneSystem.SceneInstance.RootScene.Entities;
                for (int i = 0; i < num; i++)
                {
                    var instantiate = prefab.Instantiate();
                    var entity = instantiate[0];
                    var transformComponent = entity.Transform;
                    transformComponent.Position = this.position;
                    transformComponent.Rotation = Quaternion.Identity;
                    this.rootSceneEntities1.Add(entity);
                }
            }
            catch (Exception e)
            {
                GlobalLogger.GetLogger("Test1").Error(e.ToString());
            }
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            GlobalLogger.GetLogger("AppDomain").Error(e.ToString());
        }

        private async Task StartAsync()
        {
            // 在坐标(1, 1, 1)处实例化1000个预制体场景
        }

        async Task Create()
        {
            await Task.Delay(50);
        } 
    }
}
