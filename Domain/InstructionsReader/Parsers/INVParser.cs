namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseINV(string rawInstruction, out ICPUInstruction instruction)
        {
            string[] tokens;

            if (!TryParse(rawInstruction, Instruction.INV, out tokens))
            {
                instruction = null;
                return false;
            }

            int registerIndex = int.Parse(tokens[0]);

            if (IsOutOfRange(registerIndex))
            {
                instruction = null;
                return false;
            }

            instruction = new INV(registerIndex);
            return true;
        }

    }
}
