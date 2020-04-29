using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TicTacToePersistence
{
    public class SqlServerDatabase
    {
        private SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection("Server=L02420;Database=TicTacToe;Integrated Security=true");
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.InnerException);
                return null;
            }
        }
        public bool SaveGame(Game game)
        {
            SqlCommand com;
            try
            {
                com = new SqlCommand($"Insert into game(winnerId) values (null)", getConnection());
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.InnerException);
                return false;
            }
            int cnt = 0;
            try
            {
                cnt = com.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.InnerException);
                return false;
            }
            if (cnt > 0)
                return true;
            else
                return false;
        }
        public List<BoardMoves> GetBoardMoves(int gameNo)
        {
            List<BoardMoves> bmList = new List<BoardMoves>();
            SqlCommand com = new SqlCommand($"select * from boardmoves where gameno={gameNo}", getConnection());
            SqlDataReader sqld = com.ExecuteReader();
            while (sqld.Read())
            {
                BoardMoves bm = new BoardMoves(
                    Convert.ToInt32(sqld[0].ToString()),
                    Convert.ToInt32(sqld[1].ToString()),
                    Convert.ToInt32(sqld[2].ToString()),
                    Convert.ToInt32(sqld[3].ToString()))
                    ;
                bmList.Add(bm);
            }
            return bmList;
        }
    }
}
}
