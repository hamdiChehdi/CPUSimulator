namespace Domain.Test
{
    using DeepEqual.Syntax;
    using Domain.Instructions;
    using Domain.Parsers;
    using NUnit.Framework;

    class TestVMOVParser
    {
        [Test]
        public void TestVMOVParser_WRONG_instructions()
        {
            ICPUInstruction instruction;
            bool answer = InstructionParser.TryParseVMOV("MOV -5,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseVMOV("MOV xx,R15", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseVMOV("MOV 4294967297,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);

            answer = InstructionParser.TryParseVMOV("MOVK 10,R50", out instruction);
            Assert.IsFalse(answer);
            Assert.IsNull(instruction);
        }

        [Test]
        public void TestVMOVParser_Correct_instructions()
        {
            ICPUInstruction instruction1;
            bool answer = InstructionParser.TryParseVMOV("MOV 4294967295,R05", out instruction1);
            Assert.IsTrue(answer);
            instruction1.ShouldDeepEqual(new VMOV(4294967295, 5));

            ICPUInstruction instruction2;
            answer = InstructionParser.TryParseVMOV("MOV 0,R42", out instruction2);
            Assert.IsTrue(answer);
            instruction2.ShouldDeepEqual(new VMOV(0, 42));
        }

    }
}
