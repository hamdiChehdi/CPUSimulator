namespace Domain.Instructions
{
    public interface ICPUInstruction
    {
        public void Execute()
        {

        }

        public int NextAddress(int address)
        {
            return address + 1;
        }
    }
}
