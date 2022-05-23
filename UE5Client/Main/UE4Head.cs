using RhuEngine.Linker;
using RNumerics;

namespace UERhubarbVR
{
    internal class UE5Head : IRHead
    {
        public Vector3f Position => Vector3f.Zero;

        public Matrix HeadMatrix => Matrix.Identity;
    }
}