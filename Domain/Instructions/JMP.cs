namespace Domain.Instructions
{
    public class JMP : ICPUInstruction
    {
        int targetAddress;

        public JMP(int targetAddress)
        {
            this.targetAddress = targetAddress;
        }

        public int NextAddress(int address)
        {
            return targetAddress - 1;
        }
    }
}
