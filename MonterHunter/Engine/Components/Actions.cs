using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components
{
    public enum Action
    {
        IDLE,
        WALK,
        RUN,
        EAT,
        JUMP,
        PUSH,
        HURT,
        DEATH,

        LEFTCLICK,
        RIGHTCLICK
    }
    public enum Option
    {
        CONTINUOUS,
        NONE,
    }
}
