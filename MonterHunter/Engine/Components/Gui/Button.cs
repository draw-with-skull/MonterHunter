using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine.Components.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components.Gui
{
    internal class Button: BaseComponenetGui
    {
        private Texture2D _texture;
        private Point _position;
        private Rectangle _destination;
        private bool _clicked;

        public Button(string path, Point position)
        {
            _position = position;
            _texture = Globals.content.Load<Texture2D>(path);
            _clicked = false;
            if (_texture != null)
            {
                _destination = new Rectangle(position, new Point(_texture.Width, _texture.Height));
            }
        }

        public Button(string path, int positionX,int positionY)
        {
            _position = new Point(positionX, positionY);
            _texture = Globals.content.Load<Texture2D>(path);
            if(_texture != null)
            {
                _destination = new Rectangle(positionX, positionY, _texture.Width, _texture.Height);
            }
        }
        public override void Draw()
        {
            if(_texture != null)
            {
                Globals.spriteBatch.Draw(_texture, _destination, Color.White);
            }
        }

        public override void Init()
        {
            
        }

        public override bool IsClicked()
        {
            return _clicked;
        }

        public override void Update()
        {
            
        }
        
        public static void CentreToTexture(ref Texture2D texture)
        {

        }
    }
}
