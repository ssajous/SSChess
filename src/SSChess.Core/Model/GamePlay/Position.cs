using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public class Position
    {
        public const int MinRank = 1;
        public const int MaxRank = 8;

        private Regex coordinatePattern = new Regex(@"([a-h])([1-8])");

        public int Rank { get; set; }
        public BoardFile File { get; set; }

        public Position(string square)
        {
            ParseCoordinate(square);
        }

        public Position(int rank, BoardFile file)
        {
            Rank = rank;
            File = file;
        }

        private void ParseCoordinate(string coordinate)
        {
            Match match = coordinatePattern.Match(coordinate);
            if (!match.Success)
            {
                throw new ArgumentException();
            }

            File = new BoardFile(match.Groups[1].Value.ToCharArray()[0]);
            Rank = int.Parse(match.Groups[2].Value);
        }

        /// <summary>
        /// Provides a list of all positions that are directly 
        /// adjacent to the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> GetAdjacentPositions()
        {
            List<Position> positions = new List<Position>();
            BoardFile nextFile = File.NextFile();
            BoardFile prevFile = File.PreviousFile();

            AddLowerRankPositions(positions, nextFile, prevFile);
            AddSameRankPositions(positions, nextFile, prevFile);
            AddHigherRankPositions(positions, nextFile, prevFile);

            return positions;
        }

        private void AddHigherRankPositions(List<Position> positions, BoardFile nextFile, BoardFile prevFile)
        {
            if (Rank < MaxRank)
            {
                positions.Add(new Position(Rank + 1, File));
                if (prevFile != null)
                {
                    positions.Add(new Position(Rank + 1, prevFile));
                }
                if (nextFile != null)
                {
                    positions.Add(new Position(Rank + 1, nextFile));
                }
            }
        }

        private void AddSameRankPositions(List<Position> positions, BoardFile nextFile, BoardFile prevFile)
        {
            if (prevFile != null)
            {
                positions.Add(new Position(Rank, prevFile));
            }
            if (nextFile != null)
            {
                positions.Add(new Position(Rank, nextFile));
            }
        }

        private void AddLowerRankPositions(List<Position> positions, BoardFile nextFile, BoardFile prevFile)
        {
            if (Rank > MinRank)
            {
                positions.Add(new Position(Rank - 1, File));
                if (prevFile != null)
                {
                    positions.Add(new Position(Rank - 1, prevFile));
                }
                if (nextFile != null)
                {
                    positions.Add(new Position(Rank - 1, nextFile));
                }
            }
        }

        /// <summary>
        /// Returns a list of all positions in the same 
        /// rank as the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> GetCurrentRankPositions()
        {
            List<Position> positions = new List<Position>();
            for (int i = MinRank; i <= MaxRank; i++)
            {
                positions.Add(new Position(i, File));
            }
            return positions;
        }

        /// <summary>
        /// Returns a list of all positions in the same
        /// file as the current position
        /// </summary>
        /// <returns></returns>
        public List<Position> GetCurrentFilePositions()
        {
            List<Position> positions = new List<Position>();

            for (BoardFile iter = new BoardFile(BoardFile.MinIndex); iter != null; iter = iter.NextFile())
            {
                positions.Add(new Position(Rank, iter));
            }
            return positions;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", File.Name, Rank);
        }

        public ChessColor SquareColor
        {
            get
            {
                if ((Rank + File.Index) % 2 == 0)
                {
                    return ChessColor.Black;
                }
                else
                {
                    return ChessColor.White;
                }
            }
        }

        public List<Position> GetCurrentDiagonalPositions()
        {
            List<Position> positions = new List<Position>();
            
            positions.Add(this);
            
            AddLowerLeftDiagonals(positions);
            AddLowerRightDiagonals(positions);
            AddUpperLeftDiagonals(positions);
            AddUpperRightDiagonals(positions);


            return positions;
        }

        private void AddUpperRightDiagonals(List<Position> positions)
        {
            int currentRank;
            BoardFile currentFile;

            if (Rank < MaxRank && File.Index < BoardFile.MaxIndex)
            {
                currentRank = Rank + 1;
                currentFile = File.NextFile();

                while (currentRank <= MaxRank && currentFile != null)
                {
                    positions.Add(new Position(currentRank, currentFile));
                    currentRank++;
                    currentFile = currentFile.NextFile();
                }
            }
        }

        private void AddUpperLeftDiagonals(List<Position> positions)
        {
            int currentRank;
            BoardFile currentFile;

            if (Rank < MaxRank && File.Index > BoardFile.MinIndex)
            {
                currentRank = Rank + 1;
                currentFile = File.PreviousFile();

                while (currentRank <= MaxRank && currentFile != null)
                {
                    positions.Add(new Position(currentRank, currentFile));
                    currentRank++;
                    currentFile = currentFile.PreviousFile();
                }
            }
        }

        private void AddLowerRightDiagonals(List<Position> positions)
        {
            int currentRank;
            BoardFile currentFile;

            if (Rank > MinRank && File.Index < BoardFile.MaxIndex)
            {
                currentRank = Rank - 1;
                currentFile = File.NextFile();

                while (currentRank >= MinRank && currentFile != null)
                {
                    positions.Add(new Position(currentRank, currentFile));
                    currentRank--;
                    currentFile = currentFile.NextFile();
                }
            }
        }

        private void AddLowerLeftDiagonals(List<Position> positions)
        {
            int currentRank;
            BoardFile currentFile;

            if (Rank > MinRank && File.Index > BoardFile.MinIndex)
            {
                currentRank = Rank - 1;
                currentFile = File.PreviousFile();

                while (currentRank >= MinRank && currentFile != null)
                {
                    positions.Add(new Position(currentRank, currentFile));
                    currentRank--;
                    currentFile = currentFile.PreviousFile();
                }
            }
        }
    }
}
