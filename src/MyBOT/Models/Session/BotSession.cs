using System.Threading.Tasks;

namespace MyBOT.Models.Session {
    public class BotSession: IBotSession {
        private readonly SessionCollection<SessionObject> _session;
        public BotSession() {
            _session = new SessionCollection<SessionObject>();
        }

        public async Task<SessionObject> GetSession(object botId) {
            return await _session.GetOrCreate(botId, CreateItem);
        }
        
        private static async Task<SessionObject> CreateItem() {
            dynamic testObj = new SessionObject();
            testObj.test = new object();
            return testObj;
        }
    }
}