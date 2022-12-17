using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components.Bases;
using MonterHunter.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = MonterHunter.Engine.Components.Action;

namespace MonterHunter.Entity
{
    public class Character : BaseEntity
    {
        private readonly Texture2D _texture;
        private Vector2 _position; 
        
        private float _speed = 0;
        private readonly AnimationManager _animations;
        public Character(string spriteSheetPath)
        {
            _position = Vector2.Zero;
            _texture = Globals.content.Load<Texture2D>(spriteSheetPath);
            _animations = new();

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
            _speed = 100f;
            if(InputManager.action== Action.RUN)
            {
                _speed = 250;
            }

            _position = InputManager.direction * _speed * Globals.time/1000;

            _animations.Update(InputManager.action,InputManager.direction,_position);
        }
        public override void Draw()
        { 
            _animations.Draw();
        }
        
    }
}
