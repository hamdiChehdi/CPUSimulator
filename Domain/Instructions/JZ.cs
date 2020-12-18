namespace Domain.Instructions
{
    public class JZ : ICPUInstruction
    {
        int targetAddress;

        public JZ(int targetAddress)
        {
            this.targetAddress = targetAddress;
        }

        public int NextAddress(int address)
        {
            return RegisterMemory.Get(0) == 0 ? targetAddress - 1 : address + 1;
        }
    }
}
