using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core;
using Stride.Core.Collections;
using Stride.Core.Diagnostics;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Physics;

namespace GameMenu
{
    public class Tes1 : StartupScript
    {
        [Display("num")] public int num;
        [Display("step")] public int step;

        [Display("position")] public Vector3 position;

        //crach if use this
        [Display("prefab")] public Prefab _prefab;

        [Display("xRange")] public Vector2 xRange;
        [Display("yRange")] public Vector2 yRange;
        [Display("zRange")] public Vector2 zRange;

        private TrackingCollection<Entity> rootSceneEntities1;
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            try
            {
                this.rootSceneEntities1 = this.SceneSystem.SceneInstance.RootScene.Entities;
                StartAsync();
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

            try
            {
                for (int i = 0; i < num / step; i++)
                {
                    await Create();
                }
            }
            catch (Exception e)
            {
                GlobalLogger.GetLogger("Test1").Error(e.ToString());
            }
        }

        async Task Create()
        {
            await Task.Delay(1);


            for (var i = 0; i < step; i++)
            {
                float x = this.Next(this.xRange.X, this.xRange.Y);
                float y = this.Next(this.yRange.X, this.yRange.Y);
                float z = this.Next(this.zRange.X, this.zRange.Y);
                var instantiate = _prefab.Instantiate();
                var entity = instantiate[0];
                var transformComponent = entity.Transform;
                transformComponent.Position = new Vector3(x, y, z);
                this.rootSceneEntities1.Add(entity);
            }
        }

        private float Next(float xMin, float xMax)
        {
            return Random.Shared.Next((int)(xMin * 1000), (int)(xMax * 1000)) / 1000f;
        }
    }
}