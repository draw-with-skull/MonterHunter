using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components;

namespace MonterHunter.Engine.Managers
{
    public static class InputManager
    {
        private static bool _gotAction;
        private static Action action;
        public static Vector2 direction = Vector2.Zero;
        private static KeyboardState keyboardState;
        private static MouseState mouseState;

        public static Action GetAction()
        {
            return action;
        }
        public static void Update()
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
