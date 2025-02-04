﻿namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public bool PieceExists(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        } 

        public void PlacePiece(Piece p, Position pos)
        {
            if (PieceExists(pos))
                throw new BoardException("Já existe uma peça nesta posição!");

            pieces[pos.line, pos.column] = p;
            p.position = pos;
            p.IncreaseMovementAmount();
        }

        public Piece PickUpPiece(Position pos)
        {
            if (Piece(pos) == null)
                return null;

            Piece p = Piece(pos);
            p.position = null;
            pieces[pos.line, pos.column] = null;
            return p;
        }

        public bool IsValidPosition(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
                return false;
            else
                return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!IsValidPosition(pos))
                throw new BoardException("Posição inválida!");
        }
    }
}