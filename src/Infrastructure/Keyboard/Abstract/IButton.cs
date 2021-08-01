using Keyboard.Const;
using Keyboard.TgmKeyboard;

namespace Keyboard {
    public interface IButton {
        public ButtonType type{ get; }
        public string text{ get; }
        public string emoji{ get; }
        public uint column{ get; }
        public uint row{ get; }
        public OnClickDelegate handler{ get; }

        public void SetVisible(bool visible);
        public void Move(uint col, uint row);
    }
}