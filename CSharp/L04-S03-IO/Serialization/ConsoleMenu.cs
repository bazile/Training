using System;
using System.Collections.Generic;

namespace Serialization
{
	internal class ConsoleMenu
	{
		private List<MenuItem> _items = new List<MenuItem>();

		public bool ExitSelected { get; private set; }

		public void AddItem(string text, Action itemCallback)
		{
			if (_items.Count == 10) return;

			_items.Add(new MenuItem { Text = text, ItemCallback = itemCallback });
		}

		public void Show()
		{
			ExitSelected = false;
			Console.Clear();

			for (int i = 0; i < _items.Count; i++)
			{
				MenuItem item = _items[i];
				item.Hotkey = i == 9 ? '0' : (i+1).ToString()[0];

				Console.WriteLine(" {0}. {1}", i+1, item.Text);
			}

			ConsoleKeyInfo key = Console.ReadKey(true);
			if (key.Key == ConsoleKey.Escape)
			{
				ExitSelected = true;
			}
			else if (key.KeyChar != '\0')
			{
				for (int i = 0; i < _items.Count; i++)
				{
					MenuItem item = _items[i];
					if (item.Hotkey == key.KeyChar)
					{
						if (item.ItemCallback == null)
						{
							ExitSelected = true;
						}
						else
						{
							Console.Clear();
							item.ItemCallback();
						}
						break;
					}
				}
			}

			Console.Clear();
		}

		private class MenuItem
		{
			public string Text;
			public Action ItemCallback;
			public char Hotkey;
		}
	}
}
