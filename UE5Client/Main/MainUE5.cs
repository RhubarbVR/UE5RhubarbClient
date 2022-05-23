using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealEngine.Framework;
using RhuEngine;

using REngine = RhuEngine.Engine;
using RhuEngine.Linker;
using RhuEngine.Physics;
using RLogLevel = RhuEngine.Linker.LogLevel;
using System.IO;

namespace UERhubarbVR
{
    public class UE5Time : IRTime
    {
        public float Elapsedf => World.DeltaTime;
    }

    public class UnrealEngineLink : IEngineLink
    {
        public REngine engine;
        public bool SpawnPlayer => true;

        public bool CanRender => true;

        public bool CanAudio => false;

        public bool CanInput => true;

        public string BackendID => "UnrealEngine 5.0.1";

        public void BindEngine(REngine engine)
        {
            this.engine = engine;
            RLog.Instance = new UE5Log();
        }

        public void LoadStatics()
        {
            RTime.Instance = new UE5Time();
            RTexture2D.Instance = new UE5Texture();
            RMaterial.Instance = new UE5Mit();
            RShader.Instance = new UE5Shader();
            RText.Instance = new UE5Text();
            RMesh.Instance = new UE5Mesh();
            RRenderer.Instance = new UE5Render();
            RFont.Instance = new UEFont();
            RInput.Instance = new UE5Input(); 
            new RBullet.BulletPhsyicsLink(true).RegisterPhysics();
        }

        public void Start()
        {
            Debug.Log(UnrealEngine.Framework.LogLevel.Display, $"Starting Engine Bind");
        }
    }

    public class Main
    {
        public static REngine engine;
        public static UnrealEngineLink engineLink;
        public static OutputCapture cap;

        public static void OnWorldPostBegin()
        {
            var basedir = Application.ProjectDirectory;
            Debug.Log(UnrealEngine.Framework.LogLevel.Display, $"Starting RubarbVR BaseDir:{basedir}");
            cap = new OutputCapture();
            engineLink = new UnrealEngineLink();
            engine = new REngine(engineLink, Array.Empty<string>(), cap, basedir);
            engine.Init();
        }
        public static void OnWorldEnd()
        {
            engine.IsCloseing = true;
            cap.DisableSingleString = true;
            engine.Dispose();
            cap.Dispose();
        }
        public static void OnWorldPrePhysicsTick(float deltaTime)
        {
            engine?.Step();
        }
    }
}
