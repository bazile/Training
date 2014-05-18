using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FENParser
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly Label[,] _chessPieceLabels = new Label[8,8];

		private static readonly Dictionary<ChessPiece, string> _chessPieceSymbols = new Dictionary<ChessPiece, string>
			{
				{ ChessPiece.None       , "" },

				{ ChessPiece.WhiteKing  , "\x2654" }, // Белый король  \x2654
				{ ChessPiece.WhiteQueen , "\x2655" }, // Белый ферзь   \x2655
				{ ChessPiece.WhiteRook  , "\x2656" }, // Белая ладья   \x2656
				{ ChessPiece.WhiteBishop, "\x2657" }, // Белый слон    \x2657
				{ ChessPiece.WhiteKnight, "\x2658" }, // Белый конь    \x2658
				{ ChessPiece.WhitePawn  , "\x2659" }, // Белая пешка   \x2659

				{ ChessPiece.BlackKing  , "\x265A" }, // Черный король \x265A
				{ ChessPiece.BlackQueen , "\x265B" }, // Черный ферзь  \x265B
				{ ChessPiece.BlackRook  , "\x265C" }, // Черная ладья  \x265C
				{ ChessPiece.BlackBishop, "\x265D" }, // Черный слон   \x265D
				{ ChessPiece.BlackKnight, "\x265E" }, // Черный конь   \x265E
				{ ChessPiece.BlackPawn  , "\x265F" }, // Черная пешка  \x265F
			};

		private readonly List<Notation> _notationExamples = new List<Notation>
			{
				new Notation { Name = "Начальная позиция", Text = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"},
				new Notation { Name = "Пример №1", Text = "4kbr1/1rp1n2p/p1q1P3/B4pp1/N3p3/4P3/PPQ2P2/2KR2R1 w - - 0 1"}
			};

		public MainWindow()
		{
			InitializeComponent();

			InitBoard();

			comboBoxNotation.SelectionChanged += ComboBoxNotationOnSelectionChanged;
			comboBoxNotation.ItemsSource = _notationExamples;
			comboBoxNotation.SelectedIndex = 0;
		}

		private void ComboBoxNotationOnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var notation = (Notation)comboBoxNotation.SelectedValue;
			ChessPiece[,] board = NotationParser.Parse(notation.Text);
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					SetPiece(r + 1, c + 1, board[r, c]);
				}
			}
		}

		private void InitBoard()
		{
			var columns = new[] {"A", "B", "C", "D", "E", "F", "G", "H"};
			var rows = new[] {"8", "7", "6", "5", "4", "3", "2", "1"};
			for (int i = 0; i < 8; i++)
			{
				var topLabel = new Label
					{
						HorizontalAlignment = HorizontalAlignment.Center,
						Content = columns[i]
					};
				Grid.SetRow(topLabel, 0);
				Grid.SetColumn(topLabel, i + 1);
				chessBoardGrid.Children.Add(topLabel);

				var bottomLabel = new Label
					{
						HorizontalAlignment = HorizontalAlignment.Center,
						Content = columns[i]
					};
				Grid.SetRow(bottomLabel, 9);
				Grid.SetColumn(bottomLabel, i + 1);
				chessBoardGrid.Children.Add(bottomLabel);

				var leftLabel = new Label
					{
						HorizontalAlignment = HorizontalAlignment.Center,
						VerticalAlignment = VerticalAlignment.Center,
						Content = rows[i]
					};
				Grid.SetRow(leftLabel, i + 1);
				Grid.SetColumn(leftLabel, 0);
				chessBoardGrid.Children.Add(leftLabel);

				var rightLabel = new Label
					{
						HorizontalAlignment = HorizontalAlignment.Center,
						VerticalAlignment = VerticalAlignment.Center,
						Content = rows[i]
					};
				Grid.SetRow(rightLabel, i + 1);
				Grid.SetColumn(rightLabel, 9);
				chessBoardGrid.Children.Add(rightLabel);
			}

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					var pieceLabel = new Label
						{
							Content = " ",
							HorizontalAlignment = HorizontalAlignment.Center,
							FontFamily = new FontFamily("Segoe UI Symbol"),
							FontSize = 24
						};
					Grid.SetRow(pieceLabel, i + 1);
					Grid.SetColumn(pieceLabel, j + 1);
					chessBoardGrid.Children.Add(pieceLabel);

					_chessPieceLabels[i, j] = pieceLabel;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row">Номер строки от 1 до 8</param>
		/// <param name="column">Номер колонки от 1 до 8</param>
		/// <param name="piece">Фигура</param>
		private void SetPiece(int row, int column, ChessPiece piece)
		{
			_chessPieceLabels[row - 1, column - 1].Content = _chessPieceSymbols[piece];
		}
	}
}
