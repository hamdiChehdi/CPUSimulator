using CPUSimulator.UI.MvvmInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUSimulator.UI.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string name;
        private uint content;

        public RegisterViewModel(string name, uint content)
        {
            Name = name;
            Content = content;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public uint Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
                NotifyPropertyChanged(nameof(Content));
            }
        }
    }
}
