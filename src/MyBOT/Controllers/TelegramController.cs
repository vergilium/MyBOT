using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Keyboard.TgmKeyboard;
using MyBOT.Models.Session;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramAPI;

namespace MyBOT.Controllers {
	[Route("/api/[controller]")]
	public class TelegramController : ControllerBase {
		private readonly ITelegramBotClient _client;
		private readonly IBotSession _botSession;

		public TelegramController(ITelebotClient client, IBotSession botSession) {
			_client = client.Client;
			_botSession = botSession;
		}

		[HttpPost]
		[Route(@"/api/telegram/update")] //webhook uri part
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task<IActionResult> Update([FromBody]Update update) {
			SessionObject botSession;
			try {
				if (update == null) {
					Console.WriteLine("Update message is null");
					return StatusCode(StatusCodes.Status204NoContent);
				}

				botSession = await _botSession.GetSession(update?.Message?.From.Id);

				var message = update.Message;
				if (message != null) {
					Console.WriteLine(message);
				}

				await _client.SendTextMessageAsync(chatId: update?.Message.Chat.Id, text: "Hello",
					replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton("hello")));//new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("Hello", "helloCallback")));
				
				return StatusCode(StatusCodes.Status200OK);
#pragma warning disable CS0168 // Variable is declared but never used
			} catch (Exception ex) {
#pragma warning restore CS0168 // Variable is declared but never used
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		public IActionResult Index() {
			return Ok("It's bot");
		}

	}
}
