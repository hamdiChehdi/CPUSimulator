namespace Domain
{
    using Domain.Instructions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        ICPUInstruction[] instructions;

        public Program(ICPUInstruction[] instructions)
        {
            this.instructions = instructions; 
        }

        public async Task RunProgram(int interval, CancellationToken cancellationToken)
        {
            await ExecuteInstructions(interval, cancellationToken);
            await Task.Delay(interval, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            ExecuteLastInstruction(instructions);
        }

        private async Task ExecuteInstructions(int interval, CancellationToken cancellationToken)
        {
            int pointer = 0;

            while (pointer != lastInstructionAddress)
            {
                var currentInstruction = instructions[pointer];
                currentInstruction.Execute();
                pointer = currentInstruction.NextAddress(pointer);
                await Task.Delay(interval, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private void ExecuteLastInstruction(ICPUInstruction[] instructions)
        {
            var lastInstruction = instructions[lastInstructionAddress];
            lastInstruction.Execute();
            int lastExec = lastInstruction.NextAddress(lastInstructionAddress);

            if (lastExec != lastInstructionAddress + 1)
            {
                instructions[lastExec].Execute();
            }
        }

        private int lastInstructionAddress => instructions.Length - 1;
    }
}
