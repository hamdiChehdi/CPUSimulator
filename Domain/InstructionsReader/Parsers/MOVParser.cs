﻿namespace Domain.Parsers
{
    using Domain.Instructions;
    using System.Collections.Generic;

    public partial class InstructionParser
    {
        public static bool TryParseMOV(string rawInstruction, out ICPUInstruction instruction)
        {
            string[] tokens;

            if (!TryParse(rawInstruction, Instruction.MOV, out tokens))
            {
                instruction = null;
                return false;
            }

            int registerIndex1 = int.Parse(tokens[0]);
            int registerIndex2 = int.Parse(tokens[1]);

            if (IsOutOfRange(registerIndex1) || IsOutOfRange(registerIndex2))
            {
                instruction = null;
                return false;
            }

            instruction = new MOV(registerIndex1, registerIndex2);
            return true;
        }
    }
}
