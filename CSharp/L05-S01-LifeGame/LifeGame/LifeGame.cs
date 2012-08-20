using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: custom templates with drag-n-drop
// TODO: cell colors
// TODO: different algorithm selection

namespace LifeGame
{
	//internal delegate void Tick();

	class LifeBoard
	{
		private const int Rows = 6;
		private const int Columns = 6;
		private const int Cells = Rows*Columns;
		// min 3*3

		private byte[] _cells;// = new byte[Rows*Columns];

		public void Seed()
		{
			_cells = new byte[Cells]
				{
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0,
					0, 0, 1, 1, 1, 0,
					0, 1, 1, 1, 0, 0,
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0,
				};
		}

		public void Tick()
		{
			var cells = new byte[Cells];
			for (int i=1; i<Rows-1; i++)
			{
				int rowIdx = i*Rows;
				for (int j=1; j<Columns-1; j++)
				{
					int idx = rowIdx + j;
					int neighbours = _cells[idx - Columns - 1] + _cells[idx - Columns] + _cells[idx - Columns + 1] +
					                 _cells[idx + 1] + _cells[idx - 1] +
					                 _cells[idx + Columns - 1] + _cells[idx + Columns] + _cells[idx + Columns + 1];

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

	internal interface ILifeGameAlgorithm
	{
		
	}

	internal class ClassicLifeAlgorithm : ILifeGameAlgorithm
	{
		public void Tick()
		{
			//byte[]
		}
	}
}
