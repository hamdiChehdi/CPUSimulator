namespace CPUSimulator.UI.ViewModel
{ 
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using CPUSimulator.UI.MvvmInfrastructure;
    using Domain;

    public class MainWindowViewModel : ViewModelBase
    {
        private string programText;
        private int interval;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private bool isRunning;

        public MainWindowViewModel()
        {
            programText = string.Empty;
        }

        public string ProgramText
        {
            get
            {
                return this.programText;
            }

            set
            {
                this.programText = value;
                this.NotifyPropertyChanged(nameof(ProgramText));
            }
        }

        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
                NotifyPropertyChanged(nameof(Interval));
            }
        }

        public string[] ProgramLines => ProgramText.Split('\n');

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }

            set
            {
                isRunning = value;
                NotifyPropertyChanged(nameof(IsRunning));
                NotifyPropertyChanged(nameof(IsNotRunning));
            }
        }

        public bool IsNotRunning => !IsRunning;

        public ICommand RunProgramCommand
        {
            get
            {
                return new AsyncRelayCommand(RunProgram, OnException);
            }
        }

        public ICommand ClearProgramCommand
        {
            get
            {
                return new DelegateCommand(new Action<object>(this.EraseProgram));
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new DelegateCommand(new Action<object>(this.CancelRun));
            }
        }

        private void EraseProgram(object obj)
        {
            ProgramText = string.Empty;
            RegisterMemory.Reset();
        }

        private void CancelRun(object obj)
        {
            cancellationTokenSource.Cancel();
            IsRunning = false;
        }

        private async Task RunProgram()
        {
            IsRunning = true;
            var result = InstructionReader.ReadInstructions(ProgramLines);
            
            if (result.isFailed)
            {
                throw new Exception($"Error on Line {result.lineError}");
            }

            Program program = new Program(result.Instructions);
            await program.RunProgram(Interval, cancellationTokenSource.Token);
            IsRunning = false;
        }

        private void OnException(Exception e)
        {
            MessageBox.Show($"{e.Message}", "Compilation error", MessageBoxButton.OK, MessageBoxImage.Error);
            IsRunning = false;
        }
    }
}