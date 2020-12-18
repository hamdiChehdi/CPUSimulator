namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestMOVParser
    {
        [Test]
        public void TestMOVParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseMOV("MOV Rxx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseMOV("MOV R50,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseMOV("MOV R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseMOV("MOVK R10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseMOV("MOV 10,R01", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestMOVParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseMOV("MOV R10,R05", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new MOV(10, 5));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseMOV("MOV R00,R42", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new MOV(0, 42));
        }

    }
}
