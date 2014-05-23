using Chess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Chess.UI.WPF
{
    public class PiecesSet
    {
        ResourceDictionary resources = null;

        public Control this[Piece piece]
        {
            get
            {
                return resources[piece.ToString()] as Control;
            }
        }

        private PiecesSet(string dictionaryPath)
        {
            using (FileStream fs = new FileStream(dictionaryPath, FileMode.Open))
            {
                resources = XamlReader.Load(fs) as ResourceDictionary;
            }
        }
    }
}
