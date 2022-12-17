using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components.Bases
{
    public abstract class BaseState
    {
        public abstract void Draw();
        protected abstract void LoadContent();
        public abstract void Update();
    }
}
