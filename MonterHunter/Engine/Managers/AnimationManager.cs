using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonterHunter.Engine.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = MonterHunter.Engine.Components.Action;

namespace MonterHunter.Engine.Managers
{
    public class AnimationManager
    {
        private Action _key = Action.IDLE;
        private bool _flipState;
        private readonly Dictionary<Action,Animation> _animations;
        private Texture2D _texture;
        private float _frameTime=0;
        private int _frameHeight=0,_frameWidth=0;
    
        public AnimationManager()
        {
            _animations = new Dictionary<Action, Animation>();
        }

        public void AddAnimation(Action key,Animation animation)
        {
            _animations.Add(key, animation);
        }
        public void AddAnimation(Action key, int frameCount,int frameRow,bool continuous)
        {
            if (_texture == null)
                throw new Exception("Animation manager is not set");
            if (_frameTime == 0|| _frameWidth == 0|| _frameHeight == 0) 
                throw new Exception("Animation manager is not set");

            _animations.Add(key,new Animation(ref _texture,frameCount,_frameTime,_frameWidth,_frameHeight,frameRow, continuous));
            _key = key;
        }

        public void SetDefault(ref Texture2D texture, float frameTime,int frameWidth, int frameHeight)
        {
            _texture = texture;
            _frameTime = frameTime;
            _frameHeight = frameHeight;
            _frameWidth = frameWidth;
        }        

        public void Update(Action key,Vector2 direction)
        {
            if (_animations[_key].IsContinuous())
            {
                _animations[_key].Start();
                if (_animations[_key].FramesLeft() > 0)
                {
                    _animations[_key].Update(CheckFaceingDirection(direction));
                    return;
                }
            }

            if (!_animations.ContainsKey(key))
            {
                _animations[_key].Stop();
                _animations[_key].Reset();
                return;
            }
            
            _animations[key].Start();
            _animations[key].Update(CheckFaceingDirection(direction));
            
            _key = key;   
        }
        public void Draw(Vector2 position)
        {
            _animations[_key].Draw(position);
        }

        private bool CheckFaceingDirection(Vector2 direction)
        {
            if (direction.X == 1) _flipState = false;
            if (direction.X == -1) _flipState = true;
            return _flipState;
        }
    }
}
