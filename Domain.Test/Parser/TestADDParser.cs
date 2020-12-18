namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestADDParser
    {
        [Test]
        public void TestADDParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseADD("ADD Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseADD("ADD R50,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseADD("ADD R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseADD("ADDK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestADDParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseADD("ADD R10,R05", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new ADD(10, 5));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseADD("ADD R00,R42", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new ADD(0, 42));
        }

    }
}
