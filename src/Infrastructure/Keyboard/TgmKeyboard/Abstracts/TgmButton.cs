using System;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Keyboard.TgmKeyboard {
    public abstract class TgmButton: KeyboardButton, ITgmButton {
        [JsonIgnore]
        public ushort col{ get; set; }
        [JsonIgnore]
        public ushort row{ get; set; }
        [JsonIgnore]
        public string postfix{ get; set; }
        [JsonIgnore]
        public TgmBtnType type{ get; protected init; }
        [JsonIgnore]
        public bool isVisible{ get; set; } = true;
        protected string _text{ get; set; }
        
        [JsonProperty(Required = Required.Always)]
        public new string Text{
            get {
                if (isVisible) {
                    return postfix == null ? _text : $"{_text}:{postfix}";
                }
                return String.Empty;
            }
            set => _text = value;
        }

        public abstract void OnClick(OnClickDelegate callback);
    }
}