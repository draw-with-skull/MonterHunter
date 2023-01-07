using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Entity;
using System.Diagnostics;

namespace MonterHunter.Gui
{
    internal class ForestState : BaseState
    {
        private Texture2D _background;
        private Rectangle _destination;
        private Vector2 _position = Vector2.Zero;
        private Vector2 _dimension;
        private readonly float _scale;
        CharacterTop ch;


        public ForestState(int width, int height) : base(width, height)
        {
            ch = new();
            LoadContent();
            _scale = Globals.windowWidth / width;
            _destination = _background.Bounds;
            _dimension.X = width;
            _dimension.Y = height;
            _position.X = 0;
            _position.Y = 700;
        }
        public override void Draw()
        {

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            Globals.graphicsDevice.SetRenderTarget(renderTarget);
            Globals.graphicsDevice.Clear(Color.LightCoral);
            //draw all the stuff
            Render();

            Globals.spriteBatch.End();
            base.Upscale();
            
            
        }

        public override void Update()
        {
            MouseScroll();
            //_position += InputManager.direction * 250 * Globals.time / 1000;
            _destination.X = (int)_position.X;
            _destination.Y = (int)_position.Y;
            //bounds for left and top;
            if (_position.X < 0) _destination.X = 0;
            if (_position.Y < 0) _destination.Y = 0;
            //bounds for right and top;
            if (_position.X > _destination.Width-_dimension.X) _destination.X = _destination.Width - (int)_dimension.X;
            if (_position.Y > _destination.Height-_dimension.Y) _destination.Y = _destination.Height - (int)_dimension.Y;
            
        }

        protected override void LoadContent()
        {
            _background = Globals.content.Load<Texture2D>("Artwork/Maps/MainIsland");
        }

        protected override void Render()
        {
            
            Globals.spriteBatch.Draw(_background,Vector2.Zero, _destination, Color.White);
            ch.Draw();
        }

        private void MouseScroll()
        {
            Vector2 mousePosition;
            mousePosition.X = Globals.mouseState.Position.X;
            mousePosition.Y = Globals.mouseState.Position.Y;
            //
            if (mousePosition.Y > Globals.windowHeight-100 && _position.Y < Globals.windowHeight) _position.Y += Globals.time  ;
            if (mousePosition.Y < 100 && _position.Y > 0)  _position.Y -= Globals.time;
            if (mousePosition.X > Globals.windowWidth-100 && _position.X < Globals.windowWidth) _position.X += Globals.time;
            if (mousePosition.X < 100 && _position.X > 0) _position.X -= Globals.time;
            Debug.WriteLine(_position);
        }
    }
}
