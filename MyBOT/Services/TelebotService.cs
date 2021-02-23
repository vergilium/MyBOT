using BotClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBOT.Services {
	public static class TelebotServiceExtention {
		public static void AddTelebotService(this IServiceCollection service) {
			service.AddSingleton<BotSettings, BotSettings>();
			service.AddSingleton<TelebotClient, TelebotClient>();
		}
	}
}
