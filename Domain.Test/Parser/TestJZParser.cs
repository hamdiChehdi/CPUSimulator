namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestJZParser
    {
        [Test]
        public void TestJZParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseJZ("JZ Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJZ("JZ R50,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJZ("JZ R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJZ("JZK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestJZParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseJZ("JZ 1500", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new JZ(1500));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseJZ("JZ 0", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new JZ(0));
        }

    }
}
