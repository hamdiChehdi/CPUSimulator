namespace Domain.Parsers
{
    using Sprache;
    using Superpower;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class InstructionParser
    {
        //static Dictionary<string, Tokenizer<string>> Tokenizers = InstructionsTokenizersBuilder.Build();
        static Dictionary<string, Parser<string[]>> parsers = ParsersBuilder.Build();
        static bool IsOutOfRange(int registerIndex) => registerIndex is < 0 or > 42;

        static bool TryParse(string rawInstruction, string instruction, out string[] tokens)
        {
            tokens = null;

            try
            {
                var result = parsers[instruction].TryParse(rawInstruction);

                if (!result.WasSuccessful)
                {
                    return false;
                }

                tokens = result.Value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
