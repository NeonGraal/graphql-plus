using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyCategoryOutput(
  IVerifyAliased<CategoryDeclAst> aliased
) : UsageAliasedVerifier<CategoryDeclAst, OutputDeclAst>(aliased)
{
  protected override void UsageValue(CategoryDeclAst usage, IMap<OutputDeclAst[]> byId, ITokenMessages errors)
  {
    if (!byId.ContainsKey(usage.Output)) {
      errors.AddError(usage, $"Invalid Category Output. '{usage.Output}' not defined.");
    }
  }
}
