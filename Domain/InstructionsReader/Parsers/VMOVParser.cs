namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseVMOV(string rawInstruction, out ICPUInstruction instruction)
        {
            string[] tokens;

            if (!TryParse(rawInstruction, Instruction.VMOV, out tokens))
            {
                instruction = null;
                return false;
            }

            uint value;
            int registerIndex2 = int.Parse(tokens[1]);

            if (!uint.TryParse(tokens[0], out value) || IsOutOfRange(registerIndex2))
            {
                instruction = null;
                return false;
            }

            instruction = new VMOV(value, registerIndex2);
            return true;
        }
    }
}
