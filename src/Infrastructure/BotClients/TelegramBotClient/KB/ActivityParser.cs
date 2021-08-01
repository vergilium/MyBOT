using System.Xml;
using IdentityServer4.Models;

namespace TelegramAPI.KB {
    public class ActivityParser {
        private string _activityLocation{ get; init; }

        public ActivityParser(string path) {
            _activityLocation = path;
        }
        
        
    }
}