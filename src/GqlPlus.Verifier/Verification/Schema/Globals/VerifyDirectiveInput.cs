using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyDirectiveInput(
  IVerifyAliased<IGqlpSchemaDirective> aliased
) : UsageVerifier<IGqlpSchemaDirective, InputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaDirective usage, InputDeclAst[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaDirective usage, UsageContext context)
  {
    foreach (Ast.Schema.ParameterAst parameter in usage.Parameters) {
      if (!context.GetType(parameter.Type.FullName, out Ast.Schema.AstDescribed? _)) {
        context.AddError(parameter, "Directive Parameter", $"'{parameter.Type}' not defined");
      }
    }
  }
}
