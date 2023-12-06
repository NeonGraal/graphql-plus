using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputTypes : UsageAliasedVerifier<InputAst, AstType>
{
  protected override string Label => "Inputs";
  protected override string UsageKey(InputAst item) => item.Extends?.Name ?? "";
  protected override ITokenMessages UsageValue(InputAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
