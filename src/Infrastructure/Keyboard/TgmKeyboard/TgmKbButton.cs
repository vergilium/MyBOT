using System;
using Newtonsoft.Json;

namespace Keyboard.TgmKeyboard {
    public class TgmKbButton: TgmButton {

        public TgmKbButton(
            string text,
            ushort col = 0,
            ushort row = 0,
            string postfix = null,
            bool isContact = false,
            bool isLocation = false) {
            this.Text = text;
            this.col = col;
            this.row = row;
            this.postfix = postfix;
            if (isContact & isLocation) {
                throw new ArgumentException("Error parameters isContact or isLocation. They can`t be all true");
            }
            if (isContact || isLocation) {
                this.RequestContact = isContact;
                this.RequestLocation = isLocation;
                this.type = isContact ? TgmBtnType.BTN_PHONE : TgmBtnType.BTN_LOCATION;
            } else {
                this.type = TgmBtnType.BUTTON;
            }
        }
        public override void OnClick(OnClickDelegate callback) {
            throw new System.NotImplementedException();
        }
    }
}