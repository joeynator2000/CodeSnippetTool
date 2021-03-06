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
            HotkeysManager.SetupSystemHook();
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.S, () => { AddToList("Ctrl+S Fired"); }));

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //HotkeyManager.ShutdownSystemHook();
        }

        public void AddToList(string text)
        {
            //hotkeysFired.Items.Add(text);
        }

        public void saveFileExample()
        {
            AddToList("Tried to save using Ctrl + K");
        }
    }
}
