using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Managers;


namespace MonterHunter.Engine.Components.Gui
{
    internal class Button: BaseComponenetGui
    {
        private readonly Texture2D _texture;
        private Rectangle _destination;
        private Rectangle _boundingBox;
        private bool _clicked;
        private Color _color;
        private readonly float _scaleing;


        // constructors
        public Button(string path, Point position, float scaling)
        {
            _scaleing = scaling;
            _texture = Globals.content.Load<Texture2D>(path);
            _clicked = false;

            if (_texture != null)
            {
                _destination = new Rectangle(position, new Point(_texture.Width, _texture.Height));
                UpdateBoundingBox();
            }
            
        }

        public Button(string path, int positionX,int positionY,float scaling)
        {
            _scaleing = scaling;
            _texture = Globals.content.Load<Texture2D>(path);
            if(_texture != null)
            {
                _destination = new Rectangle(positionX, positionY, _texture.Width, _texture.Height);
                UpdateBoundingBox();
            }
        }
        public override void Init()
        {
            // no use here
        }
        //screen drawing to the screen 
        public override void Draw()
        {
            _color = Color.White;
            if(_texture != null)
            {
                Globals.spriteBatch.Draw(_texture, _destination, _color);
            }
        }
        // game logic
        public override bool IsClicked()
        {
            return _clicked;
        }

        public override void Update()
        {
            UpdateMouseClickState();
        }
        private void UpdateMouseClickState()
        {
            if (_boundingBox.Contains(Globals.mouseState.Position))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _clicked = true;
                }
            }
        }
        internal void Reset()
        {
            //call because of bugs
            _clicked = false;
        }
        //because of mouse position because of scaleing
        private void UpdateBoundingBox()
        {
            //because of screen scaleing;
            _boundingBox.X = (int)(_destination.X * _scaleing);
            _boundingBox.Y = (int)(_destination.Y * _scaleing);
            _boundingBox.Width = (int)(_texture.Width * _scaleing);
            _boundingBox.Height = (int)(_texture.Height * _scaleing);
        }
        //position for the button
        public void CentreToRectangle(Rectangle source)
        {
            _destination.X = source.X + ((source.Width - _destination.Width) / 2);
            _destination.Y = source.Y + ((source.Height - _destination.Height) / 2);
            UpdateBoundingBox();
        }
        
        public void UnderButton(Rectangle source, int margin)
        {
            _destination.X = source.X + ((source.Width - _destination.Width) / 2);
            _destination.Y = source.Y + ((source.Height - _destination.Height) / 2);
            _destination.Y +=source.Height + margin;
            UpdateBoundingBox();
        }
        //getters
        public Rectangle Bounds() {
            return _destination;
        }
        
    }
}
