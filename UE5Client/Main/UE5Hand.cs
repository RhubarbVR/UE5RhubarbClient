using RhuEngine.Linker;
using RNumerics;

namespace UERhubarbVR
{
    internal class UE5Hand : IRHand
    {
        public Matrix Wrist => Matrix.Identity;
    }
}