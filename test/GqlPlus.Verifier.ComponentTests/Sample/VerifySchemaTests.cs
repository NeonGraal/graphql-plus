using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Result;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifySchemaTests(
  ISchemaParseChecks checks,
  IMergerRepository mergers,
  IVerifierRepository verifierRepository
) : TestSchemaResult(checks)

{
  private readonly IMerge<IAstSchema> _schemaMerger = mergers.MergerFor<IAstSchema>();
  private readonly IVerify<IAstSchema> _schemaVerifier = verifierRepository.VerifierFor<IAstSchema>();

  protected override async Task Result_Valid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    this.SkipIf(SchemaValidData.ExcludeSpecsForBuiltIn(test));

    if (result is IResultError error) {
      error.Message.ShouldBeNull(section.Prefixed(" ") + test);
    }

    IEnumerable<IAstSchema> merged = _schemaMerger.Merge([result.Required()]);

    IMessages errors = Messages.New;

    _schemaVerifier.Verify(merged.First(), errors);

    await CheckErrors(dirs, test, errors, "verify", "parse");
  }

  protected override async Task Result_Invalid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    IMessages errors = Messages.New;
    if (result.IsOk()) {
      _schemaVerifier.Verify(result.Required(), errors);
    } else {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors, "verify", "parse");
  }
}
