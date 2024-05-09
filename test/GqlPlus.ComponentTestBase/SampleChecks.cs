using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;
public class SampleChecks(Parser<IGqlpSchema>.D schemaParser)
{
  private readonly Parser<IGqlpSchema>.L _schemaParser = schemaParser;

  protected async Task<IGqlpSchema> ParseSchema(string sample)
  {
    string schema = await File.ReadAllTextAsync("Sample/Schema/" + sample + ".graphql+");
    Tokenizer tokens = new(schema);

    return _schemaParser.Parse(tokens, "Schema").Required();
  }

  protected VerifySettings SampleSettings(string dir, string file)
  {
    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory("SampleTests/" + dir);
    settings.UseFileName(file);

    return settings;
  }
}
