using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components;

namespace MonterHunter.Engine.Managers
{
    public class InputManagerPlayerSide
    {
        private bool _gotAction;
        private Action action;
        public Vector2 direction = Vector2.Zero;
        private KeyboardState keyboardState;
        private MouseState mouseState;

        public  Action GetAction()
        {
            return action;
        }
        public  void Update()
        {
            keyboardState = Keyboard.GetState();
            mouseState = Globals.mouseState;
            _gotAction = false;

            //move left right
            if (keyboardState.IsKeyDown(Keys.A)) { action = Action.WALK; direction.X = -1; _gotAction = true; }
            if (keyboardState.IsKeyDown(Keys.D)) { action = Action.WALK; direction.X = 1; _gotAction = true; }
            //run
            if (keyboardState.IsKeyDown(Keys.LeftShift)){ action = Action.RUN; }
            //jump
            if (keyboardState.IsKeyDown(Keys.W)) { action = Action.JUMP; _gotAction = true; return; }
            //actions
            if (keyboardState.IsKeyDown(Keys.Q)) { action = Action.EAT; _gotAction = true; return; }

            //mouse 
            if (mouseState.LeftButton == ButtonState.Pressed) { action = Action.LEFTCLICK; _gotAction = true; return; }
            if (mouseState.RightButton == ButtonState.Pressed) { action = Action.RIGHTCLICK; _gotAction = true; return; }

            //generals
            if (keyboardState.IsKeyDown(Keys.Escape)){ action = Action.ESCAPE; return; }

            if (!_gotAction)
            {
                action = Action.IDLE;
                direction = Vector2.Zero;
            }
        }
    }
}
