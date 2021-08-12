using MyBOT.Activities.Abstract;
using Telegram.Bot.Types.ReplyMarkups;

namespace MyBOT.Activities.Keyboards.Telegram{
    public class CabinetMenuTelegram: IActivityTelegram{
        public string Text{ get; }
        public object Keyboard{ get; }

        public CabinetMenuTelegram(){
            Text = "Личный кабинет";
            Keyboard = new ReplyKeyboardMarkup(new[]{
                new []{ new KeyboardButton("Закладки"), new KeyboardButton("Избранное"), new KeyboardButton("Рекомендации")},
                new []{new KeyboardButton("В меню")}
            });
        }
    }
}