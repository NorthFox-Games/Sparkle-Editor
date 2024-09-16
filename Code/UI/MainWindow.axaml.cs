using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Sparkle_Editor.Code.UI;

public partial class MainWindow : Window
{
    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("Button clicked!");
    }
}