using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Components.Gui
{
    internal class Button: BaseComponenetGui
    {
        private readonly Texture2D _texture;
        private Rectangle _destination;
        private Rectangle _boundingBox;
        private bool _clicked;
        private Color color;

        

        public Button(string path, Point position)
        {
            _texture = Globals.content.Load<Texture2D>(path);
            _clicked = false;
            if (_texture != null)
            {
                _destination = new Rectangle(position, new Point(_texture.Width, _texture.Height));
                UpdateBoundingBox();
            }
            
        }

        public Button(string path, int positionX,int positionY)
        {
            _texture = Globals.content.Load<Texture2D>(path);
            if(_texture != null)
            {
                _destination = new Rectangle(positionX, positionY, _texture.Width, _texture.Height);
                UpdateBoundingBox();
            }
        }
        public override void Draw()
        {
            color = Color.White;
            if(_texture != null)
            {
                Globals.spriteBatch.Draw(_texture, _destination, color);
            }
        }

        public override void Init()
        {
            // no use here
        }

        public override bool IsClicked()
        {
            return _clicked;
        }

        public override void Update()
        {
            UpdateMouseClickState();


        }
        
        public void CentreToRectangle(Rectangle source)
        {
            _destination.X = source.X + ((source.Width - _destination.Width) / 2);
            _destination.Y = source.Y + ((source.Height - _destination.Height) / 2);
            UpdateBoundingBox();
            
        }
        private void UpdateMouseClickState()
        {
            if (_boundingBox.Contains(Globals.mouseState.Position))
            {
                if (InputManager.GetAction() == Action.LEFTCLICK)
                {
                    _clicked = true;
                }
            }
        }
        private void UpdateBoundingBox()
        {
            //because of screen scaleing;
            _boundingBox.X = _destination.X * 4;
            _boundingBox.Y = _destination.Y * 4;
            _boundingBox.Width = _texture.Width * 4;
            _boundingBox.Height = _texture.Height * 4;
        }
        internal void Reset()
        {
            _clicked = false;
        }
    }
}
