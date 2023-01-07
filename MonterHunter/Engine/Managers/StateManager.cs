using MonterHunter.Engine.Components.Bases;
using System.Collections.Generic;

namespace MonterHunter.Engine.Managers
{
    public static class StateManager
    {
        private static Stack<BaseState> stateStack= new();


        public static void AddState(BaseState state)
        {
            stateStack.Push(state);
        }

        public static  void RemoveState()
        {
            if(stateStack.Count <= 1)
            {
                return;
            }
            stateStack.Pop();
        }
        
        public static BaseState GetState()
        {
            
            if (stateStack.Count < 1)
            {
                return null;
            }
            return stateStack.Peek();
        }
        public static int GetStackSize()
        {
            return stateStack.Count;
        }
        public static void Exit()
        {

        }
    }
}
