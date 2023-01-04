using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonterHunter.Engine.Components.Bases
{
    public class BaseState
    {
        protected RenderTarget2D renderTarget;
        private Rectangle _destination = new Rectangle(0, 0, 1600, 900);
        public BaseState(int width, int height)
        { 
            renderTarget = new RenderTarget2D(Globals.graphicsDevice,width,height);
            LoadContent(); }
        public virtual void Draw() {}
        protected virtual void Render() { }
        protected virtual void LoadContent() { }
        public virtual void Update() { }
        protected void Upscale()
        {   
            //reset render target
            Globals.graphicsDevice.SetRenderTarget(null);//resets to the default buffer
            //upscaleing
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            Globals.spriteBatch.Draw(renderTarget, _destination, Color.White);
            Globals.spriteBatch.End();
        }
    }
}
