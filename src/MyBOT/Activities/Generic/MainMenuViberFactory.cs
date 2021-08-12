using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;
using MyBOT.Activities.Keyboards.Viber;

namespace MyBOT.Activities.Generic{
    public class MainMenuViberFactory: IActivityFactory{
        public IActivity CreateMainMenu(IStringLocalizer<SharedResource> sharedLocalizer){
            return new MainMenuViber(sharedLocalizer);
        }
    }
}