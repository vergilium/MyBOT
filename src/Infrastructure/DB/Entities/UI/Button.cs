using DB.Domain;
using Keyboard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities {
	public class Button : DbEntity {
		///<value>button text</value>
		[Column("text")]
		public string Text { get; set; }

		///<value>for telegram prefix in button text</value>
		[Column("emoji")]
		public char Emoji { get; set; }

		///<value>button column possition</value>
		[Column("column")]
		public ushort Col { get; set; }

		///<value>button row possition</value>
		[Column("row")]
		public ushort Row { get; set; }

		///<value>button color (Viber only)</value>
		[Column("color")]
		public byte[] Color { get; set; } = { 0xFF, 0xFF, 0xFF };

		///<value>button type</value>
		[Column("media_type")]
		public BtnMediaType MediaType { get; set; }

		///<value>background media (Viber only)</value>
		[Column("bg_media")]
		public string BgMedia { get; set; }

		///<value>background media scale type (Viber only)</value>
		[Column("bg_media_scale")]
		public string BgMediaScaleType { get; set; }

		///<value>button image scale type (Viber only)</value>
		[Column("img_scale")]
		public string ImageScaleType { get; set; }

		///<value>background loop flag (Viber only)</value>
		[Column("bg_loop")]
		public bool BgLoop { get; set; } = false;

		///<value>button type</value>
		[Column("action_type")]
		public ButtonType ActionType { get; set; }

		///<value>button action (url for Viber and url for Inline button of telegram)</value>
		[Column("action")]
		public string ActionBody { get; set; }

		///<value>image on button (Viber only)</value>
		[Column("img")]
		public string Image { get; set; }

		[Column("txt_valign")]
		public string TextVAlign { get; set; }

		[Column("txt_halign")]
		public string TextHAlign { get; set; }

		[Column("txt_opacity")]
		public ushort TextOpacity { get; set; }

		[Column("txt_size")]
		public string TextSize { get; set; }
	}
}
