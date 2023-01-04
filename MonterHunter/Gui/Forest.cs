using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Entity;

namespace MonterHunter.Gui
{
    internal class ForestState : BaseState
    {
        private Character ch;
        private Texture2D _background;
        private Rectangle _destination;
        private Vector2 _position = Vector2.Zero;
        private Vector2 _dimension;



        public ForestState(int width, int height) : base(width, height)
        {
            LoadContent();
            _destination = _background.Bounds;
            _dimension.X = width;
            _dimension.Y = height;
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
            ch.Update();
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
            ch = new("Artwork/SpriteSheet/character_48x48");
            _background = Globals.content.Load<Texture2D>("Artwork/Maps/MainIsland");
        }

        protected override void Render()
        {
            Globals.spriteBatch.Draw(_background,Vector2.Zero, _destination, Color.White);
            ch.Draw();
        }
    }
}
