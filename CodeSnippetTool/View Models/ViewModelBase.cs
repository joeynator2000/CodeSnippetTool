using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CodeSnippetTool.View_Models.Commands
{
    public class ViewModelBase
    {
        //code to be executed by button here

        public SimpleCommand SimpleCommand { get; set; }

        public ViewModelBase() 
        {
            // simple command takes viewmodel base in parameter, whicn this is refering to
            this.SimpleCommand = new SimpleCommand(this);
        }

        public void SimpleMethod() 
        {
            Debug.WriteLine("Hello");
        }
    }
}
