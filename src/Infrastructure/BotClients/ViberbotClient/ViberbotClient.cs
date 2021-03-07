using Microsoft.Extensions.Options;
using System;
using Viber.Bot;

namespace ViberAPI {
	public sealed class ViberbotClient {
		public readonly IViberBotClient client;
		public ViberbotClient(IOptions<BotSettings> config) {
			client = new ViberBotClient(config.Value.key);
			string hook = $"{config.Value.url}/api/viber/update";
			client.SetWebhookAsync(hook);
		}

	}
}
