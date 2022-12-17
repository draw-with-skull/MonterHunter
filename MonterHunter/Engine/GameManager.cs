using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine.Managers;
using MonterHunter.Entity;
using MonterHunter.Gui;
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
        //private Character ch;
        
        public GameManager( )
        {
            //ch = new("Artwork/SpriteSheet/character_48x48");
           

        }
        public void Init()
        {
            StateManager.AddState(new MainMenu());
        }
        public void Update()
        {
            //ch.Update();
        }
        
        public void Draw()
        {
            StateManager.GetState().Draw();
            //ch.Draw();
        }


    }
}
