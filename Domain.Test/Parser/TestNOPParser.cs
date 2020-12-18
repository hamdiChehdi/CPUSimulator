namespace Domain.Test
{
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestNOPParser
    {
        [Test]
        public void TestNOPParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseNOP("NOP Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseNOP("NOP sddsd", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseNOP("NOP 1122244", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseNOP("NOPK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestNOPParser_Correct_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseNOP("NOP", out instruction);
            Assert.IsTrue(answer);
            Assert.IsTrue(instruction is NOP);
        }

    }
}
