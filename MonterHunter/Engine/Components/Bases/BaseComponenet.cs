using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components.Bases
{
    internal abstract class BaseComponenetGui
    {
        public abstract void Draw();
        public abstract void Init();
        public abstract void Update();
        public abstract bool IsClicked();

    } 
}
