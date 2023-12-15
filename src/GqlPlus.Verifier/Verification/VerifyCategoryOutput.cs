using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategoryOutput(
  IVerifyAliased<CategoryDeclAst> aliased
) : UsageAliasedVerifier<CategoryDeclAst, OutputDeclAst>(aliased)
{
  protected override ITokenMessages UsageValue(CategoryDeclAst usage, IMap<OutputDeclAst[]> byId)
    => byId.ContainsKey(usage.Output)
      ? new TokenMessages()
      : [usage.Error($"Invalid Category Output. '{usage.Output}' not defined.")];
}
