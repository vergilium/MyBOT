using Microsoft.Extensions.Localization;
using MyBOT.Activities.Abstract;
using Telegram.Bot.Types.ReplyMarkups;

namespace MyBOT.Activities.Keyboards.Telegram{
    public class MainMenuTelegram: IActivityTelegram{
        public string Text{ get; private init; }
        public object Keyboard{ get; private init; }
        
        public MainMenuTelegram(IStringLocalizer<SharedResource> sharedLocalizer){
            Text = sharedLocalizer["Main_Menu"];
            Keyboard = new ReplyKeyboardMarkup(new[]{
                new[]{new KeyboardButton(sharedLocalizer["Cabinet"]), new KeyboardButton(sharedLocalizer["Newest"]), new KeyboardButton(sharedLocalizer["Finder"])},
                new[]{new KeyboardButton(sharedLocalizer["Help"]), new KeyboardButton(sharedLocalizer["Favorite"]), new KeyboardButton(sharedLocalizer["About"])}
            });
            ((ReplyKeyboardMarkup) Keyboard).ResizeKeyboard = true;
            ((ReplyKeyboardMarkup) Keyboard).OneTimeKeyboard = false;
        }
    }
}