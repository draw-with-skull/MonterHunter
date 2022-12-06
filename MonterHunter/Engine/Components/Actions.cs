using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components
{
    public enum Action
    {
        RELOAD,
        IDLE,
        STANDING_FIRE,
        WALK,
        WALKING_FIRE,
        WALKING_RELOAD,
    }
    public enum Option
    {
        CONTINUOUS,
        NONE,
    }
}
