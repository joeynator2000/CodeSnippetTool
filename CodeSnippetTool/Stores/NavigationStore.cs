﻿using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
