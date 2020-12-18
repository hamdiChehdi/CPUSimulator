namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseNOP(string rawInstruction, out ICPUInstruction instruction)
        {
            if (!TryParse(rawInstruction, Instruction.NOP, out _))
            {
                instruction = null;
                return false;
            }

            instruction = new NOP();
            return true;
        }
    }
}
