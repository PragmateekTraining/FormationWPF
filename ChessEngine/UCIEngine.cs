using Chess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chess.Engine
{
    public class UCIEngine : IEngine
    {
        private readonly string engineExePath = null;
        private Process engineExeProcess = null;

        private Game currentGame = null;

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

        public Move GetNextBestMove()
        {
            CheckStatus();

            string movesString = string.Join(" ", currentGame.Moves.Select(m => m.ToString()));

            return null;
        }

        public void Execute(Move move)
        {
            currentGame.Execute(move);
        }

        public void Stop()
        {
            CheckStatus();

            SendCommand("quit");

            engineExeProcess.WaitForExit(Timeout.Infinite);
        }

        public bool IsRunning()
        {
            return engineExeProcess != null && Process.GetProcesses().SingleOrDefault(p => p.Id == engineExeProcess.Id) != null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
