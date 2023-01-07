using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Entity
{
    internal class CharacterTop : BaseEntity
    {
        private Texture2D _playerIcon;
        private Vector2 _position;
        public CharacterTop()
        {
            _position = Vector2.Zero;
            _playerIcon = Globals.content.Load<Texture2D>("Artwork/SpriteSheet/character_icon_48x48");
        }
        public override void Draw()
        {
            Globals.spriteBatch.Draw(_playerIcon, _position, _playerIcon.Bounds, Color.White);
        }

        public override void Update()
        {
            
        }

        public void SetPosition(float x,float y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }
    }
}
