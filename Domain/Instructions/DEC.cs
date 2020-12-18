namespace Domain.Instructions
{
    public class DEC : ICPUInstruction
    {
        int registerIndex;

        public DEC(int registerIndex)
        {
            this.registerIndex = registerIndex;
        }

        public void Execute()
        {
            var R = RegisterMemory.Get(registerIndex);
            RegisterMemory.Set(registerIndex, R - 1);
        }
    }
}
