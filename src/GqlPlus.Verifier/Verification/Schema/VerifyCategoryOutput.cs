using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyCategoryOutput(
  IVerifyAliased<CategoryDeclAst> aliased
) : UsageAliasedVerifier<CategoryDeclAst, OutputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(CategoryDeclAst usage, IMap<OutputDeclAst[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(CategoryDeclAst usage, UsageContext context)
  {
    if (!context.GetType(usage.Output, out var _)) {
      context.AddError(usage, $"Invalid Category Output. '{usage.Output}' not defined.");
    }
  }
}
