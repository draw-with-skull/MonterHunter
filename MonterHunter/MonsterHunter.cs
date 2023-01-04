using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components;
using MonterHunter.Engine.Managers;

namespace MonterHunter
{
    public class MonsterHunter : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly GameManager gameManager;
        public RenderTarget2D renderTarget;



        public MonsterHunter()
        {
            _graphics = new(this)
            {
                PreferredBackBufferWidth = 1600,
                PreferredBackBufferHeight = 900
            };
            Content.RootDirectory = "Content";
            
            IsMouseVisible = true;
            gameManager = new();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Globals.windowHeight = _graphics.PreferredBackBufferHeight;
            Globals.windowWidth = _graphics.PreferredBackBufferWidth;
            
            Globals.InitContent(Content);
            renderTarget = new RenderTarget2D(Globals.graphicsDevice, 400, 225);
            gameManager.Init();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteBatch = _spriteBatch;
            Globals.graphicsDevice = GraphicsDevice;
        }

        protected override void Update(GameTime gameTime)
        { 
            gameManager.Update();
            Globals.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            
            gameManager.Draw();
            

            base.Draw(gameTime);
        }
    }
}