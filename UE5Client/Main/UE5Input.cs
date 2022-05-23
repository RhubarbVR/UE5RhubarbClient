using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealEngine.Framework;
using RhuEngine;

using REngine = RhuEngine.Engine;
using RhuEngine.Linker;

namespace UERhubarbVR
{
    public class UE5Input : IRInput
    {

        public string TypeDelta => "";

        public IRHead Head => new UE5Head();

        public IRMouse Mouse => new UE5Mouse();

        private IRController left = new UE5Controller();
        private IRController right = new UE5Controller();
        private IRController both = new UE5Controller();

        public IRController Controller(Handed handed)
        {
            switch (handed)
            {
                case Handed.Left:
                    return left;
                case Handed.Right:
                    return right;
                case Handed.Max:
                    return both;
                default:
                    break;
            }
            return null;
        }
        private IRHand lefthand = new UE5Hand();
        private IRHand righthand = new UE5Hand();
        private IRHand bothhand = new UE5Hand();
        public IRHand Hand(Handed value)
        {
            switch (value)
            {
                case Handed.Left:
                    return lefthand;
                case Handed.Right:
                    return righthand;
                case Handed.Max:
                    return bothhand;
                default:
                    break;
            }
            return null;
        }

        public IKeyPress Key(Key secondKey)
        {
            return new UE5KeyPress(secondKey);
        }
    }
}
