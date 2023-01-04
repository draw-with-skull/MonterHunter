using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Components.Gui;
using MonterHunter.Engine.Managers;


namespace MonterHunter.Gui
{
    internal class MainMenu : BaseState
    {
        private Button _playButton;
        private Button _exitButton;
        private Texture2D _backgound;
        private Rectangle _destination;
        private readonly float scale;
        public MainMenu(int width,int height) : base(width, height)
        {
            scale = Globals.windowWidth / width;
            LoadContent();
            _destination = new Rectangle(0, 0, _backgound.Width, _backgound.Height);
            
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

        protected override void LoadContent()
        {
            _backgound = Globals.content.Load<Texture2D>("Artwork/SplashScreen/SplashScreen");
            _playButton = new Button("Artwork/GUI/playButton",0 , 0, scale);
            _playButton.CentreToRectangle(_backgound.Bounds);
            _exitButton = new Button("Artwork/GUI/exitButton", 0, 0, scale);
            _exitButton.UnderButton(_playButton.Bounds(), 5);
        }


        public override void Update()
        {
            _playButton.Update();
            _exitButton.Update();
            if (_playButton.IsClicked())
            {
                StateManager.AddState(new ForestState(800,450));
                _playButton.Reset();
            }
            if (_exitButton.IsClicked())
            {
                //Add exit mechanic
                _exitButton.Reset();
            }
        }

        protected override void Render()
        {
            if (_backgound != null)
            {
                Globals.spriteBatch.Draw(_backgound, _destination, Color.White);
            }
            _playButton.Draw();
            _exitButton.Draw();
        }


    }
}
