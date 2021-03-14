using TelegramAPI;
using Microsoft.Extensions.DependencyInjection;

namespace MyBOT.Services {
	public static class TelebotServiceExtention {
		public static void AddTelebotService(this IServiceCollection service) {
			service.AddSingleton<BotSettings, BotSettings>();
			service.AddSingleton<ITelebotClient, TelebotClient>();
		}
	}
}
