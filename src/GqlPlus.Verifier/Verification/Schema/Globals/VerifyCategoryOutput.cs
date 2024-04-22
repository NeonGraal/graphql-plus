using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema.Globals;

internal class VerifyCategoryOutput(
  IVerifyAliased<CategoryDeclAst> aliased
) : UsageVerifier<CategoryDeclAst, OutputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(CategoryDeclAst usage, OutputDeclAst[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(CategoryDeclAst usage, UsageContext context)
  {
    if (context.GetType(usage.Output, out var type) && type is OutputDeclAst output) {
      if (output.TypeParameters.Length > 0) {
        context.AddError(usage, "Category Output", $"'{usage.Output}' is a generic Output type");
      }
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output}' not defined or not an Output type");
    }
  }
}
