using System.Collections.Generic;

namespace Keyboard {
    public class GlobalKeyboard {
        private string _kbName{ get; init; }
        private List<GenericButton> _buttons{ get; init; }

        public GlobalKeyboard(List<GenericButton> buttons, string kbName) {
            _buttons = buttons;
            _kbName = kbName;
        }
        
    }
}