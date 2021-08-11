using Keyboard.Factories.Abstract;
using Keyboard.Factories.Keyboards.Viber;

namespace Keyboard.Factories.Generic{
    public class MainMenuViberFactory: IActivityFactory{
        public IActivity CreateMainMenu(){
            return new MainMenuViber();
        }
    }
}