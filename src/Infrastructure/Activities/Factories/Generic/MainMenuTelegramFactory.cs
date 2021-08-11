using Keyboard.Factories.Abstract;
using Keyboard.Factories.Keyboards;
using Keyboard.Factories.Keyboards.Viber;

namespace Keyboard.Factories.Generic{
    public class MainMenuTelegramFactory: IActivityFactory{
        public IActivity CreateMainMenu(){
            return new MainMenuTelegram();
        }
    }
}