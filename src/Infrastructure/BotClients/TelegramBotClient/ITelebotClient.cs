using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramAPI {
	public interface ITelebotClient {
		TelegramBotClient Client { get; }
	}
}
