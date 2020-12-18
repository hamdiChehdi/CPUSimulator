namespace Domain
{
    using System;
    using Domain.Instructions;
    using Domain.Parsers;

    public class InstructionReader
    {
        public static ICPUInstruction ParseInstruction(string rawInstruction)
        {
            rawInstruction = rawInstruction.Trim();
            ICPUInstruction instruction;

            if (InstructionParser.TryParseMOV(rawInstruction, out instruction) ||
                InstructionParser.TryParseVMOV(rawInstruction, out instruction) ||
                InstructionParser.TryParseADD(rawInstruction, out instruction) ||
                InstructionParser.TryParseDEC(rawInstruction, out instruction) ||
                InstructionParser.TryParseINC(rawInstruction, out instruction) ||
                InstructionParser.TryParseINV(rawInstruction, out instruction) ||
                InstructionParser.TryParseJMP(rawInstruction, out instruction) ||
                InstructionParser.TryParseJZ(rawInstruction, out instruction) ||
                InstructionParser.TryParseNOP(rawInstruction, out instruction))
            {
                return instruction;
            }

            return null;
        }

        public static ReadResult ReadInstructions(string[] subroutine)
        {
            ICPUInstruction[] instructions = new ICPUInstruction[subroutine.Length];
            int address = 0;

            foreach (string rawInstruction in subroutine)
            {
                var instruction = ParseInstruction(rawInstruction);

                if (instruction is null)
                {
                    return new ReadResult(instructions, true, address);
                }

                instructions[address] = instruction;
                address++;
            }

            return new ReadResult(instructions, false, 0);
        }
    }
}
