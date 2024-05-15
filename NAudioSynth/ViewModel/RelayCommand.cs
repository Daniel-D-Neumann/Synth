﻿using System;
using System.Windows.Input;

namespace NAudioSynth.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object>? execute;
        private Action<object,string>? executeParam;
        private Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested+= value; }
            remove { CommandManager.RequerySuggested -= value;}
        }


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object,string> execute, string param, Func<object,bool> canExecute = null)
        {
            this.executeParam = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}