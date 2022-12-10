using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonterHunter.Engine.Components;

namespace MonterHunter.Engine.Managers
{
    public class InputManager
    {
        public static Action action;
        public static Option option;
        public static Vector2 direction=Vector2.Zero;

        public static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            
            if (keyboardState.GetPressedKeyCount() > 0)
            {
                //left right movement
                if (keyboardState.IsKeyDown(Keys.A)) { action = Action.WALK; direction.X = -1; }
                if (keyboardState.IsKeyDown(Keys.D)) { action = Action.WALK; direction.X = 1; }
                if(keyboardState.IsKeyUp(Keys.A)&& keyboardState.IsKeyUp(Keys.D)) { direction = Vector2.Zero; }
                if (keyboardState.IsKeyDown(Keys.R)){action = Action.RELOAD;}
            }
            else
            {
                direction = Vector2.Zero;
                action = Action.IDLE;
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (action == Action.WALK) action = Action.WALKING_FIRE; else action = Action.STANDING_FIRE;

            }


        }

    }
}
