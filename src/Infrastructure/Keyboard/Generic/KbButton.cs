using Keyboard.Const;
using Keyboard.TgmKeyboard;

namespace Keyboard {
    public class KbButton: GenericButton{
        public KbButton(
            ButtonType type,
            string text,
            string emoji,
            uint column,
            uint row,
            OnClickDelegate handler) : base(type, text, emoji, column, row, handler) { }
    }
}