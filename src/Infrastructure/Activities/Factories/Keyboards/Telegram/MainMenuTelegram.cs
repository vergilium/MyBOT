using Keyboard.Factories.Abstract;
using Telegram.Bot.Types.ReplyMarkups;

namespace Keyboard.Factories.Keyboards{
    public class MainMenuTelegram: IActivityTelegram{
        public string Text{ get; private init; }
        public object Keyboard{ get; private init; }
        
        public MainMenuTelegram(){
            Text = "== Главное меню ==";
            Keyboard = new ReplyKeyboardMarkup(new[]{
                new[]{new KeyboardButton("🚪Кабинет"), new KeyboardButton("📢Новинки"), new KeyboardButton("🔎Поиск")},
                new[]{new KeyboardButton("❓Помощь"), new KeyboardButton("🔥Популятное"), new KeyboardButton("🤖О боте")}
            });
            ((ReplyKeyboardMarkup) Keyboard).ResizeKeyboard = true;
            ((ReplyKeyboardMarkup) Keyboard).OneTimeKeyboard = false;
        }
        
    }
}