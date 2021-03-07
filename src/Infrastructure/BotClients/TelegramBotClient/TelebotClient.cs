using Microsoft.Extensions.Options;
using System;
using Telegram.Bot;

namespace TelegramAPI {
	/// <summary>
	/// Telegram BOT Client 
	/// </summary>
	public sealed class TelebotClient {
		public readonly ITelegramBotClient client;
		public TelebotClient(IOptions<BotSettings> config) {
			client = new TelegramBotClient(config.Value.key);
			string hook = $"{config.Value.url}/api/telegram/update";
			client.SetWebhookAsync(hook);
		}
	}
}
