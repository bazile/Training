using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: background thread
// TODO: custom templates with drag-n-drop
// TODO: cell colors
// TODO: different algorithm selection
// TODO: FPS counter
// TODO: Different draw mode: simple, double-buffering, DirectX?
// http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

namespace LifeGame
{
	//internal delegate void Tick();

	internal interface ILifeBoard
	{
		int Rows { get; }
		int Columns { get; }
		byte[] Cells  { get; }
	}

	class LifeBoard : ILifeBoard
	{
		//private const int Rows = 6;
		//private const int Columns = 6;
		//private const int Cells = Rows*Columns;
		// min 3*3

		public int Rows { get; private set; }
		public int Columns { get; private set; }
		public byte[] Cells
		{
			get { return _cells; }
		}

		public LifeBoard(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;

			_cells = new byte[(Rows + 1)*(Columns + 1)];
		}

		private readonly byte[] _cells;

		//public void Seed()
		//{
		//	_cells = new byte[Cells]
		//		{
		//			0, 0, 0, 0, 0, 0,
		//			0, 0, 0, 0, 0, 0,
		//			0, 0, 1, 1, 1, 0,
		//			0, 1, 1, 1, 0, 0,
		//			0, 0, 0, 0, 0, 0,
		//			0, 0, 0, 0, 0, 0,
		//		};
		//}

		//public void Tick()
		//{
		//}
	}

	internal interface ILifeGameAlgorithm
	{
		
	}

	internal class ClassicLifeGameAlgorithm : ILifeGameAlgorithm
	{
		private ILifeBoard _board;

		public ClassicLifeGameAlgorithm(ILifeBoard board)
		{
			_board = board;
		}

		public void Tick()
		{
			int rows = _board.Rows;
			int columns = _board.Columns;

			byte[] _cells = _board.Cells;
			var cells = new byte[_cells.Length];

			for (int i=1; i<=rows; i++)
			{
				int rowIdx = i*rows;
				for (int j=1; j<=columns-1; j++)
				{
					int idx = rowIdx + j;
					int neighbours = _cells[idx - columns - 1] + _cells[idx - columns] + _cells[idx - columns + 1] +
					                 _cells[idx + 1] + _cells[idx - 1] +
					                 _cells[idx + columns - 1] + _cells[idx + columns] + _cells[idx + columns + 1];

					if (_cells[idx] ==0)
					{
						if (neighbours == 3)
						{
							cells[idx] = 1; // born by reproduction
						}
					}
					else
					{
						if (neighbours < 2)
						{
							cells[idx] = 0; // underpopulation
						}
						else if (neighbours > 3)
						{
							cells[idx] = 0; // overpopulation
						}
						else
						{
							cells[idx] = 1;
						}
					}
				}
			}
		}
	}
}
