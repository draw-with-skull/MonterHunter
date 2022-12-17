using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Components.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Gui
{
    internal class MainMenu : BaseState
    {
        private Button _playButton;
        private Texture2D _backgound;
        public MainMenu()
        {
            LoadContent();
        }
        
        public override void Draw()
        {
           if(_backgound != null)
            {
                Globals.spriteBatch.Draw(_backgound,new Rectangle(0, 0, _backgound.Width, _backgound.Height), Color.White);
            }
            _playButton.Draw();
        }

        protected override void LoadContent()
        {
            _backgound = Globals.content.Load<Texture2D>("Artwork/SplashScreen/SplashScreen");
            _playButton = new Button("Artwork/GUI/playButton", 200 , 100);
        }


        public override void Update()
        {
            // add some shit here
        }

        
    }
}
