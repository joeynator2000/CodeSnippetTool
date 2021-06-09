using System;
using System.Windows.Documents;
using System.Windows.Input;

namespace CodeSnippetTool.Hotkeys
{
    /// <summary>
    /// A hotkey containing a mod key, normal key and a callback method.
    /// </summary>
    public class HotkeyListener
    {
        public ModifierKeys Modifier { get; set; }

        public Key Key { get; set; }

        public Action Callback { get; set; }

        public bool CanExecute { get; set; }

        public HotkeyListener(ModifierKeys modifier, Key key, Action callback, bool canExecute = true)
        {
            this.Modifier = modifier;
            this.Key = key;
            this.Callback = callback;
            this.CanExecute = canExecute;
        }
    }
}
