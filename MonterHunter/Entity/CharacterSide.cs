using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Managers;
using Action = MonterHunter.Engine.Components.Action;

namespace MonterHunter.Entity
{
    public class CharacterSide : BaseEntity
    {
        private readonly Texture2D _texture;
        private Vector2 _position;
        private readonly InputManagerPlayerSide _inputManager;
        
        private float _speed;
        private readonly AnimationManager _animations;
        public CharacterSide(string spriteSheetPath)
        {
            _position = Vector2.Zero;
            _texture = Globals.content.Load<Texture2D>(spriteSheetPath);
            _animations = new();
            _inputManager = new();

            _animations.SetDefault(ref _texture, 75f, 48, 48);
            _animations.AddAnimation(Action.IDLE, 4, 0, false);
            _animations.AddAnimation(Action.WALK, 6, 1, false);
            _animations.AddAnimation(Action.RUN, 6, 2, false);
            _animations.AddAnimation(Action.LEFTCLICK, 6, 3, true);
            _animations.AddAnimation(Action.RIGHTCLICK, 6, 4, true);
            _animations.AddAnimation(Action.EAT, 6, 5, true);
            _animations.AddAnimation(Action.JUMP, 6, 6, true);
            _animations.AddAnimation(Action.PUSH, 6, 7, false);
            

        }

        public override void Update()
        {
            _inputManager.Update();
            _speed = 100f;
            if(_inputManager.GetAction() == Action.RUN)
            {
                _speed = 250;
            }

            _position = _inputManager.direction * _speed * Globals.time/1000;
            _animations.Update(_inputManager.GetAction(), _inputManager.direction,_position);
        }
        public override void Draw()
        { 
            _animations.Draw();
        }
        
    }
}
