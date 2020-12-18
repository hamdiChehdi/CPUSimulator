namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseJMP(string rawInstruction, out ICPUInstruction instruction)
        {
            string[] tokens;

            if (!TryParse(rawInstruction, Instruction.JMP, out tokens))
            {
                instruction = null;
                return false;
            }

            int targetAddress;

            if (!int.TryParse(tokens[0], out targetAddress))
            {
                instruction = null;
                return false;
            }

            instruction = new JMP(targetAddress);
            return true;
        }

    }
}
