namespace CPUSimulator.UI.ViewModel
{
    using CPUSimulator.UI.MvvmInfrastructure;
    using Domain;
    using System.Collections.ObjectModel;

    public class RegisterGridViewModel : ViewModelBase
    {
        public ObservableCollection<RegisterViewModel> Registers { get; set; }

        public RegisterGridViewModel()
        {
            Registers = new ObservableCollection<RegisterViewModel>();

            for (int i = 0; i < 43; i++)
            {
                Registers.Add(new RegisterViewModel($"R{i:D2}", 0));
            }

            RegisterMemory.OnRegisterChange += UpdateRegister;
            RegisterMemory.OnRegisterReset += ResetRegister;
        }

        private void UpdateRegister(int index, uint value)
        {
            Registers[index].Content = value;
        }

        private void ResetRegister()
        {
            foreach (var register in Registers)
            {
                register.Content = 0;
            }
        }
    }
}
