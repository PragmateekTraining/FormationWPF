using Chess.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Chess.Engine
{
    public class UCIEngine : IEngine
    {
        private readonly string engineExePath = null;
        private Process engineExeProcess = null;

        private Game currentGame = null;

        private const string bestMoveResponsePattern = "bestmove ((?:[a-h][1-8]){2}|NULL)(?: ponder (?:(?:[a-h][1-8]){2}|0000))?";
        private static readonly Regex bestMoveResponseRegex = new Regex(bestMoveResponsePattern);

        public UCIEngine(string engineExePath)
        {
            this.engineExePath = engineExePath;
        }

        public void Start()
        {
            if (engineExeProcess == null)
            {
                if (!File.Exists(engineExePath))
                {
                    throw new Exception(string.Format("Cannot find engine exe at '{0}'!", engineExePath));
                }

                engineExeProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = engineExePath,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                engineExeProcess.Start();
            }
        }

        private void SendCommand(string command)
        {
            engineExeProcess.StandardInput.WriteLine(command);
        }

        public void CheckStatus()
        {
            SendCommand("isready");

            string response = engineExeProcess.StandardOutput.ReadLine();

            if (response != "readyok")
            {
                throw new Exception("Engine is not ready!");
            }
        }

        public void StartNewGame()
        {
            CheckStatus();

            engineExeProcess.StandardInput.WriteLine("ucinewgame");

            currentGame = new Game();
        }

        public Move GetBestMove()
        {
            CheckStatus();

            string movesString = string.Join(" ", currentGame.Moves.Select(m => m.ToString()));

            SendCommand("position startpos moves " + movesString);
            SendCommand("go depth 10");

            string response = "";

            while (!response.StartsWith("bestmove "))
            {
                response = engineExeProcess.StandardOutput.ReadLine();
            }

            Match match = bestMoveResponseRegex.Match(response);

            string bestMoveString = match.Groups[1].Value;

            // = group.Captures[0].Value + group.Captures[1].Value;

            Move bestMove = bestMoveString != "NULL" ? Move.Parse(bestMoveString) : null;

            return bestMove;
        }

        private void UpdateMatedStatus()
        {
            Move bestMove = GetBestMove();

            if (bestMove == null)
            {
                AreWhitesMated = currentGame.Moves.Count % 2 == 0;
                AreBlacksMated = !AreWhitesMated;
            }
        }

        public bool AreWhitesMated { get; private set; }

        public bool AreBlacksMated { get; private set; }

        public void Execute(Move move)
        {
            currentGame.Execute(move);

            UpdateMatedStatus();
        }

        public void Stop()
        {
            if (IsRunning())
            {
                CheckStatus();

                SendCommand("quit");

                engineExeProcess.WaitForExit(Timeout.Infinite);
            }
        }

        public bool IsRunning()
        {
            return engineExeProcess != null && Process.GetProcesses().SingleOrDefault(p => p.Id == engineExeProcess.Id) != null;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
