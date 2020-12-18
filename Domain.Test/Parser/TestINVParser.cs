namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestINVParser
    {
        [Test]
        public void TestINVParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseINV("INV Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINV("INV R50,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINV("INV R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINV("INVK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestINVParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseINV("INV R10", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new INV(10));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseINV("INV R00", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new INV(0));
        }

    }
}
