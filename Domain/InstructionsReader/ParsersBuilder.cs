namespace Domain.Parsers
{
    using Sprache;
    using System.Collections.Generic;

    public static class ParsersBuilder
    {
        public static Dictionary<string, Parser<string[]>> Build()
        {
            var parsers = new Dictionary<string, Parser<string[]>>();

            parsers.Add(Instruction.ADD, ADDParser);

            parsers.Add(Instruction.DEC, DECParser);

            parsers.Add(Instruction.INC, INCParser);

            parsers.Add(Instruction.INV, INVParser);

            parsers.Add(Instruction.JMP, JMPParser);

            parsers.Add(Instruction.JZ, JZParser);

            parsers.Add(Instruction.NOP, NOPParser);

            parsers.Add(Instruction.MOV, MOVParser);

            parsers.Add(Instruction.VMOV, VMOVParser);

            return parsers;
        }

        private static Parser<string[]> ADDParser =>
            from instruction in Parse.String(Instruction.ADD)
            from space in Parse.WhiteSpace.Once()
            from r1 in Parse.Char('R').Once()
            from rn1 in Parse.Number
            from comma in Parse.Char(',').Once()
            from r2 in Parse.Char('R').Once()
            from rn2 in Parse.Number.End()
            select new string[] { rn1, rn2 };

        private static Parser<string[]> DECParser =>
           from instruction in Parse.String(Instruction.DEC)
           from space in Parse.WhiteSpace.Once()
           from r1 in Parse.Char('R').Once()
           from rn1 in Parse.Number.End()
           select new string[] { rn1 };

        private static Parser<string[]> INCParser =>
           from instruction in Parse.String(Instruction.INC)
           from space in Parse.WhiteSpace.Once()
           from r1 in Parse.Char('R').Once()
           from rn1 in Parse.Number.End()
           select new string[] { rn1 };

        private static Parser<string[]> INVParser =>
           from instruction in Parse.String(Instruction.INV)
           from space in Parse.WhiteSpace.Once()
           from r1 in Parse.Char('R').Once()
           from rn1 in Parse.Number.End()
           select new string[] { rn1 };

        private static Parser<string[]> JMPParser =>
            from instruction in Parse.String(Instruction.JMP)
            from space in Parse.WhiteSpace.Once()
            from rn1 in Parse.Number.End()
            select new string[] { rn1 };

        private static Parser<string[]> JZParser =>
            from instruction in Parse.String(Instruction.JZ)
            from space in Parse.WhiteSpace.Once()
            from rn1 in Parse.Number.End()
            select new string[] { rn1 };

        private static Parser<string[]> MOVParser =>
            from instruction in Parse.String(Instruction.MOV)
            from space in Parse.WhiteSpace.Once()
            from r1 in Parse.Char('R').Once()
            from rn1 in Parse.Number
            from comma in Parse.Char(',').Once()
            from r2 in Parse.Char('R').Once()
            from rn2 in Parse.Number.End()
            select new string[] { rn1, rn2 };

        private static Parser<string[]> VMOVParser =>
            from instruction in Parse.String(Instruction.MOV)
            from space in Parse.WhiteSpace.Once()
            from rn1 in Parse.Number
            from comma in Parse.Char(',').Once()
            from r2 in Parse.Char('R').Once()
            from rn2 in Parse.Number.End()
            select new string[] { rn1, rn2 };

        private static Parser<string[]> NOPParser =>
            from instruction in Parse.String(Instruction.NOP).End()
            select new string[] { };
       
    }
}
