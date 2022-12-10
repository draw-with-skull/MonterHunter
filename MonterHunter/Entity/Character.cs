using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine;
using MonterHunter.Engine.Components;
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
        
        private readonly float _speed = 100f;
        private readonly AnimationManager _animations;
        public Character()
        {
            _position = Vector2.Zero;
            _texture = Globals.content.Load<Texture2D>("Artwork/SpriteSheet/mainPlayer");
            _animations = new();

            _animations.SetDefault(ref _texture, 75f, 32, 32);
            _animations.AddAnimation(Action.RELOAD, 8, 0, true);
            _animations.AddAnimation(Action.WALK, 8, 3, false);
            _animations.AddAnimation(Action.STANDING_FIRE, 16, 2, true);
            //_animations.AddAnimation(Action.RELOAD, new Animation(ref _texture, 8, 75f, 32, 32, 0,true));
            _animations.AddAnimation(Action.IDLE, new Animation(ref _texture, 8, 75f, 32, 32, 1,false));
            //_animations.AddAnimation(Action.STANDING_FIRE, new Animation(ref _texture, 16, 75f, 32, 32, 2,true));
            //_animations.AddAnimation(Action.WALK, new Animation(ref _texture, 8, 75f, 32, 32, 3,false));
            _animations.AddAnimation(Action.WALKING_FIRE, new Animation(ref _texture, 16, 75f, 32, 32, 4,false));
            //_animations.AddAnimation(Action.WALKING_RELOAD, new Animation(ref _texture, 8, 75f, 32, 32, 5,false));
        }

        public override void Update()
        {
            _position = InputManager.direction * _speed * Globals.time/1000;

            _animations.Update(InputManager.action,InputManager.direction,_position);
        }
        public override void Draw()
        { 
            _animations.Draw();
        }
        
    }
}
