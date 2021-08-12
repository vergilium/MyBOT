using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;
using Viber.Bot;

namespace MyBOT.Activities.Keyboards.Viber{
    public class CabinetMenuViber: IActivityViber{
        public string Text{ get; }
        public object Keyboard{ get; }

        public CabinetMenuViber(IStringLocalizer<SharedResource> sharedLocalizer){
            Text = sharedLocalizer["Personal_room"];
            Keyboard = new Keyboard{
                Buttons = new[]{
                    new KeyboardButton{
                        Text = sharedLocalizer["Bookmarks"],
                        ActionBody = "Bookmarks",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Favorite"],
                        ActionBody = "Favorite",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Recommend"],
                        ActionBody = "Recommend",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["ToMenu"],
                        ActionBody = "ToMenu",
                        Columns = 2
                    }
                }
            };
        }
    }
}