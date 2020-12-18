namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestJMPParser
    {
        [Test]
        public void TestJMPParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseJMP("JMP Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJMP("JMP R50,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJMP("JZ 7", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJMP("JMP R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseJMP("JMPK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestJMPParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseJMP("JMP 15", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new JMP(15));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseJMP("JMP 0", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new JMP(0));
        }

    }
}
