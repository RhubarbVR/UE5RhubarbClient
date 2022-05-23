using RhuEngine.Linker;
using RNumerics;
using UnrealEngine.Framework;

namespace UERhubarbVR
{
    internal class UE5Mouse : IRMouse
    {
        public Vector2f ScrollChange => Vector2f.Zero;

        public Vector2f PosChange => Vector2f.Zero;
    }
}