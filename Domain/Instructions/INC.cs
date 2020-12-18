namespace Domain.Instructions
{
    public class INC : ICPUInstruction
    {
        int registerIndex;

        public INC(int registerIndex)
        {
            this.registerIndex = registerIndex;
        }

        public void Execute()
        {
            var R = RegisterMemory.Get(registerIndex);
            RegisterMemory.Set(registerIndex, R);
        }
    }
}
