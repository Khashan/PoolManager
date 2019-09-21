namespace ChessSharpTranslation
{
       public enum FigureType { Pawn, King, Queen, Rook, Knight, Bishop }

        //struct to make it convenient to work with cells
        public struct Pos
        {
            public readonly sbyte X;
            public readonly sbyte Y;

            public Pos(sbyte y, sbyte x)
            {
                X = x;
                Y = y;
            }
            public Pos(int y, int x)
            {
                X = (sbyte)x;
                Y = (sbyte)y;
            }
        }

        public class Figure
        {
            public FigureType Type { get; }
            public byte Owner { get; }
            public Pos Cell { get; set; }
            public Pos? PrevCell { get; }

            public Figure(FigureType type, byte owner, Pos cell, Pos? prevCell = null)
            {

            }
        }
}