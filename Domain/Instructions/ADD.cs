namespace Domain.Instructions
{
    public class ADD : ICPUInstruction
    {
        int registerIndex1;
        int registerIndex2;

        public ADD(int registerIndex1, int registerIndex2)
        {
            this.registerIndex1 = registerIndex1;
            this.registerIndex2 = registerIndex2;
        }

        public void Execute()
        {
            var R1 = RegisterMemory.Get(registerIndex1);
            var R2 = RegisterMemory.Get(registerIndex2);
            RegisterMemory.Set(registerIndex1, R1 + R2);
        }
    }
}
