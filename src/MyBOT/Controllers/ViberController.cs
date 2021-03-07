using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Viber.Bot;
using ViberAPI;

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
                default: break;
            }

            // you should to control required fields
            var message = new TextMessage() {
                //required
                Receiver = update.Sender.Id,
                Sender = new Viber.Bot.User() {
                    //required
                    Name = "Our bot",
                    Avatar = "http://dl-media.viber.com/1/share/2/long/bots/generic-avatar%402x.png"
                },
                //required
                Text = str
            };

            // our bot returns incoming text
            var response = await _client.SendTextMessageAsync(message);

            return Ok();
        }
    }
}
