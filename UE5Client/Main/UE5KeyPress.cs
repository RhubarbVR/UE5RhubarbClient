using RhuEngine.Linker;
using UnrealEngine.Framework;

namespace UERhubarbVR
{
    internal class UE5KeyPress : IKeyPress
    {
        internal UE5KeyPress( Key secondKey)
        {
            SecondKey = secondKey;
        }

        public Key SecondKey { get; }

        public bool IsActive()
        {
            return World.GetFirstPlayerController().GetPlayerInput().IsKeyPressed(SecondKey.ToString());
        }

        public bool IsJustActive()
        {
            return World.GetFirstPlayerController().GetPlayerInput().GetTimeKeyPressed(SecondKey.ToString()) <= RTime.Elapsedf;
        }
    }
}