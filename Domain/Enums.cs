using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public static class Instruction
    {
        public const string VMOV = nameof(VMOV);
        public const string MOV = nameof(MOV);
        public const string ADD = nameof(ADD);
        public const string DEC = nameof(DEC);
        public const string INC = nameof(INC);
        public const string INV = nameof(INV);
        public const string NOP = nameof(NOP);
        public const string JMP = nameof(JMP);
        public const string JZ = nameof(JZ);

        public static ReadOnlyCollection<string> InstructionTypes = new ReadOnlyCollection<string>(new List<string>() {
            MOV, ADD, DEC, INC, JMP, JZ, NOP
        });
    }
}
