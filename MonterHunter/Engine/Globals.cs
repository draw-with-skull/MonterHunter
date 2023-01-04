using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonterHunter.Engine
{
    public  class Globals
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager content;
        public static GraphicsDeviceManager graphicsManager;
        public static GraphicsDevice graphicsDevice;
        public static float time;
        public static MouseState mouseState;
        public static int windowHeight;
        public static int windowWidth;
        public static void InitContent(ContentManager gameContent)
        {
            content = gameContent;
        }
        public static void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            time = gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
