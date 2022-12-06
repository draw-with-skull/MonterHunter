using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine;
using MonterHunter.Engine.Managers;

namespace MonterHunter
{
    public class MonsterHunter : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager gameManager;
        public RenderTarget2D renderTarget;


        public MonsterHunter()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Globals.InitContent(Content);
            renderTarget = new RenderTarget2D(Globals.graphicsDevice, 400, 255);
            gameManager = new();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.spriteBatch = _spriteBatch;
            Globals.graphicsDevice = GraphicsDevice;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            gameManager.Update();
            // TODO: Add your update logic here
            InputManager.Update();
            Globals.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //drawing
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            Globals.graphicsDevice.SetRenderTarget(renderTarget);
            Globals.graphicsDevice.Clear(Color.LightCoral);
            gameManager.Draw();
            Globals.spriteBatch.End();
            Globals.graphicsDevice.SetRenderTarget(null);
            //upscaleing
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            Globals.spriteBatch.Draw(renderTarget, new Rectangle(0, 0, 1600, 900), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}