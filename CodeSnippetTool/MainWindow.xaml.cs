using CodeSnippetTool.Views;
using CodeSnippetTool.Hotkeys;
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

namespace CodeSnippetTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Setup for the hook
            HotkeyManager.SetupSystemHook();

            // Create hotkey Enter Control + Whatever letter and it recognizes it in the main window, see the listbox @ hotkeys fired.
            HotkeyListener saveHotkey = new HotkeyListener(ModifierKeys.Control, Key.K, saveFileExample);


            //Add hotkey
            HotkeyManager.AddHotkey(saveHotkey);



            //Shut down hook when exit app
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HotkeyManager.ShutdownSystemHook();
        }

        public void AddToList(string text)
        {
            //hotkeysFired.Items.Add(text);
        }

        public void saveFileExample()
        {
            AddToList("Tried to save using Ctrl + K");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPageView sp = new SearchPageView();
            this.Content = sp;
        }
    }
}
