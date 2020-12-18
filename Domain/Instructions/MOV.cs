namespace Domain.Instructions
{
    public class MOV : ICPUInstruction
    {
        int sourceRegisterIndex;
        int targetRegisterIndex;

        public MOV(int sourceRegisterIndex, int targetRegisterIndex)
        {
            this.sourceRegisterIndex = sourceRegisterIndex;
            this.targetRegisterIndex = targetRegisterIndex;
        }

        public void Execute()
        {
            var rsource = RegisterMemory.Get(sourceRegisterIndex);
            RegisterMemory.Set(targetRegisterIndex, rsource);
        }
    }
}
