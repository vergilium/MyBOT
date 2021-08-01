using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using Keyboard;
using Keyboard.Const;
using Telegram.Bot.Types.ReplyMarkups;
using ButtonType = Keyboard.Const.ButtonType;

namespace MyBOT.Activities {
    public class MainMenu_activity {
        private string _xmlLocation{ get; init; }
        private GlobalKeyboard _replyMarkup{ get; set; }
        private List<GenericButton> _buttons{ get; set; }
        
        private string _keyboardName{ get; set; }
        private ButtonType _btnType{ get; set; } = ButtonType.UNDEFINED;
        private KeyboardScope _kbScope{ get; set; }
        
        public MainMenu_activity() {
            StringBuilder xmlLocation = new StringBuilder(Directory.GetCurrentDirectory());
            xmlLocation.Append(Path.DirectorySeparatorChar);
            xmlLocation.Append("Activities");
            xmlLocation.Append(Path.DirectorySeparatorChar);
            xmlLocation.Append(this.GetType().Name.Replace('_', '.'));
            xmlLocation.Append(".xml");
            _xmlLocation = xmlLocation.ToString();

            _buttons = new List<GenericButton>();
        }

        public bool Parse(string location = null) {
            location = _xmlLocation;
            XmlDocument activity = new XmlDocument();
            try {
                if (!File.Exists(location)) {
                    Console.WriteLine("File " + location + " is not exist!");
                    return false;
                }
                
                activity.Load(_xmlLocation);
                
                XmlElement xRoot = activity.DocumentElement;
                if (xRoot != null && xRoot.Name == "menu"){
                    _keyboardName = xRoot.Attributes.GetNamedItem("name")?.Value;
                    if (_keyboardName == null) {
                        Console.WriteLine("Keyboard name is not preset");
                        return false;
                    }
                    _kbScope = Enum.Parse<KeyboardScope>(xRoot.Attributes.GetNamedItem("scope")?.Value?.ToUpper() ?? "SINGLETON");
                    
                    foreach (XmlNode button in xRoot) {
                        if (button.Attributes != null && button.Attributes.Count > 0) {
                            ButtonType btnType = Enum.Parse<ButtonType>(button.Attributes.GetNamedItem("type")?.Value?.ToUpper() ?? "BUTTON");
                            if(_btnType == ButtonType.UNDEFINED) _btnType = btnType;
                            string btnText = button.Attributes.GetNamedItem("text")?.Value ?? String.Empty;
                            string btnEmoji = button.Attributes.GetNamedItem("emoji")?.Value;
                            UInt32.TryParse(button.Attributes.GetNamedItem("column")?.Value, out uint btnCol);
                            UInt32.TryParse(button.Attributes.GetNamedItem("row")?.Value, out uint btnRow);
                            string btnAction = button.Attributes.GetNamedItem("action")?.Value;

                            if (btnText != String.Empty) {
                                _buttons.Add(new KbButton(btnType, btnText, btnEmoji, btnCol, btnRow, null));
                            }
                        }
                    }
                }

                _replyMarkup = new GlobalKeyboard(_buttons, "MainMenu");
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

        public GlobalKeyboard GetKeyboard() {
            return _replyMarkup;
        }
    }
}