using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UsageExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ExampleViewModel VM => (ExampleViewModel)FindResource("VM");

        private void IDTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = true; //< don't allow alphabetic characters to be entered
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var listBoxItem = (ListBoxItem)button.DataContext;
            var itemIndex = ItemsListBox.ItemContainerGenerator.IndexFromContainer(listBoxItem);
            VM.Items.RemoveAt(itemIndex);
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            VM.Items.Add(new ExampleObject("", 0));
        }
    }
}
