using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// http://habrahabr.ru/post/263569/

/*
	var life = new Life { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 1, 2 }, { 1, 3 } };

	var i = 0;
	do
	{
		Console.WriteLine("#{0}\r\n{1}", i++, life);

		Console.ReadLine();

	} while (life.Next());

	Console.WriteLine(life.Any() ? "* Stagnation!" : "* Extinction!");
*/

/*
Замечания к коду:

	Текущее состояние игры — список координат живых клеток, обновляемый на каждом шаге. В других реализациях обычно используется представление игрового поля в виде двумерного массива.
	Использование операций над множествами: объединение, пересечение, вычитание.
	Ни единого явного цикла (в классе Life).
	Использование struct для Cell позволяет не заботиться о сравнении ячеек и обеспечивает эффективное управление памятью (.NET нативно поддерживает ValueType в типизированных коллекциях).
	Практически неограниченный размер игрового поля. Причем «бесплатно».
	Возможна простая оптимизация: замена тип _cell с List на HashSet и вызовы Except()/Concat() в Next() на циклы с Remove()/Add() даст значительный прирост скорости (правда, в ущерб элегантности кода).
	Возможна простая многопоточная оптимизация: AsParallel().
	Наследование от IEnumerable и метод Add() добавлены исключительно ради изящества инициализации.

Если ставить целью исключительно компактность, код мог бы выглядеть примерно так:

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLife
{
	using Cell = Tuple<int, int>;

	public class Life
	{
		public static List<Cell> Next(List<Cell> cells)
		{
			Func<Cell, IEnumerable<Cell>> ambit = 
				cell => Enumerable.Range(-1, 3).SelectMany(x => Enumerable.Range(-1, 3)
						.Where(y => x != 0 || y != 0)
						.Select(y => new Cell(cell.Item1 + x, cell.Item2 + y)));
			Func<Cell, int> count = cell => ambit(cell).Intersect(cells).Count();
			return cells.SelectMany(ambit)
				.Where(cell => count(cell) == 3)
				.Union(cells.Where(cell => count(cell) == 2))
				.ToList();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var world = new List<Cell> { new Cell(1, 1), new Cell(2, 2), new Cell(3, 3), new Cell(1, 2), new Cell(1, 3) };
			do
			{
				Console.WriteLine(Dump(world));
				Console.ReadLine();
			} while ((world = Life.Next(world)).Any());
		}

		public static string Dump(List<Cell> cells)
		{
			int xmin = cells.Min(x => x.Item1), xmax = cells.Max(x => x.Item1), 
				ymin = cells.Min(x => x.Item2), ymax = cells.Max(x => x.Item2);
			var matrix = Enumerable.Range(xmin, xmax - xmin + 1)
				.Select(x => Enumerable.Range(ymin, ymax - ymin + 1)
					.Select(y => cells.Contains(new Cell(x, y))));
			return string.Join(Environment.NewLine, matrix.Select(row => string.Join("", row.Select(b => b ? "X" : "."))));
		}
	}
}
*/

namespace LifeGame.LINQ
{
	public struct Cell
	{
		public readonly int X, Y;

		public Cell(int x, int y) { X = x; Y = y; }
	}

	public class Life : IEnumerable<Cell>
	{
		private List<Cell> _cells = new List<Cell>();

		private static readonly int[] Liveables = { 2, 3 };

		public bool Next()
		{
			var died = _cells
				.Where(cell => !Liveables.Contains(Count(cell)))    // Условие смерти
				.ToArray();

			var born = _cells
				.SelectMany(Ambit)                                  // Все окружающие ячейки
				.Distinct()                                         // ...без дубликатов
				.Except(_cells)                                     // ...пустые
				.Where(cell => Count(cell) == 3)                    // Условие рождения
				.ToArray();

			if (died.Length == 0 && born.Length == 0)
				return false; // Нет изменений

			_cells = _cells
				.Except(died)
				.Concat(born)
				.ToList();

			return _cells.Any(); // Не все еще умерли?
		}

		private int Count(Cell cell)
		{
			return Ambit(cell)
				.Intersect(_cells)
				.Count();
		}

		private static IEnumerable<Cell> Ambit(Cell cell)
		{
			return Enumerable.Range(-1, 3)
				.SelectMany(x => Enumerable.Range(-1, 3)
					.Where(y => x != 0 || y != 0) 					// Кроме центральной клетки
					.Select(y => new Cell(cell.X + x, cell.Y + y)));
		}

		public override string ToString()
		{
			if (_cells.Count == 0)
				return string.Empty;

			var xmin = _cells.Min(cell => cell.X);
			var xmax = _cells.Max(cell => cell.X);
			var ymin = _cells.Min(cell => cell.Y);
			var ymax = _cells.Max(cell => cell.Y);

			var matrix = Enumerable.Range(xmin, xmax - xmin + 1)
				.Select(x => Enumerable.Range(ymin, ymax - ymin + 1)
					.Select(y => _cells.Contains(new Cell(x, y))));

			return string.Join(Environment.NewLine,
				matrix.Select(row =>
					string.Join("",
						row.Select(b => b ? "X" : "."))));
		}

		public IEnumerator<Cell> GetEnumerator()
		{
			return _cells.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(int x, int y)
		{
			_cells.Add(new Cell(x, y));
		}
	}
}
