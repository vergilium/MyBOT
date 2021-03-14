using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Keyboard.TgmKeyboard;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramAPI;

namespace MyBOT.Controllers {
	[Route("/api/[controller]")]
	public class TelegramController : ControllerBase {
		private readonly ITelegramBotClient _client;

		public TelegramController(TelebotClient client) {
			_client = client.Client;
		}

		[HttpPost]
		[Route(@"/api/telegram/update")] //webhook uri part
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task<IActionResult> update([FromBody]Update update) {
			try {
				if (update == null) {
					Console.WriteLine("Update message is null");
					return StatusCode(StatusCodes.Status204NoContent);
				}

				var message = update.Message;
				if (message != null) {
					Console.WriteLine(message);
				}

				await _client.SendTextMessageAsync(chatId:update.Message.Chat.Id, text:"Hello",
					replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("Hello", "helloCallback")));
				
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
