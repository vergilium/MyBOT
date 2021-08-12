using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;

namespace MyBOT.Activities.Generic{
    public class Activity{
        public IActivity MainMenu{ get; private set; }

        public Activity(IActivityFactory factory, IStringLocalizer<SharedResource> sharedLocalizer){
            MainMenu = factory.CreateMainMenu(sharedLocalizer);
        }
    }
}