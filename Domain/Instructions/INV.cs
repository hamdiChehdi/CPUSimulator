namespace Domain.Instructions
{
    public class INV : ICPUInstruction
    {
        int registerIndex;

        public INV(int registerIndex)
        {
            this.registerIndex = registerIndex;
        }

        public void Execute()
        {
            var R = RegisterMemory.Get(registerIndex);
            RegisterMemory.Set(registerIndex, ~R);
        }
    }
}
