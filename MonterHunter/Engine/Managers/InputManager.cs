using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components;

namespace MonterHunter.Engine.Managers
{
    public class InputManager
    {
        private static bool _gotAction;
        public static Action action;
        public static Option option;
        public static Vector2 direction = Vector2.Zero;
        private static KeyboardState keyboardState;
        private static MouseState mouseState;

        public static void Update()
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
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

            //mouse actions
            if (mouseState.LeftButton == ButtonState.Pressed) { action = Action.LEFTCLICK; _gotAction = true; return; }
            if (mouseState.RightButton == ButtonState.Pressed) { action = Action.RIGHTCLICK; _gotAction = true; return; }

            if (!_gotAction)
            {
                action = Action.IDLE;
                direction = Vector2.Zero;
            }


        }
    }
}
