using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Managers;
using MonterHunter.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Gui
{
    internal class ForestState : BaseState
    {
        private Character ch;
        private Texture2D _background;
        private Rectangle _destination;
        private Vector2 _position = Vector2.Zero;

        public ForestState()
        {
            LoadContent();
            _destination = _background.Bounds;
        }
        public override void Draw()
        {
            Globals.spriteBatch.Draw(_background, _destination, Color.White);
            ch.Draw();
            
        }

        public override void Update()
        {
            ch.Update();
            _position -= InputManager.direction * 250 * Globals.time / 1000;
            _destination.X = (int)_position.X;
            _destination.Y = (int)_position.Y;
        }

        protected override void LoadContent()
        {
            ch = new("Artwork/SpriteSheet/character_48x48");
            _background = Globals.content.Load<Texture2D>("Artwork/Maps/MainIsland");
        }
    }
}
