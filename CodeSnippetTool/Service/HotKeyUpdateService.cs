using CodeSnippetTool.Db;
using CodeSnippetTool.Hotkeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CodeSnippetTool.Service
{
    public class HotKeyUpdateService
    {
        public string[] oldHotKey;
        public string[] newHotKey;
        public int id;

        public HotKeyUpdateService(string oldHotKey, string newHotKey, int id)
        {
            if (oldHotKey != null)
            {
                this.oldHotKey = oldHotKey.Split("+");
            }
            this.newHotKey = newHotKey.Split("+");
            this.id = id;
        }

        public bool isValidInput()
        {
            //make first upper rest to lower of modefier string
            newHotKey[1] = newHotKey[1].First().ToString().ToUpper() + newHotKey[1].Substring(1);
            if (newHotKey.Length == 2 && newHotKey[0].Length == 1 && modefierValidation() && hotKeyValidation())
            {
                return true;
            }
            MessageBox.Show("The hotkey is invalid");
            return false;
        }

        //checks if hotkey is an int and adds D for hotkey system enum. check if the combination is already taken
        public bool hotKeyValidation()
        {
            if (newHotKey[0] != null && newHotKey[1] != null)
            {
                int number;
                if (int.TryParse(newHotKey[0], out number))
                {
                    newHotKey[0] = "D" + number.ToString();
                }

                string mod = newHotKey[1].Substring(newHotKey[1].IndexOf(':') + 1).Trim();

                newHotKey[0] += $"+{mod}";

                DbSelect dataSelecter = new DbSelect();
                if (!dataSelecter.hotKeyIsTaken(newHotKey[0], id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool modefierValidation()
        {
            return (newHotKey[1] == "Shift" || newHotKey[1] == "Alt") ? true : false; 
        }

        public void removeOldHotKey()
        {
            //Old hot key
            if (oldHotKey != null)
            {
                string oldModifier = oldHotKey[1];
                char[] oldModifierCharacters = oldModifier.ToCharArray();
                oldModifierCharacters[0] = char.ToUpper(oldModifierCharacters[0]);
                oldModifier = new string(oldModifierCharacters);

                Key keyValue = (Key)Enum.Parse(typeof(Key), oldHotKey[0], true);
                ModifierKeys modifierValue = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), oldModifier, true);
                HotkeysManager.RemoveHotkey(modifierValue, keyValue);
            } 
        }

        public string getNewHotKey()
        {
            return $"{newHotKey[0]}+{newHotKey[1]}";
        }
    }
}
