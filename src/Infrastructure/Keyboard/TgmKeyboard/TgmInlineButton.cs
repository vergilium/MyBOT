using Newtonsoft.Json;

namespace Keyboard.TgmKeyboard {
    public class TgmInlineButton: TgmButton {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackData { get; set; }
        
        public TgmInlineButton(
            string text,
            string callbackData = null,
            string url = null,
            ushort col = 0,
            ushort row = 0,
            string postfix = null) {
            this.Text = text;
            this.CallbackData = callbackData;
            if (this.CallbackData == null && url != null) {
                this.Url = url;
            }
            this.col = col;
            this.row = row;
            this.postfix = postfix;
            this.type = TgmBtnType.BTN_INLINE;
        }
        
        public override void OnClick(OnClickDelegate callback) {
            throw new System.NotImplementedException();
        }
    }
}