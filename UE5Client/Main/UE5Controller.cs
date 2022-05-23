using RhuEngine.Linker;

namespace UERhubarbVR
{
    internal class UE5Controller : IRController
    {
        public float Trigger => 0f;

        public float Grip => 0f;

        public IKeyPress StickClick => new UE5KeyPress(Key.None);

        public IKeyPress X1 => new UE5KeyPress(Key.None);

        public IKeyPress X2 => new UE5KeyPress(Key.None);

        public IRStick Stick => new UE5Stick();
    }
}