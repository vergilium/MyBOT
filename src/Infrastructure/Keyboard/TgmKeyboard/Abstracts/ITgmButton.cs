using Telegram.Bot.Types.ReplyMarkups;
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Keyboard.TgmKeyboard {
    public enum TgmBtnType {
        BUTTON = 0,
        BTN_INLINE = 1,
        BTN_PHONE = 2,
        BTN_LOCATION = 3
    }

    public delegate void OnClickDelegate(object msg);
    public interface ITgmButton: IKeyboardButton {
        ushort col{ get; set; }
        ushort row{ get; set; }
        bool isVisible{ get; set; }
        string postfix{ get; set; }
        TgmBtnType type{ get; }
        void OnClick(OnClickDelegate callback);
    }
}