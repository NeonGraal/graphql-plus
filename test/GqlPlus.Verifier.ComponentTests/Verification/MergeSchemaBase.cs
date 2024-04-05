using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class MergeSchemaBase(
    Parser<SchemaAst>.D parser)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

  protected static bool IsObjectInput(string input)
    => input is not null && input.Contains("object ", StringComparison.Ordinal);

  protected static IEnumerable<string> ValidObjects
    => VerifySchemaValidObjectsData.Source.Values
      .SelectMany(input => IsObjectInput(input)
        ? new[] {
          ReplaceObject(input, "dual", "Dual"),
          ReplaceObject(input, "input", "InP"),
          ReplaceObject(input, "output", "OutP"),
        } : [input]);

  protected static IEnumerable<string> ValidMerges
    => VerifySchemaValidMergesData.Source.Values
      .SelectMany(input => IsObjectInput(input)
        ? new[] {
          ReplaceObject(input, "dual", "Dual"),
          ReplaceObject(input, "input", "InP"),
          ReplaceObject(input, "output", "OutP"),
        } : [input]);

  protected static IEnumerable<string> AllValid
    => ValidObjects
      .Concat(ValidMerges)
      .Concat(VerifySchemaValidSchemasData.Source.Values)
      .Concat(VerifySchemaValidTypesData.Source.Values);

  protected IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  protected static string ReplaceObject(string input, string objectReplace, string objReplace)
    => input is null ? ""
    : input
      .Replace("object", objectReplace, StringComparison.InvariantCulture)
      .Replace("Obj", objReplace, StringComparison.InvariantCulture);

  protected static async Task WhenAll(params Task[] tasks)
  {
    using var scope = new AssertionScope();

    var all = Task.WhenAll(tasks);

    try {
      await all;
    } catch (Exception) {
      if (all.Exception is not null) {
        throw all.Exception;
      }

      throw;
    }
  }
}
