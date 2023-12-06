using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategoryOutput : UsageAliasedVerifier<CategoryDeclAst, OutputDeclAst>
{
  // protected override string UsageKey(CategoryAst item) => item.Output;
  protected override ITokenMessages UsageValue(CategoryDeclAst usage, IMap<OutputDeclAst[]> byId)
  {
    return byId.ContainsKey(usage.Output)
      ? TokenMessages.Empty
      : [usage.Error($"Invalid Category Output. '{usage.Output}' not defined.")];
  }
}
