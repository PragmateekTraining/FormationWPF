using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Engine
{
    public interface IEngine : IDisposable
    {
        void Start();
        void Stop();

        bool IsRunning();

        void StartNewGame();

        void Execute(Move move);
        Move GetNextBestMove();

        void CheckStatus();
    }
}
