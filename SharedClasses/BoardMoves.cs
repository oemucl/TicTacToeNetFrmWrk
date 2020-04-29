using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class BoardMoves
    {
        public int BoardmovesId { get; private set; }
        public int GameId { get; private set; }
        public int GamerId { get; private set; }
        public int FieldId { get; private set; }
        public BoardMoves(int boardMovesId, int gameId, int gamerId, int fieldId)
        {
            BoardmovesId = boardMovesId;
            GameId = gameId;
            GamerId = gamerId;
            FieldId = fieldId;
        }
    }
}
}
