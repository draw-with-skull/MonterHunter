using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine
{
    internal class GameManager
    {
        private Character ch;

        public GameManager( )
        {
            ch = new();
           

        }
        public void Update()
        {
            ch.Update();
        }

        public void Draw()
        {
            ch.Draw();
        }


    }
}
