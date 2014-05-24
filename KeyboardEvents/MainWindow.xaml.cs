using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyboardEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HandleKeys(null);
        }

        private void HandleKeys(KeyEventArgs e)
        {
            altTextBlock.Visibility = (Keyboard.PrimaryDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt ? Visibility.Visible : Visibility.Hidden;
            ctrlTextBlock.Visibility = (Keyboard.PrimaryDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control ? Visibility.Visible : Visibility.Hidden;
            shiftTextBlock.Visibility = (Keyboard.PrimaryDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift ? Visibility.Visible : Visibility.Hidden;
        }

        private void StackPanel_KeyDown_1(object sender, KeyEventArgs e)
        {
            HandleKeys(e);
        }

        private void StackPanel_KeyUp_1(object sender, KeyEventArgs e)
        {
            HandleKeys(e);

            Key key = e.Key != Key.System ? e.Key : e.SystemKey;

            if (key >= Key.A && key <= Key.Z)
            {
                keysPanel.Children.Add(new TextBlock { Margin = new Thickness(2), Text = key.ToString() });
            }
        }
    }
}
