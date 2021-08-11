using Keyboard.Factories.Abstract;

namespace Keyboard.Factories.Generic{
    public class Activity{
        public IActivity MainMenu{ get; private set; }

        public Activity(IActivityFactory factory){
            MainMenu = factory.CreateMainMenu();
        }
    }
}