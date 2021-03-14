using Microsoft.Extensions.Options;
using System;
using Telegram.Bot;

namespace TelegramAPI {
	/// <summary>
	/// Telegram BOT Client 
	/// </summary>
	public sealed class TelebotClient: ITelebotClient {
		public TelegramBotClient Client { get; private init; }
		public TelebotClient(IOptions<BotSettings> config) {
			Client = new TelegramBotClient(config.Value.key);
			string hook = $"{config.Value.url}/api/telegram/update";
			Client.SetWebhookAsync(hook);
		}
	}
}
