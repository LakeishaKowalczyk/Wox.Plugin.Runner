﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wox.Plugin.Runner.Settings
{
    class CommandViewModel : ViewModelBase
    {
        public CommandViewModel( Command command )
        {
            Command = command;
            description = command.Description;
            shortcut = command.Shortcut;
            path = command.Path;
            argumentsFormat = command.ArgumentsFormat;
        }

        public Command Command { get; set; }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                Set( () => Description, ref description, value );
                CheckDirty();
            }
        }

        private string shortcut;
        public string Shortcut
        {
            get
            {
                return shortcut;
            }
            set
            {
                Set( () => Shortcut, ref shortcut, value );
                CheckDirty();
            }
        }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                Set( () => Path, ref path, value );
                CheckDirty();
            }
        }

        private string argumentsFormat;
        public string ArgumentsFormat
        {
            get
            {
                return argumentsFormat;
            }
            set
            {
                Set( () => ArgumentsFormat, ref argumentsFormat, value );
            }
        }

        private bool isDirty = false;
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
            set
            {
                Set( () => IsDirty, ref isDirty, value );
            }
        }

        public Command GetCommand()
        {
            if ( !IsDirty )
                return Command;
            else
                return new Command
                {
                    Description = Description,
                    Shortcut = Shortcut,
                    Path = Path,
                    ArgumentsFormat = ArgumentsFormat
                };
        }

        private void CheckDirty()
        {
            IsDirty =
                ( Description != Command.Description ) ||
                ( Shortcut != Command.Shortcut ) ||
                ( Path != Command.Path ) ||
                ( ArgumentsFormat != Command.ArgumentsFormat );
        }
    }
}
