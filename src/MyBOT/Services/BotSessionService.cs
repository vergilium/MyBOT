using Microsoft.Extensions.DependencyInjection;
using MyBOT.Models.Session;

namespace MyBOT.Services {
    public static class BotSessionService {
        public static void AddBotSession(this IServiceCollection service) {
            service.AddSingleton<IBotSession, BotSession>();
        }
    }
}