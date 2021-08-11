using Keyboard.Factories.Abstract;
using Viber.Bot;

namespace Keyboard.Factories.Keyboards.Viber{
    public class MainMenuViber: IActivityViber{
        public string Text{ get; private init; }
        public object Keyboard{ get; private init; }
        
        public MainMenuViber(){
            Text = "== Главное меню ==";
            Keyboard = new global::Viber.Bot.Keyboard{
                Buttons = new[]{
                    new KeyboardButton{
                        Text = "🚪Кабинет",
                        ActionBody = "Cabinet",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = "📢Новинки",
                        ActionBody = "newest",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = "🔎Поиск",
                        ActionBody = "finder",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = "❓Помощь",
                        ActionBody = "help",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = "🔥Популятное",
                        ActionBody = "popular",
                        Columns = 2
                    },
                    new KeyboardButton{
                        Text = "🤖О боте",
                        ActionBody = "about",
                        Columns = 2
                    }
                }
            };
        }
    }
}