namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestINCParser
    {
        [Test]
        public void TestINCParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseINC("INC Rxx", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINC("INC R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINC("INC R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseINC("INCK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestINCParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseINC("INC R10", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new INC(10));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseINC("INC R00", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new INC(0));
        }

    }
}
