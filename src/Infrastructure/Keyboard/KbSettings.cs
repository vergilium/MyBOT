using System.Dynamic;

namespace Keyboard{
    public sealed class KbSettings {
        /// <value>name of property in settings.json file</value>
        public const string KbOptions = "KeybordsOptions";
        public ushort maxRowPosition { get; set; }
        public ushort maxColPosition{ get; set; }
    }
}