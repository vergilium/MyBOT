using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;
using Viber.Bot;

namespace MyBOT.Activities.Keyboards.Viber{
    public class MainMenuViber: IActivityViber{
        public string Text{ get; private init; }
        public object Keyboard{ get; private init; }
        
        public MainMenuViber(IStringLocalizer<SharedResource> sharedLocalizer){
            Text = sharedLocalizer["Main_Menu"];
            Keyboard = new global::Viber.Bot.Keyboard{
                Buttons = new[]{
                    new KeyboardButton{
                        Text = sharedLocalizer["Cabinet"],
                        ActionBody = "Cabinet",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Newest"],
                        ActionBody = "Newest",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Finder"],
                        ActionBody = "Finder",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Help"],
                        ActionBody = "Help",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["Popular"],
                        ActionBody = "Popular",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = sharedLocalizer["About"],
                        ActionBody = "about",
                        Columns = 2
                    }
                }
            };
        }
    }
}