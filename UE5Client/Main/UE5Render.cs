using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealEngine.Framework;
using RhuEngine;

using REngine = RhuEngine.Engine;
using RhuEngine.Linker;
using RNumerics;
using RhuEngine.Components;

namespace UERhubarbVR
{
    public class UIRender : RenderLinkBase<UICanvas>
    {
        public override void Init()
        {
        }

        public override void Remove()
        {
        }

        public override void Render()
        {
            RenderingComponent?.RenderUI();
        }

        public override void Started()
        {
        }

        public override void Stopped()
        {
        }
    }

    public class UETextRender : RenderLinkBase<WorldText>
    {
        public override void Init()
        {
            //Not needed for StereoKit
        }

        public override void Remove()
        {
            //Not needed for StereoKit
        }

        public override void Render()
        {
            RenderingComponent.textRender.Render(RNumerics.Matrix.Identity, RenderingComponent.Entity.GlobalTrans);
        }

        public override void Started()
        {
            //Not needed for StereoKit
        }

        public override void Stopped()
        {
            //Not needed for StereoKit
        }
    }

    public class UEFont : IRFont
    {
        public RFont Default => new RFont(null);
    }

    public class UE5Shader : IRShader
    {
        public RShader UnlitClip =>new RShader(null);

        public RShader PBRClip => new RShader(null);

        public RShader PBR => new RShader(null);

        public RShader Unlit => new RShader(null);
    }


    public class UE5Mit : IRMaterial
    {
        public IEnumerable<RMaterial.RMatParamInfo> GetAllParamInfo(object tex)
        {
            yield return new RMaterial.RMatParamInfo { };
        }

        public DepthTest GetDepthTest(object tex)
        {
            return DepthTest.Never;
        }

        public bool GetDepthWrite(object tex)
        {
            return false;
        }

        public Cull GetFaceCull(object tex)
        {
            return Cull.None;
        }

        public int GetQueueOffset(object tex)
        {
            return 0;
        }

        public Transparency GetTransparency(object tex)
        {
            return Transparency.None;
        }

        public bool GetWireframe(object tex)
        {
            return false;
        }

        public object Make(RShader rShader)
        {
            return null;
        }

        public void Pram(object ex, string tex, object value)
        {
        }

        public void SetDepthTest(object tex, DepthTest value)
        {
        }

        public void SetDepthWrite(object tex, bool value)
        {
        }

        public void SetFaceCull(object tex, Cull value)
        {
        }

        public void SetQueueOffset(object tex, int value)
        {
        }

        public void SetTransparency(object tex, Transparency value)
        {
        }

        public void SetWireframe(object tex, bool value)
        {
        }
    }


    public class UE5Mesh : IRMesh
    {
        public RMesh Quad => new RMesh(StaticMesh.Cube);

        public void Draw(string id, object mesh, RMaterial loadingLogo, Matrix p, Colorf tint)
        {
        }

        public void LoadMesh(RMesh meshtarget, IMesh mesh)
        {
        }
    }



    public class UE5Text : IRText
    {
        public void Add(string id, string v, Matrix p)
        {
        }

        public void Add(string id, char c, Matrix p, Colorf color, RFont rFont, FontStyle fontStyle, Vector2f textCut)
        {
        }

        public Vector2f Size(RFont rFont, char c, FontStyle fontStyle)
        {
            return Vector2f.One;
        }
    }

    public class SKMeshRender : RenderLinkBase<MeshRender>
    {
        public override void Init()
        {
        }

        public override void Remove()
        {
        }

        public override void Render()
        {
            Debug.DrawBox(RenderingComponent.Entity.GlobalTrans.Translation, RenderingComponent.Entity.GlobalTrans.Scale, RenderingComponent.Entity.GlobalTrans.Rotation.ToSystemNumric(), System.Drawing.Color.Blue);
        }

        public override void Started()
        {
        }

        public override void Stopped()
        {
        }
    }

    public class UE5Render : IRRenderer
    {
        public Matrix GetCameraRootMatrix()
        {
            return Matrix.Identity;
        }

        public bool GetEnableSky()
        {
            return false;
        }

        public void SetCameraRootMatrix(Matrix m)
        {
        }

        public void SetEnableSky(bool e)
        {
        }
    }


    public class UE5Texture : IRTexture2D
    {
        public RTexture2D White => new RTexture2D(null);

        public TexAddress GetAddressMode(object target)
        {
            return TexAddress.Wrap;
        }

        public int GetAnisoptropy(object target)
        {
            return 0;
        }

        public int GetHeight(object target)
        {
            return 0;
        }

        public TexSample GetSampleMode(object target)
        {
            return TexSample.Linear;
        }

        public int GetWidth(object target)
        {
            return 0;
        }

        public object Make(TexType dynamic, TexFormat rgba32Linear)
        {
            return null;
        }

        public object MakeFromColors(Colorb[] colors, int width, int height, bool srgb)
        {
            return null;
        }

        public object MakeFromMemory(byte[] data)
        {
            return null;
        }

        public void SetAddressMode(object target, TexAddress value)
        {
        }

        public void SetAnisoptropy(object target, int value)
        {
        }

        public void SetColors(object tex, int width, int height, byte[] rgbaData)
        {
        }

        public void SetSampleMode(object target, TexSample value)
        {
        }

        public void SetSize(object tex, int width, int height)
        {
        }
    }
}
