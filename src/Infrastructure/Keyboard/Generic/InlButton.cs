using Keyboard.Const;
using Keyboard.TgmKeyboard;

namespace Keyboard {
    public class InlButton: KbButton {
        public InlButton(
            ButtonType type,
            string text,
            string emoji,
            uint column,
            uint row,
            OnClickDelegate handler) : base(type, text, emoji, column, row, handler) { }
    }
}