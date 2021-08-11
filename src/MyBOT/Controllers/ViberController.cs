using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Keyboard.Factories.Generic;
using Viber.Bot;
using ViberAPI;
using Keyboard = Viber.Bot.Keyboard;

namespace MyBOT.Controllers {
	[Route("/api/[controller]")]
	public class ViberController : ControllerBase {
		private readonly IViberBotClient _client;

		public ViberController(ViberbotClient client) {
			_client = client.client;
		}

		[HttpGet]
		public IActionResult Get() {
			if (Response.StatusCode == 200) {
				return Ok("Viber-bot is active");
			} else {
				return BadRequest();
			}
		}

		[HttpPost]
		[Route(@"/api/viber/update")] //webhook uri part
		[Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] Viber.Bot.CallbackData update) {
            var str = String.Empty;

            switch (update.Event) {
                case Viber.Bot.EventType.Message: {
                    var mess = update.Message as Viber.Bot.TextMessage;
                    str = mess.Text;
                    break;
                }
                default: return NoContent();
            }

            var activity = new Activity(new MainMenuViberFactory());

	            // our bot returns incoming text
            await _client.SendKeyboardMessageAsync(new KeyboardMessage
            {
	            Receiver = update.Sender.Id,
	            Text = activity.MainMenu.Text,
	            Keyboard = (Viber.Bot.Keyboard) activity.MainMenu.Keyboard,
	            TrackingData = "td"
            });

            return Ok();
        }
    }
}
