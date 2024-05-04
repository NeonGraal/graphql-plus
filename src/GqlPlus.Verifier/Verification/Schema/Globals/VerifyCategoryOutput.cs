using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyCategoryOutput(
  IVerifyAliased<IGqlpSchemaCategory> aliased
) : UsageVerifier<IGqlpSchemaCategory, OutputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaCategory usage, OutputDeclAst[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaCategory usage, UsageContext context)
  {
    if (context.GetType(usage.Output, out Ast.Schema.AstDescribed? type) && type is OutputDeclAst output) {
      if (output.TypeParameters.Length > 0) {
        context.AddError(usage, "Category Output", $"'{usage.Output}' is a generic Output type");
      }
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output}' not defined or not an Output type");
    }
  }
}
