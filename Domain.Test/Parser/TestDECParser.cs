namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestDECParser
    {
        [Test]
        public void TestDECParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseDEC("DEC Rxx", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseDEC("DEC R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseDEC("DEC R10,R00", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseDEC("DECK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestDECParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseDEC("DEC R10", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new DEC(10));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseDEC("DEC R00", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new DEC(0));
        }

    }
}
