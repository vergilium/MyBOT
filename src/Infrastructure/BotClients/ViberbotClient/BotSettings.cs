using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberAPI {

	public sealed class BotSettings {
		/// <value>name of property in settings.json file</value>
		public const string botOptions = "ViberbotOptions";
		/// <value> URL string for web hook</value>
		public string url { get; set; }
		///<value>Name of telegram bot</value>
		public string name { get; set; }
		///<value>Telegram API access key</value>
		public string key { get; set; }

	}
}
