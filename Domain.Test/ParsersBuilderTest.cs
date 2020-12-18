namespace Domain.Test
{
    using Domain.Parsers;
    using NUnit.Framework;

    class ParsersBuilderTest
    {
        [Test]
        public void CallBuild_Should_return_keys()
        {
            var result = ParsersBuilder.Build();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Keys, new[] {Instruction.ADD, Instruction.DEC, Instruction.INC, 
                                                Instruction.INV, Instruction.JMP, Instruction.JZ,
                                                Instruction.NOP, Instruction.MOV, Instruction.VMOV});
        }
    }
}
