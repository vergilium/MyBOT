using Keyboard.Const;
using Keyboard.TgmKeyboard;

namespace Keyboard {
    public class GenericButton {
        public ButtonType type{ get; private init; }
        public string text{ get; private set; }
        public string emoji{ get; private set; }
        public uint column{ get; private set; }
        public uint row{ get; private set; }
        public OnClickDelegate handler{ get; private init; }
        
        protected GenericButton(ButtonType type, string text, string emoji, uint column, uint row, OnClickDelegate handler) {
            this.type = type;
            this.text = text;
            this.emoji = emoji;
            this.column = column;
            this.row = row;
            this.handler = handler;
            
        }
        
        
    }
}