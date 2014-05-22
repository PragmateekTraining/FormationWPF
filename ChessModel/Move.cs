using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Move
    {
        public Piece Piece { get; set; }
        public Square From { get; set; }
        public Square To { get; set; }

        private const string moveStringPattern = "([a-h][1-8]){2}";

        private static readonly Regex moveStringRegex = new Regex(moveStringPattern);

        public override string ToString()
        {
            return From.ToString() + To.ToString();
        }

        public static Move Parse(string moveString)
        {
            Match match = moveStringRegex.Match(moveString);

            if (!match.Success)
            {
                throw new Exception(string.Format("Expected move to match pattern {0}!", moveStringPattern));
            }

            Group group = match.Groups[1];

            string fromString = group.Captures[0].Value;
            string toString = group.Captures[1].Value;

            Move move = new Move
            {
                From = Square.Parse(fromString),
                To = Square.Parse(toString)
            };

            return move;
        }
    }
}
