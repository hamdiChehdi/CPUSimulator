using NUnit.Framework;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using Superpower.Tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    class TestSpace
    {
        [Test]
        public void FreeTest()
        {
            TextParser<Unit> registerNumber =
            from first in Character.Digit
            from second in Character.Digit
            select Unit.Value;

            Tokenizer<string> ADDtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.ADD))
            .Ignore(Span.WhiteSpace)
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Ignore(Character.EqualTo(','))
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Build();

            Tokenizer<string> DECtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.DEC))
            .Ignore(Span.WhiteSpace)
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Build();

            Tokenizer<string> INCtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.INC))
            .Ignore(Span.WhiteSpace)
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Build();

            Tokenizer<string> INVtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.INV))
            .Ignore(Span.WhiteSpace)
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Build();

            Tokenizer<string> JMPtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.JMP))
            .Ignore(Span.WhiteSpace)
            .Match(Numerics.NaturalUInt32, "value")
            .Build();

            Tokenizer<string> JZtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.JZ))
            .Ignore(Span.WhiteSpace)
            .Match(Numerics.NaturalUInt32, "value")
            .Build();

            Tokenizer<string> NOPtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.NOP))
            .Build();

            Tokenizer<string> MOVtokenizer = new TokenizerBuilder<string>()
            .Match(Span.EqualTo(Instruction.MOV), Instruction.MOV)
            .Match(Span.WhiteSpace, "space")
            .Match(Character.EqualTo('R'), "R")
            .Match(registerNumber, "registerNumber")
            .Match(Character.EqualTo(','), "comma")
            .Match(Character.EqualTo('R'), "R")
            .Match(registerNumber, "registerNumber")
            .Build();

            Tokenizer<string> VMOVtokenizer = new TokenizerBuilder<string>()
            .Ignore(Span.EqualTo(Instruction.MOV))
            .Ignore(Span.WhiteSpace)
            .Match(Numerics.NaturalUInt32, "value")
            .Ignore(Character.EqualTo(','))
            .Ignore(Character.EqualTo('R'))
            .Match(registerNumber, "registerNumber")
            .Build();

            var result = MOVtokenizer.TryTokenize("MOV 10,R01");

            if (!result.HasValue)
            {
                Assert.False(false);
            }
        }
    }
}
