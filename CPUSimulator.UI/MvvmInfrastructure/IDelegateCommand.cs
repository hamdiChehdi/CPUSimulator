namespace CPUSimulator.UI.MvvmInfrastructure
{
    using System.Windows.Input;

    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
