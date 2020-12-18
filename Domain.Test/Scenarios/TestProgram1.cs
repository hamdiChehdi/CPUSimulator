using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Test.Scenarios
{
    class TestProgram1
    {
        string[] subroutine;

        [SetUp]
        public void AssignProgram()
        {
            subroutine = new string[] { "MOV 5,R00", 
                                        "MOV 10,R01", 
                                        "JZ 7", 
                                        "ADD R02,R01 ", 
                                        "DEC R00 ", 
                                        "JMP 3 ",
                                        "MOV R02,R42" };
        }

        [Test]
        public void TestReadInstruction()
        {
            var result = InstructionReader.ReadInstructions(subroutine);
            Assert.IsFalse(result.isFailed);
        }


        [Test]
        public async Task TestRunInstruction()
        {
            var result = InstructionReader.ReadInstructions(subroutine);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Program program = new Program(result.Instructions);
            await program.RunProgram(10, cancellationTokenSource.Token);
        }
    }
}
