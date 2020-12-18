namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseDEC(string rawInstruction, out ICPUInstruction instruction)
        {
            string[] tokens;

            if (!TryParse(rawInstruction, Instruction.DEC, out tokens))
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

            instruction = new DEC(registerIndex);
            return true;
        }

    }
}
