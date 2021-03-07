using System;
using System.Text;

namespace Keyboard {
	public class Button {
		private string _text;
		private int _row { get; set; }
		private int _col { get; set; }
		private bool _isWisible { get; set; }
		#nullable enable
		private string? _postfix = null;

		public Button(string text) {
			this._text = text;
		}

		public string text {
			get {
				StringBuilder text = new StringBuilder(this._text);
				if(_postfix != null) {
					text.Insert(text.Length, ": ");
					text.Insert(text.Length, this._postfix);
				}
				return text.ToString();
			}
		}

		public Button setPosition(int row, int col) {
			if(row > 0 && col > 0) {
				this._row = row;
				this._col = col;
			} else {
				throw new ArgumentException("Parameter 'row' and 'col' will be more zero!");
			}
			return this;
		}
	}
}
