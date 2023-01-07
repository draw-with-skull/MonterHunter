using MonterHunter.Engine.Managers;
using MonterHunter.Gui;

namespace MonterHunter.Engine
{
    internal class GameManager
    {
        
        
        public GameManager( )
        {
           
        }
        public void Init()
        {
            StateManager.AddState(new MainMenu(400,225));
        }
        public void Update()
        {
            StateManager.GetState().Update();
        }
        
        public void Draw()
        {
            StateManager.GetState().Draw();
        }


    }
}
