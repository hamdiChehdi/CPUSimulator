namespace CPUSimulator.UI.ViewModel
{
    using CPUSimulator.UI.Resources;
    using Domain;
    using System.Collections.Generic;

    public class InstructionsViewModel
    {
        public List<InstructionViewModel> Instructions { get; set; }

        public InstructionsViewModel()
        {
            Instructions = new List<InstructionViewModel>();

            Instructions.Add(CreateInstructionViewModel(Instruction.VMOV));

            foreach (var instructionName in Instruction.InstructionTypes)
            {
                Instructions.Add(CreateInstructionViewModel(instructionName));
            }
        }

        private InstructionViewModel CreateInstructionViewModel(string instructionName)
        {
            var description = InstructionsDescriptions.ResourceManager.GetString($"{instructionName}_Description");
            var label = InstructionsDescriptions.ResourceManager.GetString($"{instructionName}_Label");
            return new InstructionViewModel() { Description = description, Label = label };
        }
    }
}
