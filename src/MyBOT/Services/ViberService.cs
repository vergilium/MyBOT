using Microsoft.Extensions.DependencyInjection;
using ViberAPI;

namespace MyBOT.Services {
	public static class ViberServiceExtention {
		public static void AddViberbotService(this IServiceCollection service) {
			service.AddSingleton<BotSettings, BotSettings>();
			service.AddSingleton<ViberbotClient, ViberbotClient>();
		}
	}
}
