using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategoryOutput : UsageAliasedVerifier<CategoryAst, OutputAst>
{
  protected override string Label => "Category";
  protected override string UsageKey(CategoryAst item) => item.Output;
  protected override ITokenMessages UsageValue(CategoryAst usage, IMap<OutputAst[]> byId) => TokenMessages.Empty;
}
