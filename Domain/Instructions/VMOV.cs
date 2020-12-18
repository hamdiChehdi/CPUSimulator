namespace Domain.Instructions
{
    public class VMOV : ICPUInstruction
    {
        uint value;
        int targetRegisterIndex;
        
        public VMOV(uint value, int targetRegisterIndex)
        {
            this.value = value;
            this.targetRegisterIndex = targetRegisterIndex;
        }

        public void Execute()
        {
            RegisterMemory.Set(targetRegisterIndex, value);
        }
    }
}
