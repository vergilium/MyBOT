using System.Threading.Tasks;

namespace MyBOT.Models.Session {
    public interface IBotSession {
        Task<SessionObject> GetSession(object botId);
    }
}