using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using BotClient;

namespace MyBOT.Controllers {
	[Route("/api/[controller]")]
	public class MessageController : ControllerBase {
		private readonly ITelegramBotClient _client;

		public MessageController(TelebotClient client) {
			_client = client.client;
		}

		[HttpPost]
		[Route(@"/api/message/update")] //webhook uri part
		[Consumes(MediaTypeNames.Application.Json)]
		public IActionResult update([FromBody]Update update) {
			try {
				if (update == null) {
					Console.WriteLine("Update message is null");
					return StatusCode(StatusCodes.Status204NoContent);
				}

				var message = update.Message;
				if (message != null) {
					Console.WriteLine(message);
				}
				return StatusCode(StatusCodes.Status200OK);
#pragma warning disable CS0168 // Variable is declared but never used
			} catch (Exception ex) {
#pragma warning restore CS0168 // Variable is declared but never used
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		public IActionResult index() {
			return Ok("It's bot");
		}

	}
}
