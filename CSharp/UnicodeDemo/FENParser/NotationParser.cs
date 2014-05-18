using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FENParser
{
	/// <summary>
	/// Парсер шахматной нотации Форсайта — Эдвардса (Forsyth–Edwards Notation, FEN)
	/// </summary>
	/// <remarks>
	/// Начальная позиция: rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
	/// http://ru.wikipedia.org/wiki/%D0%9D%D0%BE%D1%82%D0%B0%D1%86%D0%B8%D1%8F_%D0%A4%D0%BE%D1%80%D1%81%D0%B0%D0%B9%D1%82%D0%B0_%E2%80%94_%D0%AD%D0%B4%D0%B2%D0%B0%D1%80%D0%B4%D1%81%D0%B0
	/// http://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
	/// </remarks>
	static class NotationParser
	{
		private static readonly Dictionary<char, ChessPiece> SymbolToPiece = new Dictionary<char, ChessPiece>
			{
				{'K', ChessPiece.WhiteKing},
				{'Q', ChessPiece.WhiteQueen},
				{'R', ChessPiece.WhiteRook},
				{'B', ChessPiece.WhiteBishop},
				{'N', ChessPiece.WhiteKnight},
				{'P', ChessPiece.WhitePawn},

				{'k', ChessPiece.BlackKing},
				{'q', ChessPiece.BlackQueen},
				{'r', ChessPiece.BlackRook},
				{'b', ChessPiece.BlackBishop},
				{'n', ChessPiece.BlackKnight},
				{'p', ChessPiece.BlackPawn}
			};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="notation"></param>
		/// <returns></returns>
		/// <exception cref="InvalidChessNotationException">Если нотация содержит ошибки</exception>
		public static ChessPiece[,] Parse(string notation)
		{
			var fenRegex = new Regex(@"^((([KQRBNPkqrbnp1234567]{1,8}|8)/){7}([KQRBNPkqrbnp1234567]{1,8}|8))\s(w|b)\s[kqKQ-]{1,4}\s(-|[abcdefghABCDEFGH][1-8])\s\d+\s\d+$");
			Match m = fenRegex.Match(notation);
			if (!m.Success) throw new InvalidChessNotationException("Supplied notation is not a valid FEN", notation);

			string[] rows = m.Groups[1].Value.Split('/');
			var board = new ChessPiece[8,8];
			for (int r=0; r<8; r++)
			{
				string row = rows[r];
				for (int i = 0, c = 0; i < row.Length; i++)
				{
					if (char.IsDigit(row[i]))
					{
						int emptyNum = row[i] - 48;
						for (int j = 0; j < emptyNum; j++)
						{
							board[r,c++] = ChessPiece.None;
						}
					}
					else
					{
						//switch (row[i])
						//{
						//    case 'K': board[r, c] = ChessPiece.WhiteKing; break;
						//    case 'Q': board[r, c] = ChessPiece.WhiteQueen; break;
						//    case 'R': board[r, c] = ChessPiece.WhiteRook; break;
						//    case 'B': board[r, c] = ChessPiece.WhiteBishop; break;
						//    case 'N': board[r, c] = ChessPiece.WhiteKnight; break;
						//    case 'P': board[r, c] = ChessPiece.WhitePawn; break;

						//    case 'k': board[r, c] = ChessPiece.BlackKing; break;
						//    case 'q': board[r, c] = ChessPiece.BlackQueen; break;
						//    case 'r': board[r, c] = ChessPiece.BlackRook; break;
						//    case 'b': board[r, c] = ChessPiece.BlackBishop; break;
						//    case 'n': board[r, c] = ChessPiece.BlackKnight; break;
						//    case 'p': board[r, c] = ChessPiece.BlackPawn; break;
						//}
						//c++;
						board[r, c++] = SymbolToPiece[row[i]];
					}
				}
			}

			return board;
		}
	}
}

/*
Board:

    There are exactly 8 cols
    The row sum of the empty squares and pieces add to 8

Kings:

    See if there is exactly one w_king and one b_king
    Make sure kings are separated 1 square apart

Checks:

    Non-active color is not in check
    Active color is checked less than 3 times; in case of 2 that it is never pawn+(pawn, bishop, knight), bishop+bishop, knight+knight

Pawns:

    There are no more than 8 pawns from each color
    There aren't any pawns in first or last rows
    In case of en passant square; see if it was legally created (e.g it must be on the x3 or x6 row, there must be a pawn (from the correct color) in front of it, and the en passant square and the one behind it are empty)
    Prevent having more promoted pieces than missing pawns (e.g extra_pieces = Math.max(0, num_queens-1) + Math.max(0, num_rooks-2)... and then extra_pieces <= (8-num_pawns)), also you should do special calculations for bishops, If you have two (or more) bishops from the same square color, these can only be created through pawn promotion and you should include this information to the formula above somehow
    The pawn formation is possible to reach (e.g in case of multiple pawns in a single col, there must be enough enemy pieces missing to make that formation), here are some useful rules:
        it is impossible to have more than 6 pawns in a single column (because pawns can't exist in the first and last ranks)
        it is impossible to have more than 5 pawns in a or h columns
        the minimum number of enemy missing pieces to reach a multiple pawn in a single col B to G 2=1, 3=2, 4=4, 5=6, 6=9 ___ A and H 2=1, 3=3, 4=6, 5=10, 6=impossible, for example, if you see 5 pawns in A or H, the other player must be missing at least 10 pieces from his 15 captureable pieces
        if there are white pawns in a2 and a3, there can't legally be one in b2, and this idea can be further expanded to cover more possibilities

Castling:

    If the king or rooks are not in their starting position; the castling ability for that side is lost (in the case of king, both are lost)

Bishops:

    Look for bishops in the first and last rows trapped by pawns that haven't moved, for example:
        a bishop (any color) trapped behind 3 pawns
        a bishop trapped behind 2 non-enemy pawns (not by enemy pawns because we can reach that position by underpromoting pawns, however if we check the number of pawns and extra_pieces we could determine if this case is possible or not)

Non-jumpers:

    If there are non-jumpers enemy pieces in between the king and rook and there are still some pawns without moving; check if these enemy pieces could have legally gotten in there. Also, ask yourself: was the king or rook needed to move to generate that position? (if yes, we need to make sure the castling abilities reflect this)
    If all 8 pawns are still in the starting position, all the non-jumpers must not have left their initial rank (also non-jumpers enemy pieces can't possibly have entered legally), there are other similar ideas, like if the white h-pawn moved once, the rooks should still be trapped inside the pawn formation, etc.

Half/Full move Clocks:

    In case of an en passant square, the half move clock must equal to 0
    HalfMoves <= ((FullMoves-1)*2)+(if BlackToMove 1 else 0), the +1 or +0 depends on the side to move
    The HalfMoves must be x >= 0 and the FullMoves x >= 1

Other:

    Make sure the FEN contains all the parts that are needed (e.g active color, castling ability, en passant square, etc)
 
via http://chess.stackexchange.com/questions/1482/how-to-know-when-a-fen-position-is-legal  
*/