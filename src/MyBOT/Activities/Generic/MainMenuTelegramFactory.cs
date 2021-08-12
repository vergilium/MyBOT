using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;
using MyBOT.Activities.Keyboards.Telegram;

namespace MyBOT.Activities.Generic{
    public class MainMenuTelegramFactory: IActivityFactory{
        public IActivity CreateMainMenu(IStringLocalizer<SharedResource> sharedLocalizer){
            return new MainMenuTelegram(sharedLocalizer);
        }
    }
}