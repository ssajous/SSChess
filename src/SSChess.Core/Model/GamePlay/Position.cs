using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public class Position
    {
        public const int MinRank = 1;
        public const int MaxRank = 8;

        public int Rank { get; set; }
        public BoardFile File { get; set; }

        public Position(string square)
        {
            throw new NotImplementedException();
        }

        public Position(int rank, BoardFile file)
        {
            Rank = rank;
            File = file;
        }

        /// <summary>
        /// Provides a list of all positions that are directly 
        /// adjacent to the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> AdjacentPositions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all positions in the same 
        /// rank as the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> CurrentRankPositions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all positions in the same
        /// file as the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> CurrentFilePositions()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", File.Name, Rank);
        }

        
    }
}
