using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MonterHunter.Engine
{
    public  class Globals
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager content;
        public static GraphicsDeviceManager graphicsManager;
        public static GraphicsDevice graphicsDevice;
        public static float time;
        public static void InitContent(ContentManager gameContent)
        {
            content = gameContent;
        }
        public static void Update(GameTime gameTime)
        {
            time = gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
